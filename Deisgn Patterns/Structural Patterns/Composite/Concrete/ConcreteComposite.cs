using System;
using System.Collections.Generic;

namespace Design_Patterns.Structural_Patterns.Composite.Concrete
{
    public class Tester
    {
        public void Test()
        {
            File file1 = new File("File 1");
            File file2 = new File("File 2");
            File file3 = new File("File 3");
            File file4 = new File("File 4");
            File file5 = new File("File 5");
            File file6 = new File("File 6");
            File file7 = new File("File 7");
            File file8 = new File("File 8");
            File file9 = new File("File 9");

            Directory directory1 = new Directory("Directory 1");
            Directory directory2 = new Directory("Directory 2");
            Directory directory3 = new Directory("Directory 3");

            directory1.Add(file1);
            directory1.Add(file2);
            directory1.Add(file3);
            directory2.Add(file4);
            directory2.Add(file5);
            directory2.Add(file6);
            directory3.Add(file7);
            directory3.Add(file8);
            directory3.Add(file9);

            directory1.Add(directory2);
            directory1.Add(directory3);

            directory1.Display();
            Console.WriteLine();
            directory2.Display();
            Console.WriteLine();
            directory3.Display();
        }
    }

    public abstract class Entity
    {
        public Entity(string name) => this.name = name;

        private protected string name;

        public void ReName(string name) => this.name = name;
        public abstract void Display();
    }
    public class Directory : Entity
    {
        public Directory(string name) : base(name) { }

        private List<Entity> entities = new List<Entity>();

        public void Add(Entity entity) => entities.Add(entity);
        public void Delete(Entity entity) => entities.Remove(entity);
        public override void Display()
        {
            Console.WriteLine(name);
            foreach (Entity entity in entities)
                entity.Display();
        }
    }
    public class File : Entity
    {
        public File(string name) : base(name) { }

        public override void Display() => Console.WriteLine(name);
    }
}