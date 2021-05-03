
using System.Threading.Tasks;

namespace Infrastructure.Data.RequestHandlers
{
public interface IHttpEnpointRequest
    {
        Task<T> Get<T>(string url) where T : class;
        Task<T> Post<T>(string url, string requestBody) where T : class;
    }

}