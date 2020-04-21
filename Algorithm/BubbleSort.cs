using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    class BubbleSort : IAlgorithm
    {
        public void Execute()
        {
            List<int> arr = new List<int> { 1, 5, 2, 3, 7, 9, 0 };
            Sort(arr);
            foreach (var num in arr)
            {
                Console.Write($"{num}, ");
            }
            Console.WriteLine();
        }

        private void Sort(List<int> arr)
        {
            int temp = 0;
            for (int i = arr.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
    }
}
