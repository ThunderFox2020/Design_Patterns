using System;

namespace Design_Patterns.Behavior_Patterns.Visitor.Abstract
{
    public class Tester
    {
        public void Test()
        {
            Extensible1 extensible1 = new Extensible1();
            Extensible2 extensible2 = new Extensible2();
            Extensible3 extensible3 = new Extensible3();

            Visitor1 visitor1 = new Visitor1();
            Visitor2 visitor2 = new Visitor2();
            Visitor3 visitor3 = new Visitor3();

            extensible1.Receive(visitor1);
            extensible1.Receive(visitor2);
            extensible1.Receive(visitor3);
            Console.WriteLine();
            extensible2.Receive(visitor1);
            extensible2.Receive(visitor2);
            extensible2.Receive(visitor3);
            Console.WriteLine();
            extensible3.Receive(visitor1);
            extensible3.Receive(visitor2);
            extensible3.Receive(visitor3);
        }
    }

    public interface IVisitor
    {
        public void ExtendedFunctionality1(Extensible1 extensible1);
        public void ExtendedFunctionality2(Extensible2 extensible2);
        public void ExtendedFunctionality3(Extensible3 extensible3);
    }
    public class Visitor1 : IVisitor
    {
        public void ExtendedFunctionality1(Extensible1 extensible1) => Console.WriteLine($"Extended Functionality 1 Of {extensible1}");
        public void ExtendedFunctionality2(Extensible2 extensible2) => Console.WriteLine($"Extended Functionality 1 Of {extensible2}");
        public void ExtendedFunctionality3(Extensible3 extensible3) => Console.WriteLine($"Extended Functionality 1 Of {extensible3}");
    }
    public class Visitor2 : IVisitor
    {
        public void ExtendedFunctionality1(Extensible1 extensible1) => Console.WriteLine($"Extended Functionality 2 Of {extensible1}");
        public void ExtendedFunctionality2(Extensible2 extensible2) => Console.WriteLine($"Extended Functionality 2 Of {extensible2}");
        public void ExtendedFunctionality3(Extensible3 extensible3) => Console.WriteLine($"Extended Functionality 2 Of {extensible3}");
    }
    public class Visitor3 : IVisitor
    {
        public void ExtendedFunctionality1(Extensible1 extensible1) => Console.WriteLine($"Extended Functionality 3 Of {extensible1}");
        public void ExtendedFunctionality2(Extensible2 extensible2) => Console.WriteLine($"Extended Functionality 3 Of {extensible2}");
        public void ExtendedFunctionality3(Extensible3 extensible3) => Console.WriteLine($"Extended Functionality 3 Of {extensible3}");
    }

    public interface IExtensible
    {
        public void Receive(IVisitor visitor);
    }
    public class Extensible1 : IExtensible
    {
        public void Receive(IVisitor visitor) => visitor.ExtendedFunctionality1(this);
    }
    public class Extensible2 : IExtensible
    {
        public void Receive(IVisitor visitor) => visitor.ExtendedFunctionality2(this);
    }
    public class Extensible3 : IExtensible
    {
        public void Receive(IVisitor visitor) => visitor.ExtendedFunctionality3(this);
    }
}