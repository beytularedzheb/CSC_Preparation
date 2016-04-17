namespace CSC_Preparation
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            HashTable<string, int> testHashTable = new HashTable<string, int>();

            for (int i = 0; i < 16; i++)
            {
                testHashTable.Add(i.ToString(), i);
            }

            testHashTable.Remove("0");
            try
            {
                testHashTable[null] = 5;
                // testHashTable.Add(null, 5);
                // testHashTable.Remove("NotExistingKey");
                // testHashTable.Remove(null);
            }
            catch (KeyNotFoundException ke)
            {
                Console.WriteLine(ke.Message);
            }
            catch (ArgumentNullException ae)
            {
                Console.WriteLine(ae.Message);
            }


            Console.WriteLine(testHashTable.Find("5"));
            testHashTable["5"] = 5555;

            foreach (var key in testHashTable.Keys)
            {
                Console.WriteLine("Key: {0}", key);
            }

            foreach (var pair in testHashTable)
            {
                Console.WriteLine("Key: {0}, Value: {1}", pair.Key, pair.Value);
            }
        }
    }
}
