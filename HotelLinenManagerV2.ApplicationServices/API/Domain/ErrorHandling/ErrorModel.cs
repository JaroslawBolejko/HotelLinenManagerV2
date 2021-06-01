namespace HotelLinenManagerV2.ApplicationServices.API.Domain.ErrorHandling
{
    public class ErrorModel
    {
        public ErrorModel(string error)
        {
            this.Error = error;
        }

        public string Error { get; }
    }
}
