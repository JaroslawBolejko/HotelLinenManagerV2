using System;

namespace HotelLinenManagerV2.ApplicationServices.Components.DocNumCreator
{
    public  class DocNumCreator : IDocNumCreator
    {
        public  string DocumentNumberCreator(string str)
        {
            var number = 1;
            var currentYear = DateTime.Now.Year;
            var currentMonth = DateTime.Now.Month;

            if (str == "0/0/0")
            {
                return $"{number}/{currentMonth}/{currentYear}";
            }
            else
            {
                var tabOfNumbersFromDocument = str.Split("/", StringSplitOptions.RemoveEmptyEntries);
                var docNumber = int.Parse(tabOfNumbersFromDocument[0]);
                var month = int.Parse(tabOfNumbersFromDocument[1]);
                var year = int.Parse(tabOfNumbersFromDocument[2]);

                if (currentMonth > month)
                {
                    return $"{number}/{currentMonth}/{currentYear}";
                }
                else if (currentYear > year)
                {
                    return $"{number}/{currentMonth}/{currentYear}";
                }
                else
                {
                    return $"{++docNumber}/{currentMonth}/{currentYear}";
                }

            }
        }
    }
}
