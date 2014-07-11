using System;

class Sum
    {
        static void Main(string[] args)
        {
            int sum = 0;
            foreach (string arg in args)
            {
                if (arg==string.Empty) continue;
                string[] numbers = arg.Split(' ');
                foreach (string number in numbers)
                {
                    sum += int.Parse(number);
                }
            }
            Console.WriteLine("Результат - "+sum);
        }
    }