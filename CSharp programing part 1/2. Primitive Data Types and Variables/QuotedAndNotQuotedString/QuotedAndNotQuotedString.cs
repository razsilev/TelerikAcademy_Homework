using System;

class QuotedAndNotQuotedString
{
    static void Main()
    {
        string quoted = @"The ""use"" of quotations causes difficulties.";

        string notQuoted = "The \"use\" of quotations causes difficulties.";

        Console.WriteLine(quoted);
        Console.WriteLine(notQuoted);
    }
}