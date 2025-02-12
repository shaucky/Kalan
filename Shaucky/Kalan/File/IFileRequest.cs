using System.IO;
using System.Threading.Tasks;

namespace Shaucky.Kalan.File
{
    internal interface IFileRequest
    {
        Task<Stream> GetFileStreamAsync(string path);
    }
}
