using System;
using Newtonsoft.Json;

namespace CoreLib.Utils
{
    public static class JSONUtils
    {
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T FromJson<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
