using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moudou.CodeGenerator.AbstractionClasses
{
    public interface ITemplate
    {
        IInjector GetInjector();


        string TransformText();
    }
}
