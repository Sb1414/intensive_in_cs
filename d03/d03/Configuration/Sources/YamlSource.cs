using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var parameters = new Dictionary<string, object>();

            using (var reader = new StreamReader(filePath))
            {
                string line;
                string currentKey = null;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Trim().StartsWith("#"))
                    {
                        // Пропускаем комментарии
                        continue;
                    }

                    if (line.Contains(":"))
                    {
                        var parts = line.Split(":");
                        if (parts.Length == 2)
                        {
                            currentKey = parts[0].Trim();
                            var value = parts[1].Trim();
                            parameters[currentKey] = value;
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(currentKey))
                    {
                        // Продолжаем добавлять значения для предыдущего ключа
                        parameters[currentKey] += line.Trim();
                    }
                }
            }

            return parameters;
        }
    }
}
