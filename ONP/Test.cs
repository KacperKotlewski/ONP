using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONP
{
    class Test
    {
        public static bool Stack()
        {
            char[] symbols = new char[] { '(', '+', '*', '^', ')', '-', '*', '+', '(', '*', ')' };
            Stack stack = new Stack();

            string testingString = "";

            foreach (char sym in symbols)
            {
                testingString += stack.PushAndReturnSymbols(sym);
            }
            testingString += stack.GetLast();
            return (testingString == "^*+*-*+");
        }
    }
}
