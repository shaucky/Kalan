using Shaucky.Kalan.Format;
using Shaucky.Kalan.Modle;
using System;
using System.Threading.Tasks;

namespace Shaucky.Kalan
{
    /// <summary>
    /// KalanCore作为Kalan的入口类，通常通过KalanCore的Instance访问Kalan的功能。
    /// </summary>
    public class KalanCore
    {
        private static KalanCore _instance;
        /// <summary>
        /// 访问KalanCore的单例实例对象。
        /// </summary>
        public static KalanCore Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new KalanCore();
                }
                return _instance;
            }
        }
        /// <summary>
        /// 返回版本文件数据。
        /// </summary>
        public KalanVersion Version { get; internal set; }

        public static async Task Main()
        {
            await Instance.LoadVersionFile();
        }
        public KalanCore()
        {
            if (_instance != null)
            {
                throw (new NotSupportedException());
            }
        }
        /// <summary>
        /// 启动版本文件的加载，加载完毕后将进行比对。如果本地无版本文件或版本文件版本号与服务器端版本号不一致，则保存服务器端版本文件。
        /// </summary>
        /// <returns></returns>
        public async Task LoadVersionFile()
        {
            await FileManager.Instance.LoadVersionFile();
        }
    }
}
