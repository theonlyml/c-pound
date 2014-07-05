using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication17
{
    class Sum
    {
        double result;
        public Sum(List<string> a)
        {
            foreach (string term in a)
            {
                result += double.Parse(term);
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
            List<string> line=new List<string>();
            while (true)
            {
                Console.WriteLine("Введите строку");
                line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList(); 
                if (line[0] == "sum")
                {
                    line.RemoveAt(0);
                    Sum sum = new Sum(line);
                    Console.WriteLine(sum.Get());
                }
            }
        }
    }
}
