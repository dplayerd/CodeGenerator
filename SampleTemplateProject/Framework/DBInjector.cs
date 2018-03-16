using Moudou.TemplateBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleTemplateProject.Framework
{
    public class DBInjector : iInjector
    {
        public iInputValue getInputValue()
        {
            return new DBInputValue();
        }

        public iInitValue getInitValue()
        {
            return new DBInitValue();
        }


        public void init(iInitValue data)
        {
        }

        public void inject(iInputValue data, IEnumerable<iTemplate> templates)
        {
            foreach (iTemplate tmp in templates)
            {
                if (tmp is SampleTemplateProject.Template.SampleTemplate1)
                { 
                }
            }
        }
    }
}
