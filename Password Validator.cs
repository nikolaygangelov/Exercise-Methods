using System;
using System.Linq;

namespace _4._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            if (GetCountOfChars(password))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (NoDigitsAndLetters(password))
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (SumOfDigits(password) < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (GetCountOfChars(password) == false && NoDigitsAndLetters(password) == false && SumOfDigits(password) >= 2)
            {
                Console.WriteLine("Password is valid");
            }
        }

        private static int SumOfDigits(string password)
        {
            
            int sumOfDigits = 0;
            string toLower = password.ToLower();
            for (int i = 0; i < password.Length; i++)
            {
                if (toLower[i] >= 48 && toLower[i] <= 57)
                {
                    sumOfDigits++;
                }
            }
            return sumOfDigits;
        }

        private static bool NoDigitsAndLetters(string password)
        {
            string toLower = password.ToLower();
            bool isNotValid = false;
            for (int i = 0; i < password.Length; i++)
            {
                if ((toLower[i] < 97 || toLower[i] > 122) && (toLower[i] < 48 || toLower[i] > 57))
                {
                    isNotValid = true;
                }
            }
            return isNotValid;
        }

        private static bool GetCountOfChars(string password)
        {
            bool isNotValid = false;
            if (password.Length < 6 || password.Length > 10)
            {
                isNotValid = true;
            }
            return isNotValid;
        }
    }
}
