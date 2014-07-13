using System;

internal class BinarySearch
{
    private static int middle;

    public static int IterSearch(int x, int[] array)
    {
        int left, right;
        if (array.Length == 0)
        {
            Console.WriteLine("Введите массив");
            return -1;
        }
        left = 0;
        right = array.Length;
        while (left < right)
        {
            middle = left + (right - left)/2;
            if (x == array[middle]) return middle;
            if (x > array[middle]) left = middle + 1;
            else right = middle;
        }
        if (array[middle] > x) return middle;
        if (array[middle + 1] > x) return middle + 1;
        return -1;
    }

    public static int RecSearch(int x, int[] array, int left, int right)
    {
        if (array.Length == 0)
        {
            Console.WriteLine("Введите массив");
            return -1;
        }
        if (left >= right)
            if (array[middle] > x) return middle;
            else if (array[middle + 1] > x) return middle + 1;
            else return -1;
        middle = left + (right - left)/2;
        if (x == array[middle]) return middle;
        if (x > array[middle]) return RecSearch(x, array, middle + 1, right);
        return RecSearch(x, array, left, middle);
    }

    private static void Main(string[] args)
    {
        var numbers = new int[args.Length - 1];
        int key = int.Parse(args[0]);
        for (int i = 1; i < args.Length; i++)
        {
            numbers[i - 1] = int.Parse(args[i]);
        }
        Console.WriteLine(IterSearch(key, numbers));
        Console.WriteLine(RecSearch(key, numbers, 0, numbers.Length));
    }
}