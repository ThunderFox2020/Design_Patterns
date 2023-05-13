using System;

namespace Design_Patterns.Generative_Patterns.Abstract_Factory.Abstract
{
    public class Tester
    {
        public void Test()
        {
            AbstractFactory entityFactory;
            EntityA entityA;
            EntityB entityB;

            entityFactory = new Entity1Factory();
            entityA = entityFactory.CreateEntityA();
            entityB = entityFactory.CreateEntityB();
            Console.WriteLine(entityA);
            Console.WriteLine(entityB);

            entityFactory = new Entity2Factory();
            entityA = entityFactory.CreateEntityA();
            entityB = entityFactory.CreateEntityB();
            Console.WriteLine(entityA);
            Console.WriteLine(entityB);
        }
    }

    public abstract class EntityA { }
    public class EntityA1 : EntityA { }
    public class EntityA2 : EntityA { }

    public abstract class EntityB { }
    public class EntityB1 : EntityB { }
    public class EntityB2 : EntityB { }

    public abstract class AbstractFactory
    {
        public abstract EntityA CreateEntityA();
        public abstract EntityB CreateEntityB();
    }
    public class Entity1Factory : AbstractFactory
    {
        public override EntityA CreateEntityA() => new EntityA1();
        public override EntityB CreateEntityB() => new EntityB1();
    }
    public class Entity2Factory : AbstractFactory
    {
        public override EntityA CreateEntityA() => new EntityA2();
        public override EntityB CreateEntityB() => new EntityB2();
    }
}