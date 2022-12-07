using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Text;
using System.Collections;

namespace WebAPI.Common.Extensions
{
    [Serializable()]
    public static class SerializerDeserializerExtensions
    {
        public static byte[] SerializeToByteArray(this object obj)
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj));
        }

        public static object? DeserializeToObject<T>(this byte[] value)
        {
            return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(value));
        }
    }
}
