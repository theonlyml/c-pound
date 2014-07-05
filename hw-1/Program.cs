using System;

namespace ConsoleApplication17
{
    class Sum
    {
        double result;
        public Sum(string[] a)
        {
     /*       foreach (string el in a)
            {
                result += double.Parse(el);
            }
      */
            for (int i = 1; i < a.Length; i++)
            {
                result += double.Parse(a[i]);
            }
        }

        public double Get()
        {
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] mas;
            while (true)
            {
                Console.WriteLine("Введите строку");
                mas = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); 
                if (mas[0] == "sum")
                {
                  //  mas = mas.Except(new string[] { "sum" }).ToArray(); удаляет повторяющиеся значения, как ни странно
                    Sum a = new Sum(mas);
                    Console.WriteLine(a.Get());
                }
            }
        }
    }
}
