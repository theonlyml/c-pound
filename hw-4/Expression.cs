using System;


internal class Expression
{
    public interface IExpression
    {
        int Evaluate(int x);
    }

    public abstract class BinaryOperation : IExpression
    {
        protected IExpression First;
        protected IExpression Second;

        protected BinaryOperation(IExpression first, IExpression second)
        {
            First = first;
            Second = second;
        }

        public abstract int Evaluate(int x);
    }


    public class Add : BinaryOperation
    {
        public Add(IExpression first, IExpression second) : base(first, second)
        {
        }

        public override int Evaluate(int x)
        {
            return First.Evaluate(x) + Second.Evaluate(x);
        }

        public override string ToString()
        {
            return string.Format("{0} + {1}", First, Second);
        }
    }


    public class Const : IExpression
    {
        private int _value;

        public Const(int value)
        {
            _value = value;
        }

        public int Evaluate(int x)
        {
            return _value;
        }

        public override string ToString()
        {
            return _value.ToString();
        }
    }

    public class Module : IExpression
    {
        private IExpression _operand;

        public Module(IExpression operand)
        {
            _operand = operand;
        }

        public int Evaluate(int x)
        {
            return Math.Abs(_operand.Evaluate(x));
        }
    }

    public class UnaryMinus : IExpression
    {
        private IExpression _operand;

        public UnaryMinus(IExpression operand)
        {
            _operand = operand;
        }

        public int Evaluate(int x)
        {
            return -_operand.Evaluate(x);
        }
    }

    public class Subtract : BinaryOperation
    {
        public Subtract(IExpression first, IExpression second)
            : base(first, second)
        {
        }

        public override int Evaluate(int x)
        {
            return First.Evaluate(x) - Second.Evaluate(x);
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", First, Second);
        }
    }

    public class Multiply : BinaryOperation
    {
        public Multiply(IExpression first, IExpression second)
            : base(first, second)
        {
        }

        public override int Evaluate(int x)
        {
            return First.Evaluate(x)*Second.Evaluate(x);
        }

        public override string ToString()
        {
            if (First is Add || First is Subtract)
            {
                if (Second is Add || Second is Subtract)
                {
                    return string.Format("({0}) * ({1})", First, Second);
                }
                return string.Format("({0}) * {1}", First, Second);
            }
            if (Second is Add || Second is Subtract)
            {
                return string.Format("{0} * ({1})", First, Second);
            }
            return string.Format("{0} * {1}", First, Second);
        }
    }

    public class Divide : BinaryOperation
    {
        public Divide(IExpression first, IExpression second)
            : base(first, second)
        {
        }

        public override int Evaluate(int x)
        {
            return First.Evaluate(x)/Second.Evaluate(x);
        }

        public override string ToString()
        {
            if (First is Add || First is Subtract)
            {
                if (Second is Add || Second is Subtract)
                {
                    return string.Format("({0}) / ({1})", First, Second);
                }
                return string.Format("({0}) / {1}", First, Second);
            }
            if (Second is Add || Second is Subtract)
            {
                return string.Format("{0} / ({1})", First, Second);
            }
            return string.Format("{0} / {1}", First, Second);
        }
    }

    public class Variable : IExpression
    {
        private string _name;

        public Variable(string name)
        {
            _name = name;
        }

        public int Evaluate(int x)
        {
            return x;
        }

        public override string ToString()
        {
            return _name;
        }
    }


    private static void Main()
    {
        Console.WriteLine(
            new Add(
                new Subtract(new Multiply(new Variable("x"), new Variable("x")),
                    new Multiply(new Const(2), new Variable("x"))), new Const(1)));
    }
}