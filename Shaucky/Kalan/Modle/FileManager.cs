using Newtonsoft.Json;
using Shaucky.Kalan.File;
using Shaucky.Kalan.Format;
using Shaucky.Kalan.Settings;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Shaucky.Kalan.Modle
{
    internal class FileManager
    {
        private static FileManager _instance;
        public static FileManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FileManager();
                }
                return _instance;
            }
        }

        public FileManager()
        {
            if (_instance != null)
            {
                throw (new NotSupportedException());
            }
        }
        public async Task LoadVersionFile()
        {
            KalanFile cltVerFile = new KalanFile(Path.Combine(KalanConfig.LocalBaseDirectory, "version", "version.json"));
            KalanFile svrVerFile = new KalanFile(KalanConfig.SeerServerDomain + "/version/version.json");
            KalanVersion cltVer = null, svrVer = null;
            byte[] cltVerBytes, svrVerBytes;
            cltVerFile.onComplete += (object sender, Stream stream) =>
            {
                cltVerBytes = new byte[stream.Length];
                stream.ReadAsync(cltVerBytes, 0, (int)stream.Length);
                cltVer = JsonConvert.DeserializeObject<KalanVersion>(Encoding.UTF8.GetString(cltVerBytes));
                VersionCompare(cltVer, svrVer);
            };
            svrVerFile.onComplete += (object sender, Stream stream) =>
            {
                svrVerBytes = new byte[stream.Length];
                stream.ReadAsync(svrVerBytes, 0, (int)stream.Length);
                svrVer = JsonConvert.DeserializeObject<KalanVersion>(Encoding.UTF8.GetString(svrVerBytes));
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
            if (ClientVersion.Version != 0 || (ServerVersion.Version == 0 && ClientVersion.Version != ServerVersion.Version))
            {
                KalanCore.Instance.Version = ClientVersion;
                Console.WriteLine("使用客户端版本。");
            }
            else
            {
                KalanCore.Instance.Version = ServerVersion;
                Console.WriteLine("使用服务器端版本。");
                Console.WriteLine(KalanCore.Instance.Version);
                Console.WriteLine(KalanCore.Instance.Version.Version);
                Console.WriteLine(Combo.Combine(new string[] { "resource", "config", "json", "X_Team.json" }));
                //TODO: 将服务器版本写入本地。
            }
        }
    }
}
