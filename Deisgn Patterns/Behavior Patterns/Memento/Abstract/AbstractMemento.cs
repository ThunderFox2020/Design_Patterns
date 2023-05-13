using System;
using System.Collections.Generic;

namespace Design_Patterns.Behavior_Patterns.Memento.Abstract
{
    public class Tester
    {
        public void Test()
        {
            Target target = new Target();
            Keeper keeper = new Keeper();

            target.State = "State 1";
            Console.WriteLine(target.State);

            keeper.Mementoes.Add(target.Save());

            target.State = "State 2";
            Console.WriteLine(target.State);

            target.Load(keeper.Mementoes[0]);

            Console.WriteLine(target.State);
        }
    }

    public class Target
    {
        public string State { get; set; }

        public Memento Save() => new Memento(State);
        public void Load(Memento memento) => State = memento.State;
    }
    public class Memento
    {
        public Memento(string state) => State = state;

        public string State { get; }
    }
    public class Keeper
    {
        public List<Memento> Mementoes { get; } = new List<Memento>();
    }
}