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
            throw new NotImplementedException("YAML source is not implemented yet.");
        }
    }
}
