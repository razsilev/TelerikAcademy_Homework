using System;
using System.Net;

namespace _4DownloadFile
{
    class DownloadFile
    {
        static void Main()
        {
            Console.Title = "Download file from internet";

            Console.Write("Enter URL: ");
            //string url = "http://www.devbg.org/img/Logo-BASD.jpg"
            string url = Console.ReadLine();

            bool isDownloaded = FileDownload(url);

            if (isDownloaded)
            {
                Console.WriteLine("Download complete successfully.\n");
            }

        }

        private static bool FileDownload(string url)
        {
            string fileName = "";

            try
            {
                fileName = GetFileName(url);
            }
            catch(ArgumentException)
            {
                Console.WriteLine("Invalid path!");
                return false;
            }
            

            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(url, fileName);
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Invalid path!");
                return false;
            }
            catch (WebException)
            {
                Console.WriteLine("Internet exception or wrong path!");
                return false;
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Not Supported!");
                return false;
            }
            
            return true;
        }

        private static string GetFileName(string url)
        {
            if (url.Length <= 0 || !url.Contains("/"))
            {
                throw new ArgumentException();
            }

            string[] stringArray = url.Split('/');

            return stringArray[stringArray.Length - 1];
        }
    }
}
