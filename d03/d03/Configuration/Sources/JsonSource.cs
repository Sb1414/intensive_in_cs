using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace d03.Sources
{
    internal class JsonSource : IConfigurationSource
    {
        private string filePath;
        public JsonSource(string filePath)
        {
            this.filePath = filePath;
        }

        public Dictionary<string, object> LoadParameters()
        {
            try
            {
                string json = File.ReadAllText(filePath);
                return ParseJson(json);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid data. Check your input and try again.");
                return new Dictionary<string, object>(); // Возвращаем пустой словарь в случае ошибки
            }
        }

        private Dictionary<string, object> ParseJson(string json)
        {
            var parameters = new Dictionary<string, object>();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReadCommentHandling = JsonCommentHandling.Skip
            };

            using (JsonDocument document = JsonDocument.Parse(json))
            {
                foreach (JsonProperty property in document.RootElement.EnumerateObject())
                {
                    string key = property.Name;
                    object value = GetValue(property.Value);

                    parameters[key] = value;
                }
            }

            return parameters;
        }

        private object GetValue(JsonElement element)
        {
            switch (element.ValueKind)
            {
                case JsonValueKind.String:
                    return element.GetString();
                case JsonValueKind.Number:
                    if (element.TryGetInt32(out int intValue))
                        return intValue;
                    if (element.TryGetDouble(out double doubleValue))
                        return doubleValue;
                    if (element.TryGetDecimal(out decimal decimalValue))
                        return decimalValue;
                    return element.GetRawText();
                case JsonValueKind.True:
                    return true;
                case JsonValueKind.False:
                    return false;
                default:
                    return element.GetRawText();
            }
        }
    }

}
