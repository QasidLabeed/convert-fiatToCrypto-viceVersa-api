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
            //Get Currency to convert to
            Console.WriteLine("Enter Currecy From");
            string from = Console.ReadLine();

            //Get Currency to be converted
            Console.WriteLine("Enter Currency To");
            string to = Console.ReadLine();

            //Get the amount to be converted
            Console.WriteLine("Enter Amount to be converted ");
            double amount = Convert.ToDouble(Console.ReadLine());


            string[] Param = { from, to };
            string conv = "https://min-api.cryptocompare.com/data/pricehistorical?fsym=" + Param[0] + "&tsyms=" + Param[1];
            
            //Object creation
            Api ConvCurrency = new Api();
            var response = ConvCurrency.CallApi(conv);

            //Convert string result to JSON Object
            var JObj = ConvCurrency.GetJsonObj(response);

            //Value extracted from JObj is converted to double for calculation
            var result = Convert.ToDouble(JObj[from][to]);
            var finalAmount = result * amount;
            return "1 " + from + " = " +result+" "+to+ "\n"+ "So "+amount+" "+from+" = "+finalAmount+" "+to;
        }    
    }
}
