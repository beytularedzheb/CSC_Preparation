/*
3. Write a program that counts how many times each word from given text file `words.txt`
appears in it. The character casing differences should be ignored. The result words should
be ordered by their number of occurrences in the text. Example:
'This is the TEXT. Text, text, text – THIS TEXT! Is this the text?'
is ‐> 2
the ‐> 2
this ‐> 3
text ‐> 6
*/

namespace CSC_Preparation
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    class NumberOfOccurence
    {
        static void Main(string[] args)
        {
            IDictionary<string, uint> wordOccurenceDictionary;

            string fileName = "../../words.txt";

            using (StreamReader sr = new StreamReader(fileName))
            {
                wordOccurenceDictionary = new Dictionary<string, uint>();

                string line;
                StringBuilder sb = new StringBuilder();

                while ((line = sr.ReadLine()) != null)
                {
                    line = line.ToLower();
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (Char.IsLetter(line[i]))
                        {
                            sb.Append(line[i]);
                        }
                        else if(sb.Length > 0)
                        {
                            if(!wordOccurenceDictionary.ContainsKey(sb.ToString()))
                            {
                                wordOccurenceDictionary[sb.ToString()] = 1;
                            }
                            else
                            {
                                wordOccurenceDictionary[sb.ToString()]++;
                            }
                            sb.Clear();
                        }
                    }
                }
            }

            foreach(var pair in wordOccurenceDictionary.OrderBy(kvp => kvp.Value))
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }
        }
    }
}
