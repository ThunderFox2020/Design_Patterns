using System;

namespace Design_Patterns.Generative_Patterns.Builder.Abstract
{
    public class Tester
    {
        public void Test()
        {
            Director director;
            Entity entity;

            director = new Director(new EntityBuilder1());
            director.Build();
            entity = director.Result;
            Console.WriteLine(entity);
            Console.WriteLine(entity.Part1);
            Console.WriteLine(entity.Part2);

            director = new Director(new EntityBuilder2());
            director.Build();
            entity = director.Result;
            Console.WriteLine(entity);
            Console.WriteLine(entity.Part1);
            Console.WriteLine(entity.Part2);
        }
    }

    public class Entity
    {
        public int Part1 { get; set; }
        public int Part2 { get; set; }
    }

    public class Director
    {
        public Director(EntityBuilder entityBuilder) => EntityBuilder = entityBuilder;

        public EntityBuilder EntityBuilder { get; set; }
        public Entity Result { get => EntityBuilder.Entity; }

        public void Build()
        {
            EntityBuilder.BuildPart1();
            EntityBuilder.BuildPart2();
        }
    }

    public abstract class EntityBuilder
    {
        public abstract Entity Entity { get; }

        public abstract void BuildPart1();
        public abstract void BuildPart2();
    }
    public class EntityBuilder1 : EntityBuilder
    {
        public override Entity Entity { get; } = new Entity();

        public override void BuildPart1() => Entity.Part1 = 1;
        public override void BuildPart2() => Entity.Part2 = 2;
    }
    public class EntityBuilder2 : EntityBuilder
    {
        public override Entity Entity { get; } = new Entity();

        public override void BuildPart1() => Entity.Part1 = 3;
        public override void BuildPart2() => Entity.Part2 = 4;
    }
}