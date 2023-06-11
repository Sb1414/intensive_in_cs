using System;
using System.Collections.Generic;
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
            string json = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<Dictionary<string, object>>(json, options);
        }
    }
}
