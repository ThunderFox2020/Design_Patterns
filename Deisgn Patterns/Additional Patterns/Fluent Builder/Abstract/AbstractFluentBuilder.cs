using System;

namespace Design_Patterns.Additional_Patterns.Fluent_Builder.Abstract
{
    public class Tester
    {
        public void Test()
        {
            Entity entity1 = new Entity() { Property1 = 1, Property2 = 2, Property3 = 3, Property4 = 4, Property5 = 5 };
            Entity entity2 = new EntityBuilder().SetProperty1(1).SetProperty2(2).SetProperty3(3).SetProperty4(4).SetProperty5(5).BuildEntity();

            Console.WriteLine($"{entity1.Property1} - {entity1.Property2} - {entity1.Property3} - {entity1.Property4} - {entity1.Property5}");
            Console.WriteLine($"{entity2.Property1} - {entity2.Property2} - {entity2.Property3} - {entity2.Property4} - {entity2.Property5}");
        }
    }

    public class Entity
    {
        public int Property1 { get; set; }
        public int Property2 { get; set; }
        public int Property3 { get; set; }
        public int Property4 { get; set; }
        public int Property5 { get; set; }
    }
    public class EntityBuilder
    {
        private Entity entity = new Entity();

        public EntityBuilder SetProperty1(int property1)
        {
            entity.Property1 = property1;
            return this;
        }
        public EntityBuilder SetProperty2(int property2)
        {
            entity.Property2 = property2;
            return this;
        }
        public EntityBuilder SetProperty3(int property3)
        {
            entity.Property3 = property3;
            return this;
        }
        public EntityBuilder SetProperty4(int property4)
        {
            entity.Property4 = property4;
            return this;
        }
        public EntityBuilder SetProperty5(int property5)
        {
            entity.Property5 = property5;
            return this;
        }
        public Entity BuildEntity() => entity;
    }
}