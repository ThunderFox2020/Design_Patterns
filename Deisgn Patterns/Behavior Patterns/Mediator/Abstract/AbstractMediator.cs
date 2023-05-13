using System;

namespace Design_Patterns.Behavior_Patterns.Mediator.Abstract
{
    public class Tester
    {
        public void Test()
        {
            Mediator1 mediator1 = new Mediator1();

            Member1 member1 = new Member1(mediator1);
            Member2 member2 = new Member2(mediator1);
            Member3 member3 = new Member3(mediator1);

            mediator1.Member1 = member1;
            mediator1.Member2 = member2;
            mediator1.Member3 = member3;

            member1.Send("Message 1");
            member2.Send("Message 2");
            member3.Send("Message 3");
        }
    }

    public abstract class Mediator
    {
        public abstract void Send(Member from, string message);
    }
    public abstract class Member
    {
        public Member(Mediator mediator) => this.mediator = mediator;

        private protected Mediator mediator;

        public abstract void Send(string message);
        public abstract void Receive(string message);
    }

    public class Mediator1 : Mediator
    {
        public Member1 Member1 { get; set; }
        public Member2 Member2 { get; set; }
        public Member3 Member3 { get; set; }

        public override void Send(Member from, string message)
        {
            if (from == Member1)
                Member2.Receive(message);
            if (from == Member2)
                Member3.Receive(message);
            if (from == Member3)
                Member1.Receive(message);
        }
    }
    public class Member1 : Member
    {
        public Member1(Mediator1 mediator1) : base(mediator1) { }

        public override void Send(string message) => mediator.Send(this, message);
        public override void Receive(string message) => Console.WriteLine($"Member 1 Got: {message}");
    }
    public class Member2 : Member
    {
        public Member2(Mediator1 mediator1) : base(mediator1) { }

        public override void Send(string message) => mediator.Send(this, message);
        public override void Receive(string message) => Console.WriteLine($"Member 2 Got: {message}");
    }
    public class Member3 : Member
    {
        public Member3(Mediator1 mediator1) : base(mediator1) { }

        public override void Send(string message) => mediator.Send(this, message);
        public override void Receive(string message) => Console.WriteLine($"Member 3 Got: {message}");
    }
}