using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//15  Write a program that replaces in a HTML document
//    given as string all the tags <a href="…">…</a> with 
//    corresponding tags [URL=…]…/URL]. Sample HTML fragment:

namespace _15_ReplacesTag
{
    class ReplacesTag
    {
        static void Main()
        {
            Console.Title = "HTML replaces tag";

            string htmlString = @"<p>Please visit <a href=""http://academy.telerik. com"">our site</a> to choose a training course. Also visit <a href=""www.devbg.org"">our forum</a> to discuss the courses.</p>";

            string relpasedHtmlTag = ReplaceTag(htmlString);

            Console.WriteLine(htmlString);
            Console.WriteLine("\nreplaced tag: \n\n{0}", relpasedHtmlTag);
        }

        private static string ReplaceTag(string htmlString)
        {
            StringBuilder result = new StringBuilder(htmlString.Length);
            int copyStartPosition = 0;
            int searchPosition = 0;

            while (true)
            {
                int startTagIndex = htmlString.IndexOf("<a", searchPosition);

                if (startTagIndex < 0)
                {
                    result.Append(htmlString.Substring(searchPosition, htmlString.Length - searchPosition));
                    break;
                }
                searchPosition = startTagIndex;
                string text = htmlString.Substring(copyStartPosition, startTagIndex - copyStartPosition);
                result.Append(text);

                int openUrlIndex = htmlString.IndexOf("=\"", searchPosition);
                searchPosition = openUrlIndex;
                int closeUrlIndex = htmlString.IndexOf("\">", searchPosition);
                searchPosition = closeUrlIndex + 2;
                copyStartPosition = searchPosition;

                text = htmlString.Substring(openUrlIndex + 2, closeUrlIndex - openUrlIndex - 2);
                result.Append("[URL=");
                result.Append(text + "]");

                startTagIndex = htmlString.IndexOf("</a>", searchPosition);
                text = htmlString.Substring(copyStartPosition, startTagIndex - copyStartPosition);
                result.Append(text);
                result.Append("[/URL]");
                copyStartPosition = startTagIndex + 4;
                searchPosition = copyStartPosition;
            }

            return result.ToString();
        }
    }
}
