namespace HotelLinenManagerV2.ApplicationServices.Components.Validation
{
    public class StartsWithDigit : IStartsWithDigit
    {
       public bool DigitStarter(string toCheck)
        {
            
            if (string.IsNullOrEmpty(toCheck) || char.IsDigit(toCheck[0]))
                return true;
            return false;
        }
    }
}
