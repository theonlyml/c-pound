using System;

    class BinarySearch
    {
        int left, right, mid;
        public int IterSearch(int x,int[] array)
        {
            if (array.Length==0) 
            {
                Console.WriteLine("Введите массив");
                return -1;
            }
            left = 0;
            right = array.Length;
            while (left<right)
            {
                mid = left + (right - left)/2;
                if (x == array[mid]) return mid;
                if (x > array[mid]) left = mid+1;
                else right = mid;
            }
            if (array[mid] > x) return mid;
            if (array[mid+1] > x) return mid+1;
            return -1;
        }

        public int RecSearch(int x,int[] array,int left,int right)
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Введите массив");
                return -1;
            }
            if (left >= right)
                if (array[mid] > x) return mid;
                else if (array[mid+1] > x) return mid+1;
                else return -1;
            mid = left + (right - left) / 2;
            if (x == array[mid]) return mid;
            if (x > array[mid]) return RecSearch(x, array, mid+1, right);
            return RecSearch(x, array, left, mid);
        }

        static void Main(string[] args)
        {
            int[] numbers=new int[args.Length-1];
            int key = int.Parse(args[0]);
            for (int i = 1; i < args.Length; i++)
            {
                numbers[i - 1] = int.Parse(args[i]);
            }
            Console.WriteLine(new BinarySearch().IterSearch(key,numbers));
            Console.WriteLine(new BinarySearch().RecSearch(key,numbers,0,numbers.Length));
        }
    }
