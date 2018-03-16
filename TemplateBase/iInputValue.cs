using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moudou.TemplateBase
{
    public interface iInputValue
    {
        string Author { get; set; }

        void setValue(string SourceText);
    }
}
