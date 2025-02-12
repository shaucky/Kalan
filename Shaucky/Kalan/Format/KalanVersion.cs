using Newtonsoft.Json;
using System.Collections.Generic;

namespace Shaucky.Kalan.Format
{
    /// <summary>
    /// KalanVersion是Kalan的版本文件数据结构类。
    /// </summary>
    public class KalanVersion
    {
        /// <summary>
        /// 版本文件版本号。
        /// </summary>
        [JsonProperty("version")]
        public long Version { get; set; }
        /// <summary>
        /// 版本文件文件列表。
        /// </summary>
        [JsonProperty("files")]
        public KalanVersionFiles Files { get; set; }
    }
    public class KalanVersionFiles
    {
        /// <summary>
        /// 版本文件资源文件列表。
        /// </summary>
        [JsonProperty("resource")]
        public KalanVersionFilesResource Resource { get; set; }
    }
    public class KalanVersionFilesResource
    {
        /// <summary>
        /// 版本文件资源文件资产文件列表。
        /// </summary>
        [JsonProperty("assets")]
        public KalanVersionFilesResourceAssets Assets { get; set; }
        /// <summary>
        /// 版本文件资源文件配置文件列表。
        /// </summary>
        [JsonProperty("config")]
        public KalanVersionFilesResourceConfig Config { get; set; }
    }
    public class KalanVersionFilesResourceConfig
    {
        [JsonProperty("json")]
        public Dictionary<string, string> Json { get; set; }
        [JsonProperty("xml")]
        public Dictionary<string, string> Xml { get; set; }
    }
    public class KalanVersionFilesResourceAssets
    {
        /// <summary>
        /// 版本文件资源文件资产文件战斗资源列表。
        /// </summary>
        [JsonProperty("fightResource")]
        public KalanVersionFilesResourceAssetsFightResource FightResource { get; set; }
        /// <summary>
        /// 版本文件资源文件资产文件精灵文件列表。
        /// </summary>
        [JsonProperty("pet")]
        public KalanVersionFilesResourceAssetsPet Pet { get; set; }
    }
    public class KalanVersionFilesResourceAssetsFightResource
    {
        [JsonProperty("pet")]
        public Dictionary<string, string> Pet { get; set; }
    }
    public class KalanVersionFilesResourceAssetsPet
    {
        [JsonProperty("half")]
        public Dictionary<string, string> Half {  get; set; }
        [JsonProperty("head")]
        public Dictionary<string, string> Head { get; set; }
    }
}
