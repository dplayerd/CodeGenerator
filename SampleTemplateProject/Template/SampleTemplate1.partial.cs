using Moudou.TemplateBase;
using SampleTemplateProject.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleTemplateProject.Template
{
    public partial class SampleTemplate1 : iTemplate
    {
        public iInjector getInjector()
        {
            return new DBInjector();
        }
    }
}
