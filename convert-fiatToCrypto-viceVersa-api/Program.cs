using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace convert_fiatToCrypto_viceVersa_api
{
    class Program
    {
        static void Main(string[] args)
        {
            CurrencyConversion currencyConversion = new CurrencyConversion();
            var result=currencyConversion.CurConv();
            Console.WriteLine(result);
            Console.ReadKey();

        }
    }
}
