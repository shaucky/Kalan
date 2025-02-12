using System;

namespace Shaucky.Kalan.Settings
{
    /// <summary>
    /// KalanConfig是Kalan的数据配置类。一些常用的数据可能需要通过该类设置，例如文件存储路径。
    /// </summary>
    public static class KalanConfig
    {
        private static string _seerServerDomain = "https://seerh5.61.com/";
        private static string _localBaseDirectory = null;
        /// <summary>
        /// 获取《赛尔号》HTML5端资源服务器域名或公网地址（默认值为“https://seerh5.61.com/”）。
        /// </summary>
        public static string SeerServerDomain { get { return _seerServerDomain; } }
        /// <summary>
        /// 获取应用程序在本地存储文件的目录（默认值为.NET的AppDomain.CurrentDomain.BaseDirectory）。
        /// </summary>
        public static string LocalBaseDirectory {
            get
            {
                if (_localBaseDirectory == null)
                {
                    _localBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                }
                return _localBaseDirectory;
            }
        }

        /// <summary>
        /// 设置《赛尔号》HTML5端资源服务器域名或公网地址（通常不应该设置该项，除非自建了服务器）。
        /// </summary>
        /// <param name="domain">需要设置的新地址</param>
        public static void SetSeerServerDomain(string domain)
        {
            _seerServerDomain = domain;
        }
        /// <summary>
        /// 设置应用程序在本地存储文件的目录。
        /// </summary>
        /// <param name="path"></param>
        public static void SetLocalBaseDirectory(string path)
        {
            _localBaseDirectory = path;
        }
    }
}
