using System.IO;
using System.Threading.Tasks;

namespace Shaucky.Kalan.File
{
    internal class LocalFileLoader : IFileRequest
    {
        public Task<Stream> GetFileStreamAsync(string path)
        {
            return Task.FromResult<Stream>(System.IO.File.OpenRead(path));
        }
    }
}
