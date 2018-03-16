using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemplateFramework
{
    internal class FileSettingText
    {
        internal string Name { get; set; }
        internal string SaveTo { get; set; }

        internal SaveType SaveType { get; set; }

        internal List<InjectSettingText> InjectSettings { get; set; }
    }
}