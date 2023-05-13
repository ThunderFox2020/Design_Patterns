using System;

namespace Design_Patterns.Structural_Patterns.Decorator.Abstract
{
    public class Tester
    {
        public void Test()
        {
            AbstractEntity entity1 = new ConcreteEntity();
            entity1.Action();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            AbstractEntity entity2 = new ConcreteEntity();
            entity2 = new ConcreteDecorator1(entity2);
            entity2.Action();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            AbstractEntity entity3 = new ConcreteEntity();
            entity3 = new ConcreteDecorator1(entity3);
            entity3 = new ConcreteDecorator2(entity3);
            entity3.Action();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            AbstractEntity entity4 = new ConcreteEntity();
            entity4 = new ConcreteDecorator1(entity4);
            entity4 = new ConcreteDecorator2(entity4);
            entity4 = new ConcreteDecorator3(entity4);
            entity4.Action();
        }
    }

    public abstract class AbstractEntity
    {
        public virtual void Action()
        {
            Console.WriteLine("Abstract Entity");
            Console.WriteLine();
        }
    }
    public class ConcreteEntity : AbstractEntity
    {
        public override void Action()
        {
            Console.WriteLine("Concrete Entity");
            Console.WriteLine();
        }
    }

    public abstract class AbstractDecorator : AbstractEntity
    {
        public AbstractDecorator(AbstractEntity abstractEntity) => this.abstractEntity = abstractEntity;

        private protected AbstractEntity abstractEntity;

        public override void Action()
        {
            abstractEntity.Action();
            Console.WriteLine("Abstract Decorator");
            Console.WriteLine();
        }
    }
    public class ConcreteDecorator1 : AbstractDecorator
    {
        public ConcreteDecorator1(AbstractEntity abstractEntity) : base(abstractEntity) { }

        public override void Action()
        {
            abstractEntity.Action();
            Console.WriteLine("Concrete Decorator 1");
            Console.WriteLine();
        }
    }
    public class ConcreteDecorator2 : AbstractDecorator
    {
        public ConcreteDecorator2(AbstractEntity abstractEntity) : base(abstractEntity) { }

        public override void Action()
        {
            abstractEntity.Action();
            Console.WriteLine("Concrete Decorator 2");
            Console.WriteLine();
        }
    }
    public class ConcreteDecorator3 : AbstractDecorator
    {
        public ConcreteDecorator3(AbstractEntity abstractEntity) : base(abstractEntity) { }

        public override void Action()
        {
            abstractEntity.Action();
            Console.WriteLine("Concrete Decorator 3");
            Console.WriteLine();
        }
    }
}