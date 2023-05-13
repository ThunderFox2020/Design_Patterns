using System;

namespace Design_Patterns.Behavior_Patterns.Interpreter.Concrete
{
    public class Tester
    {
        public void Test()
        {
            Variable variableA = new Variable(2);
            Variable variableB = new Variable(4);
            Variable variableC = new Variable(8);
            Variable variableD = new Variable(16);
            Variable variableE = new Variable(32);

            Addition addition = new Addition(variableA, variableB);
            Subtraction subtraction = new Subtraction(addition, variableC);
            Multiplication multiplication = new Multiplication(subtraction, variableD);
            Division division = new Division(multiplication, variableE);

            Console.WriteLine(variableA.Interpret());
            Console.WriteLine(variableB.Interpret());
            Console.WriteLine(variableC.Interpret());
            Console.WriteLine(variableD.Interpret());
            Console.WriteLine(variableE.Interpret());
            Console.WriteLine(addition.Interpret());
            Console.WriteLine(subtraction.Interpret());
            Console.WriteLine(multiplication.Interpret());
            Console.WriteLine(division.Interpret());
        }
    }

    public abstract class Expression
    {
        public abstract int Interpret();
    }
    public class Variable : Expression
    {
        public Variable(int data) => Data = data;

        public int Data { get; set; }

        public override int Interpret() => Data;
    }
    public class Addition : Expression
    {
        public Addition(Expression left, Expression right)
        {
            Left = left;
            Right = right;
        }

        public Expression Left { get; set; }
        public Expression Right { get; set; }

        public override int Interpret() => Left.Interpret() + Right.Interpret();
    }
    public class Subtraction : Expression
    {
        public Subtraction(Expression left, Expression right)
        {
            Left = left;
            Right = right;
        }

        public Expression Left { get; set; }
        public Expression Right { get; set; }

        public override int Interpret() => Left.Interpret() - Right.Interpret();
    }
    public class Multiplication : Expression
    {
        public Multiplication(Expression left, Expression right)
        {
            Left = left;
            Right = right;
        }

        public Expression Left { get; set; }
        public Expression Right { get; set; }

        public override int Interpret() => Left.Interpret() * Right.Interpret();
    }
    public class Division : Expression
    {
        public Division(Expression left, Expression right)
        {
            Left = left;
            Right = right;
        }

        public Expression Left { get; set; }
        public Expression Right { get; set; }

        public override int Interpret() => Left.Interpret() / Right.Interpret();
    }
}