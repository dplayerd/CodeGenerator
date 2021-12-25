using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moudou.CodeGenerator.AbstractionClasses
{
    /// <summary> Called before every template start. </summary>
    public interface IInputValue
    {
        /// <summary> Author </summary>
        string Author { get; set; }

        /// <summary> Called before every template start. </summary>
        /// <param name="sourceText"> template value text in config </param>
        void SetValue(string sourceText);
    }
}
