using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moudou.TemplateBase
{
    public interface iTemplate
    {
        iInjector getInjector();


        string TransformText();
    }
}
