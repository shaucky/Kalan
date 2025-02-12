using Newtonsoft.Json;
using Shaucky.Kalan.File;
using Shaucky.Kalan.Format;
using System;
using System.IO;
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
        public KalanVersion Version { get; private set; }

        public static async Task Main()
        {
            await Instance.LoadVersionFile();
        }
        /// <summary>
        /// 启动版本文件的加载，加载完毕后将进行比对。如果本地无版本文件或版本文件版本号与服务器端版本号不一致，则保存服务器端版本文件。
        /// </summary>
        /// <returns></returns>
        public async Task LoadVersionFile()
        {
            KalanFile cltVerFile = new KalanFile(AppDomain.CurrentDomain.BaseDirectory + "version/version.json");
            KalanFile svrVerFile = new KalanFile("https://seerh5.61.com/version/version.json");
            KalanVersion cltVer = null, svrVer = null;
            byte[] cltVerBytes, svrVerBytes;
            cltVerFile.onComplete += (object sender, Stream stream) =>
            {
                cltVerBytes = new byte[stream.Length];
                stream.ReadAsync(cltVerBytes, 0, (int)stream.Length);
                cltVer = JsonConvert.DeserializeObject<KalanVersion>(cltVerBytes.ToString());
                VersionCompare(cltVer, svrVer);
            };
            svrVerFile.onComplete += (object sender, Stream stream) =>
            {
                svrVerBytes = new byte[stream.Length];
                stream.ReadAsync(svrVerBytes, 0, (int)stream.Length);
                svrVer = JsonConvert.DeserializeObject<KalanVersion>(svrVerBytes.ToString());
                VersionCompare(cltVer, svrVer);
            };
            try
            {
                await cltVerFile.Load();
            }
            catch (Exception ex)
            {
                cltVer = new KalanVersion();
                VersionCompare(cltVer, svrVer);
            }
            try
            {
                await svrVerFile.Load();
            }
            catch (Exception ex)
            {
                svrVer = new KalanVersion();
                VersionCompare(cltVer, svrVer);
            }
        }
        private void VersionCompare(KalanVersion ClientVersion, KalanVersion ServerVersion)
        {
            if (ClientVersion == null || ServerVersion == null)
            {
                return;
            }
            if (ClientVersion.Version == 0 || (ServerVersion.Version != 0 && ClientVersion.Version != ServerVersion.Version))
            {
                Version = ServerVersion;
                Console.WriteLine("使用服务器端版本。");
                //TODO: 将服务器版本写入本地。
            }
            else
            {
                Version = ClientVersion;
                Console.WriteLine("使用客户端版本。");
            }
        }
    }
}
