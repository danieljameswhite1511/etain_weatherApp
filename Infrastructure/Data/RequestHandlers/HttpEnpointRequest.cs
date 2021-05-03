using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.RequestHandlers
{
    public class HttpEnpointRequest : IHttpEnpointRequest
    {
        public async Task<T> Get<T>(string url) where T : class
        {
            var handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (HttpRequestMessage, ClientCertificateOption, cetChain, policyErrors) =>
                {
                    return true;
                };

            var http = new HttpClient(handler);

            var request = await http.GetAsync(url);
            var response = request.Content.ReadAsAsync<T>().Result;

            return response;

        }
        

         public async Task<List<T>> GetList<T>(string url) where T : class
        {
            var handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (HttpRequestMessage, ClientCertificateOption, cetChain, policyErrors) =>
                {
                    return true;
                };

            var http = new HttpClient(handler);

            var request = await http.GetAsync(url);
            var response = request.Content.ReadAsAsync<List<T>>().Result;

            return response;

        }

        public async Task<T> Post<T>(string url, string requestBody) where T : class
        {
            var handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (HttpRequestMessage, ClientCertificateOption, cetChain, policyErrors) =>
                {
                    return true;
                };

            var body = new StringContent(requestBody, Encoding.UTF8, "application/json");

            var http = new HttpClient(handler);

            var request = await http.PostAsync(url, body);
            var response = request.Content.ReadAsAsync<T>().Result;

            return response;

        }
    }
}