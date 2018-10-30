using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONP_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ONP stack test passed: "+ONP.Test.Stack());

            Console.ReadLine();
        }
    }
}
