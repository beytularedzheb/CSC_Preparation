/*
2. Write a program that extracts from a given sequence of strings all elements that present
in it odd number of times. Example:
{C#, SQL, PHP, PHP, SQL, SQL } ‐> {C#, SQL}
*/

namespace CSC_Preparation
{
    using System;
    using System.Collections.Generic;

    class OddStrings
    {
        static List<string> ExtractOddStrings(string[] stringArray)
        {
            IDictionary<string, bool> occurrenceDictionary = new Dictionary<string, bool>();
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (!occurrenceDictionary.ContainsKey(stringArray[i]))
                {
                    occurrenceDictionary[stringArray[i]] = true;
                }
                else
                {
                    occurrenceDictionary[stringArray[i]] = !occurrenceDictionary[stringArray[i]];
                }
            }

            List<string> result = null;
            if (occurrenceDictionary.Count > 0)
            {
                result = new List<string>();

                foreach (var pair in occurrenceDictionary)
                {
                    if (pair.Value)
                    {
                        result.Add(pair.Key);
                    }
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            List<string> oddStrings = ExtractOddStrings(Console.ReadLine().Split(' '));
            foreach (var item in oddStrings)
            {
                Console.WriteLine(item);
            }
        }
    }
}
