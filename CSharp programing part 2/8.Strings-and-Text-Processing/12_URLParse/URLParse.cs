using System;

// 12   Write a program that parses an URL address given in the format:
//      and extracts from it the [protocol], [server] and [resource] 
//      elements. For example from the URL http://www.devbg.org/forum/index.php 
//      the following information should be extracted:


namespace _12_URLParse
{
    class URLParse
    {
        static void Main()
        {
            Console.Title = "URL parse";

            string url = "http://www.devbg.org/forum/index.php";

            string protocol = "";
            string server = "";
            string resource = "";

            string[] strArray = url.Split(new string[] {"://"}, 
                                        StringSplitOptions.RemoveEmptyEntries);

            protocol = strArray[0];
            int endServerIndex = strArray[1].IndexOf('/');
            
            server = strArray[1].Substring(0, endServerIndex);
            resource = strArray[1].Substring(endServerIndex);

            Console.WriteLine("\n[protocol] = \"{0}\"", protocol);
            Console.WriteLine("[server] = \"{0}\"", server);
            Console.WriteLine("[resource] = \"{0}\"\n", resource);
        }
    }
}
