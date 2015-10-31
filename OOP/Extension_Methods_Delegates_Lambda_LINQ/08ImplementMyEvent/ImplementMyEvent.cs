using System;

// 8.  * Read in MSDN about the keyword event in C# and
//     how to publish events. Re-implement the above
//     using .NET events and following the best practices.

namespace _08ImplementMyEvent
{
    using System.Collections;

    class ImplementMyEvent
    {
        private static int eventCount;
        // Test the ListWithChangedEvent class.
        public static void Main()
        {
            TextDataProvider textReader = new TextDataProvider();

            // Add event listener.
            textReader.ReadEvent += new ReadEventHandler(TextReader_ReadEvent);

            Console.WriteLine("First TEST");
            Console.WriteLine(textReader.Read("EventTask.txt"));

            // detach event listener.
            textReader.ReadEvent -= new ReadEventHandler(TextReader_ReadEvent);
            
            // Add new event listener.
            textReader.ReadEvent += new ReadEventHandler(EventCount);

            Console.WriteLine("\nSecond TEST");
            Console.WriteLine(textReader.Read("EventTask.txt"));
        }

        static void TextReader_ReadEvent(object sender, EventArgs e)
        {
            Console.WriteLine("\nThis is called when the event (read text from file) fires.\n");
        }

        static void EventCount(object sendet, EventArgs e)
        {
            eventCount++;
            Console.WriteLine("number of event calls after start listening: {0}\n", eventCount);
        }
    }
}
