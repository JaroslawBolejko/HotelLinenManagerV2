using System;
using System.Text;

namespace KonolaTestowa
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PasswordDeConventer("ug+Eo+FZV9jii8KN4dVvkj6PwguXSAEOAcdOZh2Vxr8="));
        }

        protected static string PasswordDeConventer(string str)
        {
            var byteTab = Convert.FromBase64String(str);
            return Encoding.UTF8.GetString(byteTab);
        }
    }
}
