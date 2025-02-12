using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shaucky.Kalan.File
{
    internal class HttpFileLoader : IFileRequest
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<Stream> GetFileStreamAsync(string path)
        {
            HttpResponseMessage msg = await _httpClient.GetAsync(path);
            try
            {
                msg.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                msg.Dispose();
                throw e;
            }
            return await msg.Content.ReadAsStreamAsync();
        }
    }
}
