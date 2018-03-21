using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moudou.TemplateBase
{
    /// <summary> An enter of Framework </summary>
    public interface iInjector
    {
        /// <summary>  </summary>
        /// <returns></returns>
        iInputValue getInputValue();


        /// <summary>  </summary>
        /// <returns></returns>
        iInitValue getInitValue();


        /// <summary>  </summary>
        /// <param name="data"></param>
        void init(iInitValue data);


        /// <summary>  </summary>
        /// <param name="data"></param>
        /// <param name="templates"></param>
        void inject(iInputValue data, IEnumerable<iTemplate> templates);
    }
}
