using RestSharp;

namespace SaftOgKraft.WebSite.ApiClient;

public interface IRestClientWrapper
{
    Task<RestResponse<T>> ExecuteAsync<T>(RestRequest request);
}
