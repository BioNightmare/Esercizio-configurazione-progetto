using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace Configurazione_progetto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            Settings settings = config.GetRequiredSection("settings").Get<Settings>();
            WriteOnFile(settings.path, @"test.txt");
        }
        static void WriteOnFile(string path, string fileName)
        {
            List<string> lista = new()
            {
                "Test 1",
                "Test 2",
                "Test 3"
            };
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            File.AppendAllLines(Path.Combine(path, fileName), lista);
        }
    }

    public class Logger
    {
        public string Path;

        public Logger(string path)
        {
            Path = path;
        }
    }
    public class Settings
    {
        public string path { get; set; }
    }
}
