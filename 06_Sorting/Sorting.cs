namespace CSC_Preparation
{
    class Sorting
    {
        private static void swap(int[] arr, int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }

        public static void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int indexMin = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[indexMin] > arr[j])
                    {
                        indexMin = j;
                    }
                }

                swap(arr, indexMin, i);
            }
        }

        public static void BubleSort(int[] arr)
        {
            bool swapped;
            int len = arr.Length - 1;

            do
            {
                swapped = false;
                
                for (int i = 0; i < len; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        swap(arr, i, i + 1);
                        swapped = true;
                    }
                }

                len--;
            } while (swapped);
        }
    }
}
