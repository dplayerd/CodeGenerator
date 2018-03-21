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
            var fileContents = Program.getFileContent(args);
            var configs = Program.parseConfig(fileContents);


            // check config file exist
            if (!configs.Any())
            {
                Console.WriteLine("No config readed. Execute without result.");
                return;
            }


            // init template framework 
            TemplateFramework.Global.init(configs);
            TemplateFramework.Global.execute();


            Console.WriteLine("Execute completed. Please press ENTER.");
        }


        private static IEnumerable<string> getFileContent(IEnumerable<string> args)
        {
            // get config-file paths
            IEnumerable<string> paths = PathHelper.getConfigPaths(args);
            

            foreach (string path in paths)
            {
                string configText = File.ReadAllText(path);
                yield return configText;
            }
        }


        private static IEnumerable<FileSettingText> parseConfig(IEnumerable<string> configContents)
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
