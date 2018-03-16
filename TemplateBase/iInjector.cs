using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moudou.TemplateBase
{
    public interface iInjector
    {

        iInputValue getInputValue();


        iInitValue getInitValue();


        void init(iInitValue data);


        void inject(iInputValue data, IEnumerable<iTemplate> templates);
    }
}
