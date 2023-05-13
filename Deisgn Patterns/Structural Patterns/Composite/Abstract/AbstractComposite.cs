using System;
using System.Collections.Generic;

namespace Design_Patterns.Structural_Patterns.Composite.Abstract
{
    public class Tester
    {
        public void Test()
        {
            Element element1 = new Element("Element 1");
            Element element2 = new Element("Element 2");
            Element element3 = new Element("Element 3");
            Element element4 = new Element("Element 4");
            Element element5 = new Element("Element 5");
            Element element6 = new Element("Element 6");
            Element element7 = new Element("Element 7");
            Element element8 = new Element("Element 8");
            Element element9 = new Element("Element 9");

            Container container1 = new Container("Container 1");
            Container container2 = new Container("Container 2");
            Container container3 = new Container("Container 3");

            container1.Add(element1);
            container1.Add(element2);
            container1.Add(element3);
            container2.Add(element4);
            container2.Add(element5);
            container2.Add(element6);
            container3.Add(element7);
            container3.Add(element8);
            container3.Add(element9);

            container1.Add(container2);
            container1.Add(container3);

            container1.Display();
            Console.WriteLine();
            container2.Display();
            Console.WriteLine();
            container3.Display();
        }
    }

    public abstract class Entity
    {
        public Entity(string name) => Name = name;

        public string Name { get; set; }

        public abstract void Display();
    }
    public class Container : Entity
    {
        public Container(string name) : base(name) { }

        private List<Entity> entities = new List<Entity>();

        public void Add(Entity entity) => entities.Add(entity);
        public void Delete(Entity entity) => entities.Remove(entity);
        public override void Display()
        {
            Console.WriteLine(Name);
            foreach (Entity entity in entities)
                entity.Display();
        }
    }
    public class Element : Entity
    {
        public Element(string name) : base(name) { }

        public override void Display() => Console.WriteLine(Name);
    }
}