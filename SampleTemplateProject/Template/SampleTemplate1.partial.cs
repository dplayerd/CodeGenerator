using Moudou.CodeGenerator.AbstractionClasses;
using SampleTemplateProject.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleTemplateProject.Template
{
    public partial class SampleTemplate1 : ITemplate
    {
        public IInjector GetInjector()
        {
            return new DBInjector();
        }
    }
}
