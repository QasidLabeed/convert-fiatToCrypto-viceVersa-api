using System.Net.Http;
using System.Text;
using System.Web.Http;
using convert_fiatToCrypto_viceVersa_api;


namespace Restful_API_for_conversion.Controllers
{
    public class ConverterController : ApiController
    {


        public HttpResponseMessage GET()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new StringContent("The api format is\n localhost:8548/api/converter?from=value&to=value&amount=value", Encoding.Unicode, "application/json");
            return response;

        }
        public HttpResponseMessage GET(string from,string to,int amount)
        {
            CurrencyConversion currencyConversion = new CurrencyConversion();
            string result =currencyConversion.CallApi(from,to,amount);

            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new StringContent(result, Encoding.Unicode, "application/json");
            return response;

        }
        
    }
}
