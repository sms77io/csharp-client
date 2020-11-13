using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Sms77.Api.Library {
    public class Util {
        public static string[] SplitByLine(string str) {
            return str.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string LcFirst(string str) {
            return str.Substring(0, 1).ToLower() + str.Substring(1);
        }

        public static string ToString(JToken token) {
            if (token.Type == JTokenType.String) {
                return token.ToObject<string>();
            }

            return token.Type == JTokenType.Boolean ? $"{Convert.ToInt32(token.ToObject<bool>())}" : token.ToString();
        }

        public static IDictionary<string, object> ToDictionary(object @params, string exclude = null) {
            var dict = (IDictionary<string, object>) new ExpandoObject();

            foreach (var property in @params.GetType().GetProperties()) {
                var value = property.GetValue(@params);

                if (exclude != property.Name && null != value) {
                    dict.Add(property.Name, value);
                }
            }

            return dict;
        }

        public static bool IsValidDate(string date, string format) {
            return DateTime.TryParseExact(
                date,
                format,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _);
        }

        public static string ToTitleCase(string str) {
            return str.Substring(0, 1) + str.Substring(1).ToLower();
        }

        public static string ToJson(object paras) {
            return JsonConvert.SerializeObject(paras, Formatting.None, new JsonSerializerSettings {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        public static async Task<T> CallDynamicMethod<T>(object cls, string name, object?[] paras) {
            var type = cls.GetType();
            var method = type.GetMethod(name);
            return await (Task<T>) method!.Invoke(cls, paras)!;
        }

        public static T ToObject<T>(string json) {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static IEnumerable<T> GetEnumValues<T>() {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static bool IsValidDateTime(string date, string format) {
            return DateTime.TryParseExact(date, format, null, DateTimeStyles.None, out _);
        }
    }
}