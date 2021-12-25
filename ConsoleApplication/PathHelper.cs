using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApplication
{
    internal class PathHelper
    {
        internal static IEnumerable<string> GetConfigPaths(IEnumerable<string> args)
        {
            IEnumerable<string> paths = PathHelper.getInputFiles(args);

            if (!paths.Any())
                paths = PathHelper.getDefaultFiles();

            return paths;
        }

        private static IEnumerable<string> getInputFiles(IEnumerable<string> args)
        {
            bool startRecord = false;

            foreach (string arg in args)
            {
                var trimedArg = arg.Trim();

                if (string.IsNullOrEmpty(trimedArg))
                    continue;


                if (string.Compare(arg, "-p", true) == 0)
                    startRecord = true;


                if (startRecord)
                    yield return arg;
            }
        }


        private static IEnumerable<string> getDefaultFiles()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string newPath = Path.Combine(path, "Config");


            if (!Directory.Exists(newPath))
                return new string[] { };


            string[] configFilePaths = Directory.GetFiles(newPath, "*.config");
            string[] jsonFilePaths = Directory.GetFiles(newPath, "*.json");
            
            return configFilePaths.Union(jsonFilePaths);
        }
    }
}
