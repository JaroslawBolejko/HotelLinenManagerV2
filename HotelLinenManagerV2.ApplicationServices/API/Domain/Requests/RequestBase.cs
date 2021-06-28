namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Requests
{
    public class RequestBase
    {
        public string AuthenticationName { get; set; }
        public string AuthenticationRole { get; set; }
        public int AuthenticationCompanyId { get; set; }
    }
}
