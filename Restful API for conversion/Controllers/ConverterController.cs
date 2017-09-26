using System.Net.Http;
using System.Text;
using System.Web.Http;
using convert_fiatToCrypto_viceVersa_api;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace Restful_API_for_conversion.Controllers
{
    [EnableCors("*","*","*")]
    public class ConverterController : ApiController
    {

        [EnableCors("*", "*", "*")]
        public HttpResponseMessage GET()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new StringContent("The api format is\ntesting12.gear.host/api/converter?from=value&to=value&amount=value", Encoding.Unicode, "application/json");
            return response;

        }

        [EnableCors("*", "*", "*")]
        public HttpResponseMessage GET(string from,string to,double amount)
        {
            try
            {
                CurrencyConversion currencyConversion = new CurrencyConversion();
                string result = currencyConversion.CurConv(from, to, amount);
                HttpResponseMessage response = new HttpResponseMessage();
                response.Content = new StringContent(result, Encoding.Unicode, "application/json");
                return response;
            }
            catch (System.Exception)
            {
                HttpResponseMessage response = new HttpResponseMessage();
                response.Content = new StringContent("Invalid Parameters Passed", Encoding.Unicode,"application/json");
                return response;
            }
           

            

        }
        
    }
}
