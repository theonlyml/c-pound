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
    }


    private static void Main(string[] args)
    {
        Console.WriteLine(
            new Add(
                new Subtract(new Multiply(new Variable("x"), new Variable("x")),
                    new Multiply(new Const(2), new Variable("x"))), new Const(1)).Evaluate(3));
    }
}