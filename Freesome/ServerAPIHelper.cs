using RestSharp;
using FreesomeShared;

namespace Freesome
{
    internal static class ServerAPIHelper
    {
        public static string ServerAddress = @"http://localhost:5228/";

        public static async Task<string> Login(string accessCodeHashed, string passphraseHashed)
        {
            try
            {
                var client = new RestClient(ServerAddress);
                var request = new RestRequest("api/User/Login", Method.Post)
                    .AddJsonBody(new UserControllerLoginParameters(accessCodeHashed, passphraseHashed));
                return await client.PostAsync<string>(request);
            }
            catch (Exception)
            {
                return null;
            }
        }
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
