using System;
using System.IO;

namespace _08ImplementMyEvent
{
    // A delegate type for hooking up change nitifications.
    public delegate void ReadEventHandler(object sender, EventArgs e);

    // A class sends evnt notification whenever call Read() method.
    class TextDataProvider
    {
        public event ReadEventHandler ReadEvent;

        // Invoke the Read event; called whenever read text file.
        protected virtual void OnRead(EventArgs e)
        {
            if (ReadEvent != null)
            {
                ReadEvent(this, e);
            }
        }

        // Invoke event after each
        public string Read(string fileFullPath)
        {
            string text = string.Empty;

            using (StreamReader reader = new StreamReader(fileFullPath))
            {
                text = reader.ReadToEnd();
            }

            OnRead(EventArgs.Empty);

            return text;
        }
    }
}
