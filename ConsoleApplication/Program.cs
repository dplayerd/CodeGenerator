using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;
using System.IO;
using TemplateFramework;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileContents = Program.GetFileContent(args);
            var configs = Program.ParseConfig(fileContents);


            // check config file exist
            if (!configs.Any())
            {
                Console.WriteLine("No config readed. Execute without result.");
                return;
            }


            // init template framework 
            TemplateFramework.Global.Init(configs);
            TemplateFramework.Global.Execute();


            Console.WriteLine("Execute completed. Please press ENTER.");
        }


        private static IEnumerable<string> GetFileContent(IEnumerable<string> args)
        {
            // get config-file paths
            IEnumerable<string> paths = PathHelper.GetConfigPaths(args);
            

            foreach (string path in paths)
            {
                string configText = File.ReadAllText(path);
                yield return configText;
            }
        }


        private static IEnumerable<FileSettingText> ParseConfig(IEnumerable<string> configContents)
        {
            foreach(string configTxt in configContents)
            {
                FileSettingText result = null;


                try
                {
                    result = JsonConvert.DeserializeObject<FileSettingText>(configTxt);
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Parse config file error: ");
                    Console.WriteLine(ex.ToString());
                }


                if(result != null)
                    yield return result;
            }
        }
    }
}
