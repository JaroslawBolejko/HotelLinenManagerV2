using System;
using System.Text;

namespace KonolaTestowa
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date = new(7/11/2016);
            Console.WriteLine(date.DayOfWeek);
        }

        protected static string PasswordDeConventer(string str)
        {
            var byteTab = Convert.FromBase64String(str);
            return Encoding.UTF8.GetString(byteTab);
        }
    }
}
