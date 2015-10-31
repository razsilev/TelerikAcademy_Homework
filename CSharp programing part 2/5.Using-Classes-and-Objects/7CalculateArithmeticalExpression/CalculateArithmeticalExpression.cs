using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _7CalculateArithmeticalExpression
{
    class CalculateArithmeticalExpression
    {
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture =
                System.Globalization.CultureInfo.InvariantCulture;

            string expression = "(3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7)";
            //string expression = "pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3)";
            
            List<Token> tokens = new List<Token>();

            tokens = GetTokens(expression);

            // RPN - reverse Polish notation
            string[] RPN = ConvertTokensToRPN(tokens);

            Console.WriteLine("\nreverse Polish notation:");
            foreach (var tok in RPN)
            {
                Console.Write(tok + " ");
            }

            double result = CalculateRPN(RPN);

            Console.WriteLine("\n\nResult is: {0:N4}\n", result);
        }

        private static double CalculateRPN(string[] RPN)
        {
            Stack<double> numbers = new Stack<double>();

            for (int i = 0; i < RPN.Length; i++)
            {
                bool isNumber = false;
                double number = 0.0d;
                string str = RPN[i];

                isNumber = double.TryParse(str, out number);

                if (isNumber)
                {
                    numbers.Push(number);
                }
                else
                {
                    Calculate(numbers, str);
                }
            }

            return numbers.Pop();
        }

        private static void Calculate(Stack<double> numbers, string function)
        {
            switch (function)
            {
                case "+": Add(numbers);
                    break;
                case "-": Sub(numbers);
                    break;
                case "*": Mul(numbers);
                    break;
                case "/": Dev(numbers);
                    break;
                case "pow": Pow(numbers);
                    break;
                case "ln": Ln(numbers);
                    break;
                case "sqrt": Sqrt(numbers);
                    break;
                default: throw new ArgumentException("Invalid function");
                    break;
            }
        }

        private static void Pow(Stack<double> numbers)
        {
            double number1 = numbers.Pop();
            double number2 = numbers.Pop();
            numbers.Push(Math.Pow(number2, number1));
        }

        private static void Sqrt(Stack<double> numbers)
        {
            double number = numbers.Pop();
            numbers.Push(Math.Sqrt(number));
        }

        private static void Ln(Stack<double> numbers)
        {
            double number = numbers.Pop();
            numbers.Push(Math.Log(number));
        }

        private static void Dev(Stack<double> numbers)
        {
            double number1 = numbers.Pop();
            double number2 = numbers.Pop();
            numbers.Push(number2 / number1);
        }

        private static void Mul(Stack<double> numbers)
        {
            double number1 = numbers.Pop();
            double number2 = numbers.Pop();
            numbers.Push(number1 * number2);
        }

        private static void Sub(Stack<double> numbers)
        {
            double number1 = numbers.Pop();
            double number2 = numbers.Pop();
            numbers.Push(number2 - number1);
        }

        private static void Add(Stack<double> numbers)
        {
            double number1 = numbers.Pop();
            double number2 = numbers.Pop();
            numbers.Push(number1 + number2);
        }

        private static string[] ConvertTokensToRPN(List<Token> tokens)
        {
            Queue<string> queue = new Queue<string>();
            Stack<string> stack = new Stack<string>();

            foreach (Token token in tokens)
            {
                FindTokenPlace(queue, stack, token);
            }

            // add operators from stack to queue
            foreach (string @operator in stack)
            {
                queue.Enqueue(@operator);
            }

            return queue.ToArray();
        }

        private static void FindTokenPlace(Queue<string> queue, Stack<string> stack, Token token)
        {
            if (token.Tupe == TupeToken.Number)
            {
                queue.Enqueue(token.Value);
            }
            else if (token.Tupe == TupeToken.Operators ||
                token.Tupe == TupeToken.Function)
            {
                OperatorsPrecedence(queue, stack, token);

                stack.Push(token.Value);
            }
            else if (token.Tupe == TupeToken.Serarator &&
                token.Value == ",")
            {
                string str = "";

                while (str != "(")
                {
                    str = stack.Pop();

                    if (str != "(")
                    {
                        queue.Enqueue(str);
                    }
                }

                stack.Push("(");
            }
            else if (token.Tupe == TupeToken.Serarator && token.Value == "(")
            {
                stack.Push(token.Value);
            }
            else if (token.Tupe == TupeToken.Serarator && token.Value == ")")
            {
                RightBracket(queue, stack);
            }
        }

        private static void RightBracket(Queue<string> queue, Stack<string> stack)
        {
            string str = "";

            while (str != "(")
            {
                str = stack.Pop();

                if (str != "(")
                {
                    queue.Enqueue(str);
                }
                else
                {
                    if (stack.Count != 0)
                    {
                        string strFunction = stack.Peek();

                        if (strFunction == "ln" || strFunction == "pow" || strFunction == "sqrt")
                        {
                            queue.Enqueue(strFunction);
                            stack.Pop();
                            break;
                        }
                        
                    }

                }

            }
        }

        private static void OperatorsPrecedence(Queue<string> queue, Stack<string> stack, Token token)
        {
            if (token.Value == "-" || token.Value == "+")
            {
                string operator1 = "";

                if (stack.Count != 0)
                {
                    operator1 = stack.Peek();
                }

                if (operator1 == "*" || operator1 == "/" || operator1 == "-")
                {
                    while (true)
                    {
                        if (stack.Count != 0)
                        {
                            operator1 = stack.Peek();
                        }
                        else
                        {
                            break;
                        }

                        if (operator1 == "*" || operator1 == "/" || operator1 == "-")
                        {
                            queue.Enqueue(stack.Pop());
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        private static List<Token> GetTokens(string expression)
        {
            Scanner scanner = new Scanner(expression);
            List<Token> tokens = new List<Token>();

            while (true)
            {
                Token token = scanner.Next();

                if (token.Tupe == TupeToken.End)
                {
                    break;
                }

                if (token.Tupe != TupeToken.WhiteSpace)
                {
                    tokens.Add(token);
                    //Console.WriteLine(token.Value);
                }
            }

            return tokens;
        }
    }
}
