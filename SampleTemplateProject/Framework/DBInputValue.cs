using Moudou.TemplateBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleTemplateProject.Framework
{
    public class DBInputValue : iInputValue
    {
        public string Author { get; set; }


        public void setValue(string SourceText)
        {
            this.Author = SourceText;
        }
    }
}
