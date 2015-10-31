using System;
using System.Text;

namespace ExtensionMethodSubstring
{
    public static class ExtentionMethod
    {
        public static StringBuilder Substring(this StringBuilder stringBuider, int index, int length)
        {
            string str = stringBuider.ToString().Substring(index, length);

            return new StringBuilder(str);
        }
    }
}
