using System;
using System.Collections.Generic;
using System.Text;

namespace _16.RunLengthEncoding
{
    class Program
    {
        static string testString = "AAAAAAAAAAAAABBCCCCDD";
        //static string testString = "Aa";

        static void Main(string[] args)
        {
            string result = RunLengthEncoding(testString);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        static public string RunLengthEncoding(string str)
        {
            StringBuilder encodedChars = new StringBuilder();
            int currentRun = 1;

            for (int i = 1; i < str.Length; i++)
            {
                char currentChar = str[i];
                char previousChar = str[i - 1];

                if(currentChar != previousChar || currentRun == 9)
                {
                    encodedChars.Append(currentRun.ToString());
                    encodedChars.Append(previousChar);
                    currentRun = 0;
                }
                currentRun++;
            }
            encodedChars.Append(currentRun.ToString());
            encodedChars.Append(str[str.Length - 1]);
            return encodedChars.ToString();
        }

        
    }
}
