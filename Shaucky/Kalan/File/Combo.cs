using Newtonsoft.Json;
using Shaucky.Kalan.Settings;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Shaucky.Kalan.File
{
    internal static class Combo
    {
        public static string Combine(string[] strings)
        {
            string uri = KalanConfig.SeerServerDomain;
            uri = GetPathFromJson(KalanCore.Instance.Version.Files, uri, strings);
            return uri;
        }
        private static string GetPathFromJson(object data, string path, string[] strings)
        {
            string[] nextStrings;
            Type type = data.GetType();
            if (type == typeof(Dictionary<string, string>))
            {
                if (((Dictionary<string, string>)data).ContainsKey(strings[0]))
                {
                    path = CombineUri(new string[] { path, ((Dictionary<string, string>)data)[strings[0]] });
                }
                else
                {
                    path = CombineUri(new string[] { path, strings[0] });
                }
                return path;
            }
            foreach (PropertyInfo property in type.GetProperties())
            {
                JsonPropertyAttribute jsonPpt = property.GetCustomAttribute<JsonPropertyAttribute>();
                if (jsonPpt != null && strings[0] == jsonPpt.PropertyName)
                {
                    if (strings.Length > 1)
                    {
                        nextStrings = new string[strings.Length - 1];
                        for (int i = 0; i < nextStrings.Length; i++)
                        {
                            nextStrings[i] = strings[i + 1];
                        }
                        path = CombineUri(new string[] { path, property.GetCustomAttribute<JsonPropertyAttribute>().PropertyName });
                        path = GetPathFromJson(property.GetValue(data), path, nextStrings);
                        return path;
                    }
                    else
                    {
                        path = CombineUri(new string[] { path, property.GetCustomAttribute<JsonPropertyAttribute>().PropertyName });
                        return path;
                    }
                }
            }
            return path;
        }
        private static string CombineUri(string[] strs)
        {
            string uri = "";
            for (int i = 0; i < strs.Length; i++)
            {
                uri += (i + 1 < strs.Length) ? (strs[i] + "/") : strs[i];
            }
            return uri;
        }
    }
}
