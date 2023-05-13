using System;

namespace Design_Patterns.Behavior_Patterns.State.Abstract
{
    public class Tester
    {
        public void Test()
        {
            State1 state1 = new State1();
            State2 state2 = new State2();

            Context context = new Context(state1);
            context.Action();
            context.Action();

            Console.WriteLine();

            context.State = state2;
            context.Action();
            context.Action();
        }
    }

    public abstract class State
    {
        public abstract void Action(Context context);
    }
    public class State1 : State
    {
        public override void Action(Context context)
        {
            Console.WriteLine("State Changed From State1 To State2");
            context.State = new State2();
        }
    }
    public class State2 : State
    {
        public override void Action(Context context)
        {
            Console.WriteLine("State Changed From State2 To State1");
            context.State = new State1();
        }
    }

    public class Context
    {
        public Context(State state) => State = state;

        public State State { get; set; }

        public void Action() => State.Action(this);
    }
}