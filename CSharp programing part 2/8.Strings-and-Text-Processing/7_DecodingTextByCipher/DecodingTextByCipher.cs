using System;
using System.Text;

// 7.   Write a program that encodes and decodes a string 
//      using given encryption key (cipher). The key consists 
//      of a sequence of characters. The encoding/decoding is 
//      done by performing XOR (exclusive or) operation over the
//      first letter of the string with the first of the key, the
//      second – with the second, etc. When the last key character 
//      is reached, the next is the first.


namespace _7_DecodingTextByCipher
{
    class DecodingTextByCipher
    {
        static void Main()
        {
            string message = "I'm I, Who are you? The key consists of a sequence of characters.";
            string key = ".NET";

            string encryptedMessage = Encryption(message, key);
            Console.WriteLine("Encrypted message: {0}", encryptedMessage);

            Console.WriteLine("\nDecrypted message: {0}\n", Decryption(encryptedMessage, key));
        }

        static string Encryption(string message, string key)
        {
            StringBuilder encryptedMessage = new StringBuilder(message.Length);

            for (int i = 0; i < message.Length; i++)
            {
                char encryptedChar = (char)(message[i] ^ key[i % key.Length]);
                encryptedMessage.Append(encryptedChar);
            }

            return encryptedMessage.ToString();
        }

        static string Decryption(string message, string key)
        {
            return Encryption(message, key);
        }

    }
}
