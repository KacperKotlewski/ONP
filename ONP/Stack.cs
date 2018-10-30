using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONP
{
    public class Stack
    {
        private List<Symbol> symbolArray = new List<Symbol>();

        public string PushAndReturnSymbols(char symbol)
        {
            string result = "";

            Symbol newSymbol = Symbol.Fab(symbol);

            if (newSymbol.GetPriority() != 5)
            {
                while (!_NewPriorityIsGreater(newSymbol.GetPriority()))
                {
                    char lastSymbol = _GetAndDeleteLast();
                    if (!(lastSymbol == '(' && symbol == ')' || lastSymbol == (char)(0) && symbol == ')'))
                    {
                        result += lastSymbol.ToString();
                    }
                    else break;
                }
                if(symbol != ')')
                {
                    symbolArray.Add(newSymbol);
                }
            }
            return result;
        }

        public string GetLast()
        {
            string str = "";
            foreach (Symbol symbol in symbolArray)
            {
                str+=symbol.Get().ToString();
            }
            return str;
        }

        public void PrintAll()
        {
            foreach (Symbol symbol in symbolArray)
            {
                Console.Write(symbol.Get());
            }
        }

        private char _GetAndDeleteLast()
        {
            int lastIndex = symbolArray.Count - 1;
            char symbol = (char)(0);
            if (lastIndex >= 0)
            {
                symbol = symbolArray[lastIndex].Get();
                symbolArray.RemoveAt(lastIndex);
            }
            return symbol;
        }

        private bool _NewPriorityIsGreater(byte priorityToCompare)
        {
            if (priorityToCompare == 1) //jeżeli to nawias zamykający
                return false;
            if (_GetLastPriority() < priorityToCompare) //jeżeli to inny znak > od ostatniego
                return true;
            else if(priorityToCompare == 0) return true; //jeżeli to nawias otwierający
            else return false;  //jeżeli to znak <= ostatniemu
        }

        private byte _GetLastPriority()
        {
            try
            {
                byte priority = symbolArray[symbolArray.Count - 1].GetPriority();
                return priority;
            }
            catch(Exception e)
            {
                return 0;
            }
        }
    }
}
