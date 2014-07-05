using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication17
{
    class Sum
    {
        double result;
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
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] mas;
            while (true)
            {
                Console.WriteLine("Введите строку");
                mas = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                if (mas[0] == "sum")
                {
                    mas = mas.Except(new string[] {"sum"}).ToArray();
                    Sum a = new Sum(mas);
                    Console.WriteLine(a.Get());
                }
            }
        }
    }
}
