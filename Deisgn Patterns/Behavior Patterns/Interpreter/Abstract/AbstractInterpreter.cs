using System;

namespace Design_Patterns.Behavior_Patterns.Interpreter.Abstract
{
    public class Tester
    {
        public void Test()
        {
            TerminalExpression terminalExpression1 = new TerminalExpression("Expression 1");
            TerminalExpression terminalExpression2 = new TerminalExpression("Expression 2");
            TerminalExpression terminalExpression3 = new TerminalExpression("Expression 3");
            TerminalExpression terminalExpression4 = new TerminalExpression("Expression 4");
            TerminalExpression terminalExpression5 = new TerminalExpression("Expression 5");

            NonTerminalExpression nonTerminalExpression1 = new NonTerminalExpression(terminalExpression1, terminalExpression2);
            NonTerminalExpression nonTerminalExpression2 = new NonTerminalExpression(nonTerminalExpression1, terminalExpression3);
            NonTerminalExpression nonTerminalExpression3 = new NonTerminalExpression(nonTerminalExpression2, terminalExpression4);
            NonTerminalExpression nonTerminalExpression4 = new NonTerminalExpression(nonTerminalExpression3, terminalExpression5);

            terminalExpression1.Interpret();
            Console.WriteLine();
            terminalExpression2.Interpret();
            Console.WriteLine();
            terminalExpression3.Interpret();
            Console.WriteLine();
            terminalExpression4.Interpret();
            Console.WriteLine();
            terminalExpression5.Interpret();
            Console.WriteLine();
            nonTerminalExpression1.Interpret();
            Console.WriteLine();
            nonTerminalExpression2.Interpret();
            Console.WriteLine();
            nonTerminalExpression3.Interpret();
            Console.WriteLine();
            nonTerminalExpression4.Interpret();
        }
    }

    public abstract class Expression
    {
        public abstract void Interpret();
    }
    public class TerminalExpression : Expression
    {
        public TerminalExpression(string data) => Data = data;

        public string Data { get; set; }

        public override void Interpret() => Console.WriteLine($"Data: {Data}");
    }
    public class NonTerminalExpression : Expression
    {
        public NonTerminalExpression(Expression expression1, Expression expression2)
        {
            Expression1 = expression1;
            Expression2 = expression2;
        }

        public Expression Expression1 { get; set; }
        public Expression Expression2 { get; set; }

        public override void Interpret()
        {
            Expression1.Interpret();
            Expression2.Interpret();
        }
    }
}