using System;

namespace Design_Patterns.Behavior_Patterns.Strategy.Concrete
{
    public class Tester
    {
        public void Test()
        {
            Computer computer = new Computer(new WindowsStarter());
            computer.StartOS();

            computer.OSStarter = new LinuxStarter();
            computer.StartOS();
        }
    }

    public class Computer
    {
        public Computer(IOSStarter osStarter) => OSStarter = osStarter;

        public IOSStarter OSStarter { get; set; }

        public void StartOS() => OSStarter.StartOS();
    }

    public interface IOSStarter
    {
        public void StartOS();
    }
    public class WindowsStarter : IOSStarter
    {
        public void StartOS() => Console.WriteLine("Windows");
    }
    public class LinuxStarter : IOSStarter
    {
        public void StartOS() => Console.WriteLine("Linux");
    }
}