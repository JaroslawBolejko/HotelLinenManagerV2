using System.Xml.Serialization;

namespace HotelLinenManagerV2.ApplicationServices.Components.GUSDataConnector
{

    [XmlRoot(ElementName = "dane")]
    public class DaneSzukajPodmioty
    {

        [XmlElement(ElementName = "Nip")]
        public string Nip { get; set; }
        [XmlElement(ElementName = "Nazwa")]
        public string Nazwa { get; set; }

        [XmlElement(ElementName = "Miejscowosc")]
        public string Miejscowosc { get; set; }
        [XmlElement(ElementName = "KodPocztowy")]
        public string KodPocztowy { get; set; }
        [XmlElement(ElementName = "Ulica")]
        public string Ulica { get; set; }
        [XmlElement(ElementName = "NrNieruchomosci")]
        public string NrNieruchomosci { get; set; }
        [XmlElement(ElementName = "NrLokalu")]
        public string NrLokalu { get; set; }

    }

    [XmlRoot(ElementName = "root")]
    public class RootDaneSzukajPodmioty
    {
        [XmlElement(ElementName = "dane")]
        public DaneSzukajPodmioty Dane { get; set; }


    }

}