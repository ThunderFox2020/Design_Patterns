using System;

namespace Design_Patterns.Structural_Patterns.Facade.Abstract
{
    public class Tester
    {
        public void Test()
        {
            Facade facade = new Facade(new SubSystem1(), new SubSystem2(), new SubSystem3());
            facade.Action();
        }
    }

    public class SubSystem1
    {
        public void Action() => Console.WriteLine("SubSystem1 Action");
    }
    public class SubSystem2
    {
        public void Action() => Console.WriteLine("SubSystem2 Action");
    }
    public class SubSystem3
    {
        public void Action() => Console.WriteLine("SubSystem3 Action");
    }
    public class Facade
    {
        public Facade(SubSystem1 subSystem1, SubSystem2 subSystem2, SubSystem3 subSystem3)
        {
            this.subSystem1 = subSystem1;
            this.subSystem2 = subSystem2;
            this.subSystem3 = subSystem3;
        }

        private SubSystem1 subSystem1;
        private SubSystem2 subSystem2;
        private SubSystem3 subSystem3;

        public void Action()
        {
            subSystem1.Action();
            subSystem2.Action();
            subSystem3.Action();
        }
    }
}