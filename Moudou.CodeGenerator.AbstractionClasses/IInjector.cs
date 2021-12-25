using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moudou.CodeGenerator.AbstractionClasses
{
    /// <summary> An enter of Framework </summary>
    public interface IInjector
    {
        /// <summary>  </summary>
        /// <returns></returns>
        IInputValue GetInputValue();


        /// <summary>  </summary>
        /// <returns></returns>
        IInitValue GetInitValue();


        /// <summary>  </summary>
        /// <param name="data"></param>
        void Init(IInitValue data);


        /// <summary>  </summary>
        /// <param name="data"></param>
        /// <param name="templates"></param>
        void Inject(IInputValue data, IEnumerable<ITemplate> templates);
    }
}
