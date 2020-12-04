using System;

namespace _15.CeasarCypherEncryptor
{
    class Program
    {
        static string str = "abc";
        static int key = 98;

        static void Main(string[] args)
        {
            Console.WriteLine(CaesarCypherMyMethod(str, key));
            Console.WriteLine(CaesarCypherAlgoExpertMethod(str, key));
            Console.ReadLine();
        }

        public static string CaesarCypherMyMethod(string str, int key)
        {
            // My method before watching explanation video

            // Time - O(N)
            // Space - O(N);

            string newString = "";

            foreach (char c in str)
            {
                int newchar = (int)c + key;
                while(newchar > 122)
                {
                    newchar = 96 + (newchar - 122);
                }
                
                newString += (char)newchar;
            }

            
            return newString;
        }

        public static string CaesarCypherAlgoExpertMethod(string str, int key)
        {
            // Algoexpert Method

            string newString = "";
            int reducedKey = key % 26; 

            foreach (char c in str)
            {
                int newchar = (int)c + reducedKey;                
                newString += (char)newchar;                
            }


            return newString;
        }
    }
}
