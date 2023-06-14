using d03.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d03.Configuration
{
    internal class Configuration
    {
        private readonly List<IConfigurationSource> sources;

        public Dictionary<string, object> Params { get; private set; }

        public Configuration(params IConfigurationSource[] sources)
        {
            this.sources = new List<IConfigurationSource>(sources);
            LoadConfiguration();
        }

        private void LoadConfiguration()
        {
            Params = new Dictionary<string, object>();

            // Сортируем источники конфигурации по приоритету в порядке убывания
            sources.Sort((s1, s2) => s2.Priority.CompareTo(s1.Priority));

            foreach (var source in sources)
            {
                var parameters = source.LoadParameters();

                if (parameters != null)
                {
                    // Объединяем параметры с учетом приоритета
                    foreach (var parameter in parameters)
                    {
                        if (!Params.ContainsKey(parameter.Key))
                        {
                            Params[parameter.Key] = parameter.Value;
                        }
                    }
                }
            }
        }

        public string GetParameter(string key)
        {
            if (Params.ContainsKey(key))
            {
                return Params[key]?.ToString();
            }
            return null;
        }
    }


}
