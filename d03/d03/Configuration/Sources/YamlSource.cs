using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace d03.Sources
{
    internal class YamlSource : IConfigurationSource
    {
        private string filePath;

        public YamlSource(string filePath)
        {
            this.filePath = filePath;
        }

        public Dictionary<string, object> LoadParameters()
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            string yamlContent = File.ReadAllText(filePath);
            var parameters = deserializer.Deserialize<Dictionary<string, object>>(yamlContent);
            return parameters;
        }
    }
}
