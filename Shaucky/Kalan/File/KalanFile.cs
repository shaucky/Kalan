using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Shaucky.Kalan.File
{
    /// <summary>
    /// KalanFile用于管理文件的加载、读写。
    /// </summary>
    public class KalanFile
    {
        private string _path;
        private IFileRequest _loader;
        /// <summary>
        /// 文件加载完毕时执行onComplete委托。
        /// </summary>
        public Action<object, Stream> onComplete;

        public KalanFile(string path)
        {
            _path = path;
        }
        /// <summary>
        /// 启动对指定路径文件的加载。
        /// </summary>
        /// <returns>加载完毕后，返回加载流。</returns>
        public async Task<Stream> Load()
        {
            Stream stm;
            if (Regex.Matches(_path, @"(?i)^http(s)?://").Count != 0)
            {
                _loader = new HttpFileLoader();
            }
            else
            {
                _loader = new LocalFileLoader();
            }
            stm = await _loader.GetFileStreamAsync(_path);
            onComplete?.Invoke(this, stm);
            return stm;
        }
    }
}
