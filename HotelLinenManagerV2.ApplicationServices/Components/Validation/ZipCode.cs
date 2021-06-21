using System;

namespace HotelLinenManagerV2.ApplicationServices.Components.Validation
{
    public class ZipCode : IZipCode
    {
        public bool IsPostalCode(string code)
        {
            bool isNumber = false;
            string number;
            int position = code.IndexOf('-');

            if (position == -1)
            {
                isNumber = Int32.TryParse(code, out int result);
            }
            else
            {
                number = code.Remove(position, 1);
                isNumber = Int32.TryParse(number, out int result);

            }

            if (position == 2 && isNumber == true) return true;
            return false;

        }
    }
    
}
