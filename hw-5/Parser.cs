using System;

public class Parser
{
    private static int _value;
    private static bool _flag;

    private static string s;
    private static int pointer;

    private static bool End()
    {
        return pointer == s.Length;
    }

    private static char Peek()
    {
        if (End()) throw new ApplicationException("oops! everything good ends someday..");
        return s[pointer];
    }

    private static char Next()
    {
        if (End()) throw new ApplicationException("oops! everything good ends someday..");
        return s[pointer++];
    }

    private static void WhiteSpace()
    {
        while (!End() && Peek() == ' ')
        {
            Next();
        }
    }

    private static bool isDigit()
    {
        return Peek() >= '0' && Peek() <= '9';
    }

    private static int Operand()
    {
        WhiteSpace();
        if (!End() && Peek() == '(')
        {
            Next();
            var res = Sum();
            System.Diagnostics.Debug.Assert(Peek() != ')');
            Next();
            return res;
        }
        if (Peek() == 'x')
        {
            if (_flag)
            {
                Next();
                WhiteSpace();
                return _value;
            }
            throw new ApplicationException("theres no x");
        }
        var cnst = 0;
        while (!End() && isDigit())
        {
            cnst *= 10;
            cnst += Next() - '0';
        }
        WhiteSpace();
        return cnst;
    }

    private static int Miltiply()
    {
        var res = Operand();
        while (!End() && Peek() == '*')
        {
            Next();
            res *= Operand();
        }
        while (!End() && Peek() == '/')
        {
            Next();
            res /= Operand();
        }
        return res;
    }

    private static int Sum()
    {
        var res = Miltiply();
        while (!End() && Peek() == '+')
        {
            Next();
            res += Miltiply();
        }
        while (!End() && Peek() == '-')
        {
            Next();
            res -= Miltiply();
        }
        return res;
    }


    private static int Parse(string expression)
    {
        s = expression;
        pointer = 0;
        return Sum();
    }

    private static int Parse(string expression, int x)
    {
        s = expression;
        pointer = 0;
        _value = x;
        _flag = true;
        return Sum();
    }

    public static void Main()
    {
        Console.WriteLine(Parse("12 * 5 * (3 + 7 + 2 * 2 * 2) + 10 / 2 / 5 + 21 - 7 - 15"));
    }
}