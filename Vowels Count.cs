using System;

namespace _2._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            string toLower = input.ToLower();
            int sumOfVowels = GetCountOfVowels(input, toLower);
            Console.WriteLine(sumOfVowels);
        }

        private static int GetCountOfVowels(string input, string toLower)
        {
            int sumOfVowels = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (toLower[i] == 'a' || toLower[i] == 'e' || toLower[i] == 'i' || toLower[i] == 'o' || toLower[i] == 'u')
                {
                    sumOfVowels++;
                }
            }

            return sumOfVowels;
        }
    }
}
