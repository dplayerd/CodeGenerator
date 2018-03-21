using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemplateFramework
{
    /// <summary>  </summary>
    public class FileSettingText
    {
        public string Name { get; set; }

        public string SaveTo { get; set; }

        public SaveType SaveType { get; set; }

        public List<InjectSettingText> InjectSettings { get; set; }
    }
}