namespace CSC_Preparation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            HashedSet<int> testHashedSet = new HashedSet<int>();

            testHashedSet.Add(1);
            testHashedSet.Add(2);
            testHashedSet.Add(3);
            testHashedSet.Add(7);
            testHashedSet.Add(11);
            testHashedSet.Add(13);

            Console.WriteLine("HashedSet 1");
            foreach (var item in testHashedSet)
            {
                Console.WriteLine(item);
            }

            HashedSet<int> testHashedSet_2 = new HashedSet<int>();

            testHashedSet_2.Add(1);
            testHashedSet_2.Add(4);
            testHashedSet_2.Add(7);
            testHashedSet_2.Add(10);
            testHashedSet_2.Add(13);
            testHashedSet_2.Add(17);

            Console.WriteLine("HashedSet 2");
            foreach (var item in testHashedSet_2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Union");
            testHashedSet.Union(testHashedSet_2);
            foreach (var item in testHashedSet)
            {
                Console.WriteLine(item);
            }

            /*Console.WriteLine("Intersect");
            testHashedSet.Intersect(testHashedSet_2);
            foreach (var item in testHashedSet)
            {
                Console.WriteLine(item);
            }*/
        }
    }
}
