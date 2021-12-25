using Moudou.CodeGenerator.AbstractionClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleTemplateProject.Framework
{
    public class DBInputValue : IInputValue
    {
        public string Author { get; set; }


        public void SetValue(string SourceText)
        {
            this.Author = SourceText;
        }
    }
}
