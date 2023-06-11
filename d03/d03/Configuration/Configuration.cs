﻿using d03.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d03.Configuration
{
    internal class Configuration
    {
        private Dictionary<string, string> Params;

        public Configuration(IConfigurationSource source)
        {
            Params = source.LoadParameters();
        }

        public string GetParameter(string key)
        {
            if (Params.ContainsKey(key))
            {
                return Params[key];
            }
            return null;
        }
    }
}
