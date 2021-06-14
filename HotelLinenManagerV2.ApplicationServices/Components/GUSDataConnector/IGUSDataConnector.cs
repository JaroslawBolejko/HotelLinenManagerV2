using System.Threading.Tasks;

namespace HotelLinenManagerV2.ApplicationServices.Components.GUSDataConnector
{
    public interface IGUSDataConnector
    {
        Task<T> szukajPodmioty<T>(string nip);

    }
}
