/*
1. Write a program that counts in a given array of `double` values 
the number of occurrences of each value.Use `Dictionary<TKey, TValue>`.
Example: array = {3, 4, 4, ‐2.5, 3, 3, 4, 3, ‐2.5}
‐2.5 ‐> 2 times
3 ‐> 4 times
4 ‐> 3 times
*/

namespace CSC_Preparation
{
    using System;
    using System.Collections.Generic;

    class DoubleNumberOccurrence
    {
        static void Main(string[] args)
        {
            IDictionary<double, uint> occurrencyDictionary = new Dictionary<double, uint>();
            string[] stringInputArray = Console.ReadLine().Split(' ');

            for (int i = 0; i < stringInputArray.Length; i++)
            {
                double currentNumber = double.Parse(stringInputArray[i]);

                if (!occurrencyDictionary.ContainsKey(currentNumber))
                {
                    occurrencyDictionary[currentNumber] = 1;
                }
                else
                {
                    occurrencyDictionary[currentNumber]++;
                }
            }

            foreach(var pair in occurrencyDictionary)
            {
                Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
            }
        }
    }
}
