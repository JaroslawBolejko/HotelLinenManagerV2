using GusData;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WcfCoreMtomEncoder;

namespace HotelLinenManagerV2.ApplicationServices.Components.GUSDataConnector
{
    public class GUSDataConnector : IGUSDataConnector
    {

        public UslugaBIRzewnPublClient uslugaBIRzewn;
        readonly string AdresUslugi = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("GUSAppSettings")["GUSAdresUslugi"];
        readonly string sid;
        readonly string tokken = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("GUSAppSettings")["GUSApiTokken"];
      
        public GUSDataConnector()
        {
            uslugaBIRzewn = new UslugaBIRzewnPublClient();
            uslugaBIRzewn.Endpoint.Address = new(AdresUslugi);
            var encoding = new MtomMessageEncoderBindingElement(new TextMessageEncodingBindingElement());
            var transport = new HttpsTransportBindingElement();

            var customBinding = new CustomBinding(encoding, transport);
            uslugaBIRzewn.Endpoint.Binding = customBinding;

            sid = Loguj().Result;
        }
        async Task<string> Loguj()
        {
            var klucz = await uslugaBIRzewn.ZalogujAsync(tokken);
            return klucz.ZalogujResult;
        }

        public async Task<T> szukajPodmioty<T>(string nip)
        {
            OperationContextScope scope = new OperationContextScope(uslugaBIRzewn.InnerChannel);
            HttpRequestMessageProperty httpRequest = new HttpRequestMessageProperty();
            httpRequest.Headers.Add("sid", sid);
            OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequest;

            var parametrSzukajKontrahenta = new ParametryWyszukiwania
            {
                Nip = nip
            };

            var response = await uslugaBIRzewn.DaneSzukajPodmiotyAsync(parametrSzukajKontrahenta);

            return DeserializeFromXml<T>(response.DaneSzukajPodmiotyResult);
        }
        public static T DeserializeFromXml<T>(string xml)
        {
            T result;

            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (TextReader tr = new StringReader(xml))
            {
                result = (T)ser.Deserialize(tr);
            }
            return result;
        }

    }
}
