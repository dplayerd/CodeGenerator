using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            TemplateFramework.Global.init();
            TemplateFramework.Global.execute();


            Console.WriteLine("Execute completed. Please press ENTER.");
            Console.ReadLine();
        }
    }
}
