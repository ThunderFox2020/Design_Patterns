using System;

namespace Design_Patterns.Generative_Patterns.Prototype.Abstract
{
    public class Tester
    {
        public void Test()
        {
            Entity1 entity1 = new Entity1();
            Entity2 entity2 = new Entity2();
            Entity1 cloneEntity1 = entity1.Clone() as Entity1;
            Entity2 cloneEntity2 = entity2.Clone() as Entity2;
            Console.WriteLine(entity1);
            Console.WriteLine(cloneEntity1);
            Console.WriteLine(entity2);
            Console.WriteLine(cloneEntity2);
        }
    }

    public abstract class Prototype
    {
        public abstract Prototype Clone();
    }
    public class Entity1 : Prototype
    {
        public override Prototype Clone() => new Entity1();
    }
    public class Entity2 : Prototype
    {
        public override Prototype Clone() => new Entity2();
    }
}