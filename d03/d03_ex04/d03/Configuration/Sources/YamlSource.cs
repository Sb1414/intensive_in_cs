﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d03.Sources
{
    internal class YamlSource : IConfigurationSource
    {
        private string filePath;
        private int priority;

        public int Priority => priority;

        public YamlSource(string filePath, int priority)
        {
            this.filePath = filePath;
            this.priority = priority;
        }

        public Dictionary<string, object>? LoadParameters()
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine("Invalid data. Check your input and try again.");
                return new Dictionary<string, object>(); // Возвращаем пустой словарь в случае ошибки
            }
        }
    }
}
