using System;

namespace Design_Patterns.Generative_Patterns.Builder.Concrete
{
    public class Tester
    {
        public void Test()
        {
            Master master;
            Computer computer;

            master = new Master(new Low());
            master.BuildComputer();
            computer = master.Result;
            Console.WriteLine(computer);
            Console.WriteLine(computer.CPU);
            Console.WriteLine(computer.GPU);

            master = new Master(new Middle());
            master.BuildComputer();
            computer = master.Result;
            Console.WriteLine(computer);
            Console.WriteLine(computer.CPU);
            Console.WriteLine(computer.GPU);
        }
    }

    public class Computer
    {
        public string CPU { get; set; }
        public string GPU { get; set; }
    }

    public class Master
    {
        public Master(Build build) => Build = build;

        public Build Build { get; set; }
        public Computer Result { get => Build.Computer; }

        public void BuildComputer()
        {
            Build.SetCPU();
            Build.SetGPU();
        }
    }

    public abstract class Build
    {
        public abstract Computer Computer { get; }

        public abstract void SetCPU();
        public abstract void SetGPU();
    }
    public class Low : Build
    {
        public override Computer Computer { get; } = new Computer();

        public override void SetCPU() => Computer.CPU = "Core i3";
        public override void SetGPU() => Computer.GPU = "RTX 3060";
    }
    public class Middle : Build
    {
        public override Computer Computer { get; } = new Computer();

        public override void SetCPU() => Computer.CPU = "Core i5";
        public override void SetGPU() => Computer.GPU = "RTX 3070";
    }
}