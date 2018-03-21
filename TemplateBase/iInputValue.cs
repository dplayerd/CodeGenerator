using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moudou.TemplateBase
{
    /// <summary> Called before every template start. </summary>
    public interface iInputValue
    {
        /// <summary> Author </summary>
        string Author { get; set; }

        /// <summary> Called before every template start. </summary>
        /// <param name="SourceText"> template value text in config </param>
        void setValue(string SourceText);
    }
}
