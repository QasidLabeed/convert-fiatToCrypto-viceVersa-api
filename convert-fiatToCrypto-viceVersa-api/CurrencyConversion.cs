using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace convert_fiatToCrypto_viceVersa_api
{
    public class CurrencyConversion
    {
        // No Parameter function
        public string CurConv()
        {
            
            //string[] Param = { from, to };
            string conv = "https://min-api.cryptocompare.com/data/pricehistorical?fsym=USD&tsyms=AUD";
            
            //Object creation
            Api ConvCurrency = new Api();
            var response = ConvCurrency.CallApi(conv);

            //Convert string result to JSON Object
            var JObj = ConvCurrency.GetJsonObj(response);

            return Convert.ToString(JObj["USD"]);
        }

        //Overloaded function
        public string CurConv(string from, string to, int amount)
        {
           
            string[] Param = { from,to };
            string conv = "https://min-api.cryptocompare.com/data/pricehistorical?fsym=" + Param[0] + "&tsyms=" + Param[1];

            //Object creation
            Api ConvCurrency = new Api();
            var response = ConvCurrency.CallApi(conv);

            //Convert string result to JSON Object
            var JObj = ConvCurrency.GetJsonObj(response);

            //Value extracted from JObj is converted to double for calculation
            var result = Convert.ToDouble(JObj[from][to]);
            var finalAmount = result * amount;
           
            return Convert.ToString(finalAmount);
        }
    }
}
