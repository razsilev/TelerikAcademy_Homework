using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//25. Write a program that extracts from given HTML file its title (if available),
//    and its body text without the HTML tags. Example:

namespace _25_ExtractHTML
{
    class ExtractHTML
    {
        static void Main()
        {
            Console.Title = "Extract HTML";

            Console.Write("Enter HTML text: ");

            string html = Console.ReadLine();

            string title = GetTitle(html);
            string bodyText = GetBodyText(html);

            Console.WriteLine("\nTitle -> {0}\n", title);
            Console.WriteLine("Body text -> {0}\n", bodyText);

        }

        private static string GetBodyText(string html)
        {
            StringBuilder bodyText = new StringBuilder();
            string openBodyTag = "<body>";

            int startBodyIndex = html.IndexOf(openBodyTag) + openBodyTag.Length;

            bool isText = false;
            for (int i = startBodyIndex; i < html.Length; i++)
            {
                if (html[i] == '>')
                {
                    isText = true;
                    i++;
                }

                if (i < html.Length && isText && html[i] != '<')
                {
                    bodyText.Append(html[i]);
                }
                else
                {
                    isText = false;
                }
            }

            return bodyText.ToString();
        }

        private static string GetTitle(string html)
        {
            string result = "";

            string openTitleTag = "<title>";
            string closeTitleTag = "</title>";

            int startTitleIndex = html.IndexOf(openTitleTag) + openTitleTag.Length;
            if (startTitleIndex < 0)
            {
                return result;
            }

            int titleLength = html.IndexOf(closeTitleTag) - startTitleIndex;

            result = html.Substring(startTitleIndex, titleLength);

            return result;
        }
    }
}
