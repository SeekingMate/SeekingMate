using RestSharp;
using FreesomeShared;

namespace Freesome
{
    internal static class ServerAPIHelper
    {
        public static string ServerAddress = @"http://localhost:5228/";

        public static async Task<News[]> GetNews()
        {
            try
            {
                var client = new RestClient(ServerAddress);
                var request = new RestRequest("api/News", Method.Get);
                return await client.GetAsync<News[]>(request);
            }
            catch (Exception)
            {
                return Array.Empty<News>();
            }
        }
    }
}
