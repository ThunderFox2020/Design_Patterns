using System;
using System.Collections.Generic;

namespace Design_Patterns.Structural_Patterns.Flyweight.Abstract
{
    public class Tester
    {
        public void Test()
        {
            EntityFactory entityFactory = new EntityFactory();

            List<Entity> entities = new List<Entity>();

            entities.Add(entityFactory["Entity 1"]);
            entities.Add(entityFactory["Entity 1"]);
            entities.Add(entityFactory["Entity 1"]);
            entities.Add(entityFactory["Entity 2"]);
            entities.Add(entityFactory["Entity 2"]);
            entities.Add(entityFactory["Entity 2"]);
            entities.Add(entityFactory["Entity 3"]);
            entities.Add(entityFactory["Entity 3"]);
            entities.Add(entityFactory["Entity 3"]);

            foreach (Entity entity in entities)
            {
                Console.WriteLine(entity.GetHashCode());
                entity.Action();
            }
        }
    }

    public abstract class Entity
    {
        public Entity(string state) => State = state;

        public string State { get; }

        public abstract void Action();
    }
    public class Entity1 : Entity
    {
        public Entity1() : base("Entity 1") { }

        public override void Action() => Console.WriteLine("Entity 1 Action");
    }
    public class Entity2 : Entity
    {
        public Entity2() : base("Entity 2") { }

        public override void Action() => Console.WriteLine("Entity 2 Action");
    }
    public class Entity3 : Entity
    {
        public Entity3() : base("Entity 3") { }

        public override void Action() => Console.WriteLine("Entity 3 Action");
    }
    public class EntityFactory
    {
        private Dictionary<string, Entity> entities = new Dictionary<string, Entity>();

        public Entity this[string state]
        {
            get
            {
                if (!entities.ContainsKey(state))
                {
                    switch (state)
                    {
                        case "Entity 1":
                            entities.Add("Entity 1", new Entity1());
                            break;
                        case "Entity 2":
                            entities.Add("Entity 2", new Entity2());
                            break;
                        case "Entity 3":
                            entities.Add("Entity 3", new Entity3());
                            break;
                        default:
                            break;
                    }
                }
                return entities[state];
            }
        }
    }
}