using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _7CalculateArithmeticalExpression
{
    class Scanner
    {
        static readonly string keywords =
            " ln sqrt pow ";
        static readonly string separator =
            "(),";
        static readonly string deistvie =
            "+-*/";
        private char ch;
        private int column;
        private string expression;

        public Scanner(string expression)
        {
            this.expression = expression;
            this.column = 0;
            ReadNextChar();
        }

        public void ReadNextChar()
        {
            if (column < expression.Length)
            {
                ch = expression[column];
            }
            else
            {
                ch = '@';
            }

            column++;
        }

        public Token Next()
        {
            //                    start: // za preska4ane na komentari
            
            while (true)
            {
                if (ch >= 'a' && ch <= 'z')
                {
                    StringBuilder s = new StringBuilder();

                    while (ch >= 'a' && ch <= 'z')
                    {
                        s.Append(ch);
                        ReadNextChar();
                    }

                    string id = s.ToString();

                    if (keywords.Contains(" " + id + " "))
                    {
                        return new Token(TupeToken.Function, id);
                    }

                    throw new ArgumentException("Inwalid expression!");

                }
                else if (ch >= '0' && ch <= '9' || ch == '-') // TODO: add negative numbers.!!!!
                {
                    StringBuilder s = new StringBuilder();

                    if (ch == '-')
                    {
                        s.Append(ch);
                        ReadNextChar();

                        if (ch == ' ')
                        {
                            return new Token(TupeToken.Operators, s.ToString());
                        }
                    }

                    while (ch >= '0' && ch <= '9')
                    {
                        s.Append(ch);
                        ReadNextChar();
                    }

                    if (ch=='.') 
                    {
                        s.Append(ch);
                        ReadNextChar();

                        while (ch>='0' && ch<='9') 
                        {
                            s.Append(ch);
                            ReadNextChar();
                        }

                        return new Token(TupeToken.Number, s.ToString());
                    }

                    return new Token(TupeToken.Number, s.ToString());

                }
                else if (separator.Contains(ch.ToString()))
                {
                    char ch1 = ch;
                    ReadNextChar();
                    return new Token(TupeToken.Serarator, ch1.ToString());
                }
                else if (deistvie.Contains(ch.ToString()))
                {
                    char ch1 = ch;
                    ReadNextChar();
                    return new Token(TupeToken.Operators, ch1.ToString());
                }
                else if (ch == '@')
                {
                    return new Token(TupeToken.End, ch.ToString());
                }
                else
                {
                    string s = ch.ToString();
                    ReadNextChar();
                    return new Token(TupeToken.WhiteSpace, s.ToString());
                }
            }
        }
    }
}
