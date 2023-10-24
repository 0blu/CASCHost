using System;
using CASCEdit;
using System.IO;

namespace CASCExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            var basePath = args[0];
            if (!File.Exists(Path.Combine(basePath, ".build.info")))
            {
                Console.WriteLine("Error: Missing .build.info.");
                System.Threading.Thread.Sleep(1500);
                Environment.Exit(0);
            }

            var settings = new CASSettings()
            {
                BasePath = basePath,
                BuildInfoPath = basePath,
                Basic = true,
                Product = "wow_classic", // Product = "wow_classic_era",
            };
            CASContainer.Open(settings);

            if (!CASContainer.ExtractSystemFiles(Path.Combine(basePath, "_SystemFiles")))
            {
                Console.WriteLine("Please ensure that you have a fully downloaded client.");
                System.Threading.Thread.Sleep(3000);
            }

            CASContainer.Close();
        }
    }
}
