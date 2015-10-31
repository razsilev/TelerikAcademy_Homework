using System;
using System.Text;

// 5.   You are given a text. Write a program that changes 
//      the text in all regions surrounded by the tags <upcase> and </upcase>
//      to uppercase. The tags cannot be nested.


namespace _5_UpCaseTag
{
    class UpCaseTag
    {
        static void Main()
        {
            Console.Title = "Upcase tag";

            Console.Write("Enter text: ");

            string text = Console.ReadLine();

            string upcaseResults = ExecuteUpcaseTag(text);

            Console.WriteLine("\n{0}", upcaseResults);
        }

        private static string ExecuteUpcaseTag(string text)
        {
            string startTag = "<upcase>";
            string endTag = "</upcase>";
            StringBuilder result = new StringBuilder();

            string[] strings = text.Split(new string[] { startTag }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string str in strings)
            {
                if (str.Contains(endTag))
                {
                    string[] stringsWhitUpcase = str.Split(new string[] { endTag },
                                                        StringSplitOptions.RemoveEmptyEntries);
                    
                    result.Append(stringsWhitUpcase[0].ToUpper());
                    result.Append(stringsWhitUpcase[1]);
                }
                else
                {
                    result.Append(str);
                }
            }

            return result.ToString();
        }
    }
}
