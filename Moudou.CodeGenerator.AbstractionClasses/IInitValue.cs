using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moudou.CodeGenerator.AbstractionClasses
{
    /// <summary> Called at Init step </summary>
    public interface IInitValue
    {
        /// <summary> Called at Init step </summary>
        /// <param name="sourceText"> init text in config </param>
        void SetValue(string sourceText);
    }
}
