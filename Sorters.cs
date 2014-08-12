using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorters
{
    internal class Sorters
    {
        private static void Swap(List<int> list, int x, int y)
        {
            int temp = list[x];
            list[x] = list[y];
            list[y] = temp;
        }

        public static void BubbleSort(List<int> x)
        {
            for (int i = 0; i < x.Count - 1; i++)
            {
                for (int j = 0; j < x.Count - 1 - i; j++)
                {
                    if (x[j] > x[j + 1]) Swap(x, j, j + 1);
                }
            }
        }

        public static void InstertionSort(List<int> x)
        {
            for (int i = 1; i < x.Count; i++)
            {
                int j = i - 1;
                while (j >= 0 && x[j] > x[j + 1])
                {
                    Swap(x, j, j + 1);
                    j--;
                }
            }
        }

        private static void MergeSort(List<int> array, int start, int end)
        {
            if (end - start > 2)
            {
                MergeSort(array, start, start + (end - start)/2);
                MergeSort(array, start + (end - start)/2, end);
                List<int> extraarray = new List<int>();
                int start1 = start;
                int end1 = start + (end - start)/2;
                int start2 = end1;
                while (extraarray.Count < end - start)
                {
                    if (start1 == end1 || (start2 < end && array[start2] <= array[start1]))
                    {
                        extraarray.Add(array[start2]);
                        ++start2;
                    }
                    else
                    {
                        extraarray.Add(array[start1]);
                        ++start1;
                    }
                }

                for (int i = start; i < end; i++)
                {
                    array[i] = extraarray[i - start];
                }
            }
            if (end - start == 2)
            {
                if (array[start] > array[start + 1]) Swap(array, start, start + 1);
            }
        }

        private static void QuickSort(List<int> array, int start, int end)
        {
            int pivot = array[end];
            int s = start;
            int e = end;
            do
            {
                while (array[s] < pivot) ++s;
                while (array[e] > pivot) --e;
                if (s <= e)
                {
                    Swap(array, s, e);
                    ++s;
                    --e;
                }
            } while (s <= e);
            if (e > start)
                QuickSort(array, start, e);
            if (s < end)
                QuickSort(array, s, end);
        }

        public static void Heapify(List<int> arr, int pos, int n)
        {
            int temp;
            while (2*pos + 1 < n)
            {
                int t = 2*pos + 1;
                if (2*pos + 2 < n && arr[2*pos + 2] >= arr[t])
                {
                    t = 2*pos + 2;
                }
                if (arr[pos] < arr[t])
                {
                    temp = arr[pos];
                    arr[pos] = arr[t];
                    arr[t] = temp;
                    pos = t;
                }
                else break;
            }
        }

        public static void HeapMake(List<int> arr, int n)
        {
            for (int i = n - 1; i >= 0; i--)
            {
                Heapify(arr, i, n);
            }
        }

        public static void HeapSort(List<int> arr, int n)
        {
            int temp;
            HeapMake(arr, n);
            while (n > 0)
            {
                temp = arr[0];
                arr[0] = arr[n - 1];
                arr[n - 1] = temp;
                n--;
                Heapify(arr, 0, n);
            }
        }


        private static void Main()
        {
            var random = new Random();
            List<int> a = new List<int>();
            List<int> b = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                a.Add(random.Next(-100, 100));
            }
            b = a;
            Console.WriteLine("Исходный :");
            foreach (int x in a)
            {
                Console.Write("{0} ", x);
            }
            Console.WriteLine();

            Console.WriteLine("\nОтсортированный :");
            QuickSort(b, 0, b.Count - 1);
            foreach (int x in b)
            {
                Console.Write("{0} ", x);
            }
            Console.WriteLine("\nОтсортированный Sort :");
            a.Sort();
            foreach (int x in a)
            {
                Console.Write("{0} ", x);
            }
        }
    }
}