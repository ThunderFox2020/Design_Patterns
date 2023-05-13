using System;

namespace Design_Patterns.Generative_Patterns.Factory_Method.Abstract
{
    public class Tester
    {
        public void Test()
        {
            EntityFactory entityFactory;
            Entity entity;

            entityFactory = new Entity1Factory();
            entity = entityFactory.CreateEntity();
            Console.WriteLine(entity);

            entityFactory = new Entity2Factory();
            entity = entityFactory.CreateEntity();
            Console.WriteLine(entity);
        }
    }

    public abstract class Entity { }
    public class Entity1 : Entity { }
    public class Entity2 : Entity { }

    public abstract class EntityFactory
    {
        public abstract Entity CreateEntity();
    }
    public class Entity1Factory : EntityFactory
    {
        public override Entity CreateEntity() => new Entity1();
    }
    public class Entity2Factory : EntityFactory
    {
        public override Entity CreateEntity() => new Entity2();
    }
}