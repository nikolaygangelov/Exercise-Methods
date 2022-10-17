

namespace _11._Array_Manipulator
{
    using System;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command
                    .Split(" ");
                string cmdType = cmdArgs[0];
                if (cmdType == "exchange")
                {
                    int exchangeIndex = int.Parse(cmdArgs[1]);
                    if (exchangeIndex < 0 || exchangeIndex >= array.Length)
                    {

                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    array = ExchangeElements(array, exchangeIndex);
                }
                else if (cmdType == "max" || cmdType == "min")
                {
                    // string evenOrOddArg = cmdArgs[1];
                    int indexOfElement = 0;
                    if (cmdType == "max")
                    {
                        indexOfElement = GetMaxEvenOrOddIndex(array, cmdArgs);
                    }
                    else
                    {
                        indexOfElement = GetMinEvenOrOddIndex(array, cmdArgs);
                    }
                    if (indexOfElement == -1)
                    {
                        Console.WriteLine("No matches");
                        continue; 
                    }
                    Console.WriteLine(indexOfElement);
                }
                else if (cmdType == "first" || cmdType == "last")
                {
                    int count = int.Parse(cmdArgs[1]);
                    string evenOrOddArg = cmdArgs[2];

                    if (count > array.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }
                    int[] elements;
                    if(cmdType == "first")
                    {
                        elements = FirstEvenOrOddElements(array, count, evenOrOddArg);
                    }
                    else
                    {
                        elements = LastEvenOrOddElements(array, count, evenOrOddArg);
                    }
                    PrintArray(elements);
                }
            }
            PrintArray(array);
        }

        private static int GetMaxEvenOrOddIndex(int[] array, string[] cmdArgs)
        {
            int maxEvenItem = int.MinValue;
            int rightmostIndex = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (cmdArgs[1] == "even" && array[i] % 2 == 0)
                {
                    if (array[i] >= maxEvenItem)
                    {
                        maxEvenItem = array[i];
                        rightmostIndex = i;
                    }
                }
                else if (cmdArgs[1] == "odd" && array[i] % 2 != 0)
                {
                    if (array[i] >= maxEvenItem)
                    {
                        maxEvenItem = array[i];
                        rightmostIndex = i;
                    }
                }
            }
            return rightmostIndex;
        }

        private static int GetMinEvenOrOddIndex(int[] array, string[] cmdArgs)
        {
            int minOddItem = int.MaxValue;
            int leftmostIndex = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (cmdArgs[1] == "even" && array[i] % 2 == 0)
                {
                    if (array[i] <= minOddItem)
                    {
                        minOddItem = array[i];
                        leftmostIndex = i;
                    }
                }
                else if (cmdArgs[1] == "odd" && array[i] % 2 != 0)
                {
                    if (array[i] <= minOddItem)
                    {
                        minOddItem = array[i];
                        leftmostIndex = i;
                    }
                }
            }
            return leftmostIndex;
        }

        private static int[] ExchangeElements(int[] array, int exchangeIndex)
        {

            int rotations = exchangeIndex + 1;
            while (rotations > 0)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    int first = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = first;
                }
                rotations--;
            }
            return array;
        }

        private static int[] FirstEvenOrOddElements(int[] array, int count, string evenOrOddArg)
        {
            int[] firstElArr = new int[count];
            int firstElArrIndex = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (firstElArrIndex >= count)
                {
                    break;
                }

                if (evenOrOddArg == "even" && array[i] % 2 == 0)
                {
                    firstElArr[firstElArrIndex++] = array[i];
                }
                else if (evenOrOddArg == "odd" && array[i] % 2 != 0)
                {
                    firstElArr[firstElArrIndex++] = array[i];
                }
            }

            firstElArr = ResizeArray(firstElArr, firstElArrIndex);
            return firstElArr;
        }

        private static int[] LastEvenOrOddElements(int[] array, int count, string evenOrOddArg)
        {
            int[] firstElArr = new int[count];
            int firstElArrIndex = 0;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (firstElArrIndex >= count)
                {
                    break;
                }

                if (evenOrOddArg == "even" && array[i] % 2 == 0)
                {
                    firstElArr[firstElArrIndex++] = array[i];
                }
                else if (evenOrOddArg == "odd" && array[i] % 2 != 0)
                {
                    firstElArr[firstElArrIndex++] = array[i];
                }
            }

            firstElArr = ResizeArray(firstElArr, firstElArrIndex);
            firstElArr = ReverseArray(firstElArr);
            return firstElArr;
        }

        private static int[] ResizeArray(int[] firstElArr, int count)
        {
            int[] modifiedArray = new int[count];
            for (int i = 0; i < count; i++)
            {
                modifiedArray[i] = firstElArr[i];
            }
            return modifiedArray;
        }

        private static int[] ReverseArray(int[] firstElArr)
        {
            int[] reversed = new int[firstElArr.Length];
            for (int i = firstElArr.Length - 1; i >= 0; i--)
            {
                reversed[reversed.Length - i - 1] = firstElArr[i];
            }

            return reversed;
        }

        private static void PrintArray(int[] array)
        {
            Console.WriteLine($"[{string.Join(", ", array)}]");
        }
    }
}
