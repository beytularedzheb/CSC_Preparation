namespace CSC_Preparation
{
    using System;

    class StarterClass
    {
        static void Main(string[] args)
        {
            //int[] arr = { 5, 1, 4, 0, -1, 8, 2, 3, 7, 6, 9 };
            //// Sorting.SelectionSort(arr);
            //Sorting.BubleSort(arr);
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.Write("{0} ", arr[i]);
            //}
            //Console.WriteLine();

            SignlyLinkedList<int> list = new SignlyLinkedList<int>();

            list.AddFirst(1);
            list.AddLast(2);
            list.AddFirst(3);

            Console.WriteLine("Size: {0}", list.Count);
            list.Remove(2);
            Console.WriteLine("Size after Remove(): {0}", list.Count);

            Console.WriteLine(list.Contains(1));

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

        }
    }
}
