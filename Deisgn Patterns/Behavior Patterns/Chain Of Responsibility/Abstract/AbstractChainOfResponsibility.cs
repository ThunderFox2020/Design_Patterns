using System;

namespace Design_Patterns.Behavior_Patterns.Chain_Of_Responsibility.Abstract
{
    public class Tester
    {
        public void Test()
        {
            BoolHandler boolHandler = new BoolHandler();
            boolHandler.Handling(true);
            boolHandler.Handling(10);
            boolHandler.Handling("String");
            boolHandler.Handling(new object());
            Console.WriteLine();
            IntHandler intHandler = new IntHandler();
            intHandler.Handling(true);
            intHandler.Handling(10);
            intHandler.Handling("String");
            intHandler.Handling(new object());
            Console.WriteLine();
            StringHandler stringHandler = new StringHandler();
            stringHandler.Handling(true);
            stringHandler.Handling(10);
            stringHandler.Handling("String");
            stringHandler.Handling(new object());
        }
    }

    public abstract class Handler
    {
        public abstract Handler NextHandler { get; set; }
        public abstract void Handling(object source);
    }
    public class BoolHandler : Handler
    {
        public override Handler NextHandler { get; set; } = new IntHandler();

        public override void Handling(object source)
        {
            if (source is bool)
                Console.WriteLine($"{this} | Source Is Bool");
            else
                NextHandler?.Handling(source);
        }
    }
    public class IntHandler : Handler
    {
        public override Handler NextHandler { get; set; } = new StringHandler();

        public override void Handling(object source)
        {
            if (source is int)
                Console.WriteLine($"{this} | Source Is Int");
            else
                NextHandler?.Handling(source);
        }
    }
    public class StringHandler : Handler
    {
        public override Handler NextHandler { get; set; }

        public override void Handling(object source)
        {
            if (source is string)
                Console.WriteLine($"{this} | Source Is String");
            else
                NextHandler?.Handling(source);
        }
    }
}