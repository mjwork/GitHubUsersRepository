using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GitHubUsersRepository.Helpers
{
    public static class ExternalApiHelper
    {
        /// <summary>
        /// Calls an API based on the provided URI.
        /// </summary>
        /// <param name="uri">The URI to call.</param>
        /// <returns>A <see cref="string"/> which is the content of the API response.</returns>
        public static async Task<string> CallExternalApi(string uri)
        {
            string repsonseBody = string.Empty;

            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(uri)
            };

            request.Headers.Add("User-Agent", "User-Agent-Here");

            using (HttpResponseMessage response = await client.SendAsync(request))
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                response.EnsureSuccessStatusCode();
                repsonseBody = await response.Content.ReadAsStringAsync();
            }

            return repsonseBody;
        }
    }
}