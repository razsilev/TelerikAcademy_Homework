using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateVersionAttribute
{
    [VersionAttribute("1", "01")]
    public class CreateVersionAttribute
    {
        static void Main()
        {
            Type type = typeof(CreateVersionAttribute);

            object[] attributes = type.GetCustomAttributes(false);

            Console.WriteLine("Varsion of class CreateVersionAttribute is: {0}", (VersionAttribute)attributes[0]);
        }
    }
}
