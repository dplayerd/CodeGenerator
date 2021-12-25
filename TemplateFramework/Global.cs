using Moudou.CodeGenerator.AbstractionClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TemplateFramework
{
    public class Global
    {
        static void readTemplates()
        {

        }

        private const string ConfigDirectory = "Configs";
        private const string ExportDirectory = "Results";


        #region "config"
        //public static void setConfig(string ConfigText)
        //{
 
        //}


        //static IEnumerable<string> loadConfigFile()
        //{
        //    yield return "";
        //}


        //static IEnumerable<FileSettingText> readConfig(IEnumerable<string> ConfigContent)
        //{
        //    var setting = new FileSettingText()
        //    {
        //        Name = "Sample",

        //        SaveTo = "D:\\GoGoGo\\Template\\",

        //        SaveType = SaveType.SourceText,

        //        InjectSettings = new List<InjectSettingText>()
        //        {
        //            new InjectSettingText() 
        //            {
        //                Assembly = @"F:\Projects\CodeGenerator\ConsoleApplication1\bin\Debug\SampleTemplateProject.dll",
        //                Templates = 
        //                    "[ SampleTemplateProject.Template.SampleTemplate1, " + 
        //                    "SampleTemplateProject.Template.SampleTemplate2 ]",
        //                InputValue = "{ Author: \"Moudou\" }",
        //                InitValue = "{ connectionstring: \"thisisaconnectionstring;gogogogogo;\" }",
        //                Injector = "SampleTemplateProject.Framework.DBInjector"
        //            }
        //        }
        //    };


        //    var retList = new List<FileSettingText>() { setting };
        //    return retList;
        //}
        #endregion


        #region "Log"
        private static void LogError(string msg)
        { }
        #endregion


        #region "reflection"
        static void reflect(IEnumerable<FileSettingText> configs)
        {
            Assembly[] AssembliesLoaded = AppDomain.CurrentDomain.GetAssemblies();

    
            foreach (FileSettingText config in configs)
            {
                foreach (InjectSettingText injSetting in config.InjectSettings)
                {
                    string path = injSetting.Assembly;
                    var assemblies = new Assembly[] { Assembly.LoadFile(path) };


                    IInjector injectObj = Global.getTypedObject<IInjector>(assemblies, injSetting.Injector);

                    if (injectObj == null)
                    {
                        Global.LogError("");
                        continue;
                    }



                    IEnumerable<string> aaa = injSetting.Templates.Trim('[', ']').Split(',').Select(obj => obj.Trim());
                    List<ITemplate> templateList = new List<ITemplate>();


                    foreach (string templates in aaa)
                    {
                        ITemplate template = Global.getTypedObject<ITemplate>(assemblies, templates);

                        if (template == null)
                        {
                            Global.LogError("");
                            continue;
                        }

                        templateList.Add(template);
                    }


                    IInitValue initValue = injectObj.GetInitValue();
                    IInputValue inputValue = injectObj.GetInputValue();

                    initValue.SetValue(injSetting.InitValue);
                    inputValue.SetValue(injSetting.InputValue);



                    Global.dicTemplates.Add(config.Name, templateList);
                    Global.dicInput.Add(config.Name, inputValue);
                    Global.dicInit.Add(config.Name, initValue);
                    Global.dicInject.Add(config.Name, injectObj);
                }


                Global.dicSetting.Add(config.Name, config);
            }
        }


        private static T getTypedObject<T>(Assembly[] AssembliesLoaded, string TypeName)
        {
            Type MyType =
                AssembliesLoaded
                    .Select(assembly => assembly.GetType(TypeName))
                    .Where(type => type != null)
                    .FirstOrDefault();


            if (!typeof(T).IsAssignableFrom(MyType))
                return default(T);


            object obj = Activator.CreateInstance(MyType);

            if (obj == null)
                return default(T);


            return (T)obj;
        }
        #endregion


        #region "Framework"
        static Dictionary<string, List<ITemplate>> dicTemplates = new Dictionary<string, List<ITemplate>>();
        static Dictionary<string, IInputValue> dicInput = new Dictionary<string, IInputValue>();
        static Dictionary<string, IInitValue> dicInit = new Dictionary<string, IInitValue>();
        static Dictionary<string, IInjector> dicInject = new Dictionary<string, IInjector>();
        static Dictionary<string, FileSettingText> dicSetting = new Dictionary<string, FileSettingText>();


        //public static void init()
        //{
        //    var configContents = Global.loadConfigFile();
        //    var list = Global.readConfig(configContents);

        //    Global.init(list);
        //}



        //public static void init(IEnumerable<string> JsonConfigContent)
        //{
        //    var configs = Global.readConfig(JsonConfigContent);

        //    Global.init(configs);
        //}


        public static void Init(IEnumerable<FileSettingText> configs)
        {
            Global.reflect(configs);
        }



        public static void Execute()
        {
            foreach (string tmpName in dicInject.Keys)
            {
                IInjector owner = dicInject[tmpName];

                List<ITemplate> tmpList = dicTemplates[tmpName];
                IInputValue inputVO = dicInput[tmpName];
                IInitValue initVO = dicInit[tmpName];

                FileSettingText setting = dicSetting[tmpName];


                owner.Init(initVO);
                owner.Inject(inputVO, tmpList);


                foreach (ITemplate iTemp in tmpList)
                {
                    string FileName = iTemp.GetType().ToString();

                    string writeContent = iTemp.TransformText();

                    string directoryPath = setting.SaveTo;
                    string filePath = directoryPath + FileName;

                    if (!Directory.Exists(directoryPath))
                        Directory.CreateDirectory(directoryPath);

                    File.WriteAllText(filePath, writeContent);
                }
            }
        }
        #endregion
    }
}
