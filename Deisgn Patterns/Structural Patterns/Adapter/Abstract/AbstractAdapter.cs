using System;

namespace Design_Patterns.Structural_Patterns.Adapter.Abstract
{
    public class Tester
    {
        public void Test()
        {
            User user = new User();
            To to = new To();
            user.UserAction(to);

            From from = new From();
            Adapter adapter = new Adapter(from);
            user.UserAction(adapter);
        }
    }

    public class From
    {
        public void FromAction() => Console.WriteLine("From Action");
    }
    public class Adapter : To
    {
        public Adapter(From from) => this.from = from;

        private From from;

        public override void ToAction() => from.FromAction();
    }
    public class To
    {
        public virtual void ToAction() => Console.WriteLine("To Action");
    }
    public class User
    {
        public void UserAction(To to) => to.ToAction();
    }
}