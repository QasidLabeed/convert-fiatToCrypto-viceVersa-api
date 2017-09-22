using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace convert_fiatToCrypto_viceVersa_api
{
    class CurrencyConversion
    {
        public string CallApi()
        {
            Console.WriteLine("Enter Currecy From");
            string from = Console.ReadLine();
            Console.WriteLine("Enter Currency To");
            string to = Console.ReadLine();
            Console.WriteLine("Enter Amount to be converted ");
            double amount = Convert.ToDouble(Console.ReadLine());


            string[] Param = { from, to };
            string conv = "https://min-api.cryptocompare.com/data/pricehistorical?fsym=" + Param[0] + "&tsyms=" + Param[1];
            
            Api ConvCurrency = new Api();
            var response = ConvCurrency.CallApi(conv);
            var stringResult = ConvCurrency.GetJsonObj(response);

            var result = Convert.ToDouble(stringResult[from][to]);
            var finalAmount = result * amount;
            return "1 " + from + " = " +result+" "+to+ "\n"+ "So "+amount+" "+from+" = "+finalAmount+" "+to;
        }    
    }
}
