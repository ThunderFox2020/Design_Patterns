using System;

namespace Design_Patterns.Structural_Patterns.Proxy.Abstract
{
    public class Tester
    {
        public void Test()
        {
            IProxy real = new Real();
            IProxy proxy = new Proxy();
            real.Action();
            proxy.Action();
        }
    }

    public interface IProxy
    {
        public void Action();
    }
    public class Real : IProxy
    {
        public void Action() => Console.WriteLine("Real Action");
    }
    public class Proxy : IProxy
    {
        private Real real = new Real();

        public void Action()
        {
            if (DateTime.Now.Second % 2 == 0)
                real.Action();
            else
                Console.WriteLine("Proxy Action");
        }
    }
}