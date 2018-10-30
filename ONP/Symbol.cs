using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONP
{
    class Symbol
    {
        private char symbol;
        private byte priority;

        public Symbol(char symbol)
        {
            Set(symbol);
        }

        public static Symbol Fab(char symbol)
        {
            return new Symbol(symbol);
        }

        public void Set(char symbol)
        {
            if (_IsMathSymbol(symbol))
            {
                this.symbol = symbol;
                _SetPriorityOfSymbol(symbol);
            }
            else
            {
                this.symbol = (char)(0);
                _SetPriority( 5 );
            }
        }

        public char Get()
        {
            if (GetPriority() != 5)
                return this.symbol;
            else return (char)0;
        }

        public byte GetPriority()
        {
            return this.priority;
        }



        private bool _IsMathSymbol(char symbol)
        {
            switch (symbol)
            {
                case '(':
                case ')':
                case '+':
                case '-':
                case '*':
                case '/':
                case '^':
                    return true;

                default:
                    return false;
            }
        }

        private void _SetPriority(byte priority)
        {
            this.priority = priority;
        }

        private void _SetPriorityOfSymbol(char symbol)
        {
            switch (symbol)
            {
                case '(':
                    _SetPriority( 0 );
                    break;

                case ')':
                    _SetPriority( 1 );
                    break;

                case '+':
                case '-':
                    _SetPriority( 2 );
                    break;

                case '*':
                case '/':
                    _SetPriority( 3 );
                    break;

                case '^':
                    _SetPriority( 4 );
                    break;

                default:
                    _SetPriority( 5 );
                    break;
            }
        }
    }
}
