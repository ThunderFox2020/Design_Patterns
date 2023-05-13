using System;

namespace Design_Patterns.Behavior_Patterns.Template_Method.Abstract
{
    public class Tester
    {
        public void Test()
        {
            ConcreteClass1 concreteClass1 = new ConcreteClass1();
            concreteClass1.Algorithm();
            Console.WriteLine();
            ConcreteClass2 concreteClass2 = new ConcreteClass2();
            concreteClass2.Algorithm();
            Console.WriteLine();
            ConcreteClass3 concreteClass3 = new ConcreteClass3();
            concreteClass3.Algorithm();
            Console.WriteLine();
            ConcreteClass4 concreteClass4 = new ConcreteClass4();
            concreteClass4.Algorithm();
        }
    }

    public abstract class AbstractClass
    {
        public void Algorithm()
        {
            Step1();
            Step2();
        }
        public virtual void Step1() => Console.WriteLine("Step 1");
        public virtual void Step2() => Console.WriteLine("Step 2");
    }
    public class ConcreteClass1 : AbstractClass
    {

    }
    public class ConcreteClass2 : AbstractClass
    {
        public override void Step1() => Console.WriteLine("Changed Step 1");
    }
    public class ConcreteClass3 : AbstractClass
    {
        public override void Step2() => Console.WriteLine("Changed Step 2");
    }
    public class ConcreteClass4 : AbstractClass
    {
        public override void Step1() => Console.WriteLine("Changed Step 1");
        public override void Step2() => Console.WriteLine("Changed Step 2");
    }
}