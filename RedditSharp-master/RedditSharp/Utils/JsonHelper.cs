using System.Collections;
using Newtonsoft.Json;
using ServiceStack.Text;

namespace RedditSharp.Utils
{
    public class JsonHelper
    {
        private static JsonStringSerializer JsonSerializer => new JsonStringSerializer();
        private static JsvStringSerializer JsvSerializer => new JsvStringSerializer();
        public static string Serialize<T>(T t)
        {
            return JsonSerializer.SerializeToString(t);
        }

        public static string SerializeJsv<T>(T t) where T : IEnumerable
        {
            return JsvSerializer.SerializeToString(t);
        }

        public static T Deserialize<T>(string s)
        {
            return JsonSerializer.DeserializeFromString<T>(s);
        }

        public static T DerializeJsv<T>(string s) where T : IEnumerable
        {
            return JsvSerializer.DeserializeFromString<T>(s);
        }


    }
}