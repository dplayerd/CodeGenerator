using Moudou.CodeGenerator.AbstractionClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleTemplateProject.Framework
{
    public class DBInjector : IInjector
    {
        public IInputValue GetInputValue()
        {
            return new DBInputValue();
        }

        public IInitValue GetInitValue()
        {
            return new DBInitValue();
        }


        public void Init(IInitValue data)
        {
        }

        public void Inject(IInputValue data, IEnumerable<ITemplate> templates)
        {
            foreach (ITemplate tmp in templates)
            {
                if (tmp is SampleTemplateProject.Template.SampleTemplate1)
                { 
                }
            }
        }
    }
}
