using System;

namespace BlazorApp.Helpers

{
    public class DocNumCreator
    {
        public string DocumentNumerCreator(string str)
        {
            var number = 1;
            var currentYear = DateTime.Now.Year;
            var currentMonth = DateTime.Now.Month;

            if (str == null)
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
