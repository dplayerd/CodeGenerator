using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moudou.TemplateBase
{
    /// <summary> Called at Init step </summary>
    public interface iInitValue
    {
        /// <summary> Called at Init step </summary>
        /// <param name="SourceText"> init text in config </param>
        void setValue(string SourceText);
    }
}
