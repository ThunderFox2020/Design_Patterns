using System;

namespace Design_Patterns.Structural_Patterns.Bridge.Abstract
{
    public class Tester
    {
        public void Test()
        {
            Hierarchy1 realization11 = new Realization11(new Realization21());
            realization11.Action();
            realization11.Hierarchy2 = new Realization22();
            realization11.Action();

            Console.WriteLine();

            Hierarchy1 realization12 = new Realization12(new Realization21());
            realization12.Action();
            realization12.Hierarchy2 = new Realization22();
            realization12.Action();
        }
    }

    public abstract class Hierarchy1
    {
        public Hierarchy1(Hierarchy2 hierarchy2) => Hierarchy2 = hierarchy2;

        public Hierarchy2 Hierarchy2 { private get; set; }

        public void Action() => Hierarchy2.Action();
    }
    public class Realization11 : Hierarchy1
    {
        public Realization11(Hierarchy2 hierarchy2) : base(hierarchy2) { }
    }
    public class Realization12 : Hierarchy1
    {
        public Realization12(Hierarchy2 hierarchy2) : base(hierarchy2) { }
    }

    public abstract class Hierarchy2
    {
        public abstract void Action();
    }
    public class Realization21 : Hierarchy2
    {
        public override void Action() => Console.WriteLine("Realization 21 Action");
    }
    public class Realization22 : Hierarchy2
    {
        public override void Action() => Console.WriteLine("Realization 22 Action");
    }
}