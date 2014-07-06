using System;

namespace Sum
{
    class Sum
    {
        private double result;

        public Sum(string[] a)
        {
            foreach (string el in a)
            {
                result += double.Parse(el);
            }
        }

        public double Get()
        {
            return result;
        }

        static void Main(string[] args)
        {
            string[] mas;
            Console.WriteLine("Введите строку");
            mas = Console.ReadLine().Replace('\"', ' ').Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(new Sum(mas).Get());
        }
    }