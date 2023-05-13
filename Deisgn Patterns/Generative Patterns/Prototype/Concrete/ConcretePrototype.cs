using System;

namespace Design_Patterns.Generative_Patterns.Prototype.Concrete
{
    public class Tester
    {
        public void Test()
        {
            CPU cpu = new CPU("Core i3", "10");
            GPU gpu = new GPU("RTX 3060", "Ampere");
            CPU cloneCPU = cpu.Clone() as CPU;
            GPU cloneGPU = gpu.Clone() as GPU;
            Console.WriteLine($"{cpu.Model} - {cpu.Generation}");
            Console.WriteLine($"{gpu.Model} - {gpu.Microarchitecture}");
            Console.WriteLine($"{cloneCPU.Model} - {cloneCPU.Generation}");
            Console.WriteLine($"{cloneGPU.Model} - {cloneGPU.Microarchitecture}");
        }
    }

    public abstract class Prototype
    {
        public abstract Prototype Clone();
    }
    public class CPU : Prototype
    {
        public CPU(string model, string generation)
        {
            Model = model;
            Generation = generation;
        }

        public string Model { get; set; }
        public string Generation { get; set; }

        public override Prototype Clone() => new CPU(Model, Generation);
    }
    public class GPU : Prototype
    {
        public GPU(string model, string microarchitecture)
        {
            Model = model;
            Microarchitecture = microarchitecture;
        }

        public string Model { get; set; }
        public string Microarchitecture { get; set; }

        public override Prototype Clone() => new GPU(Model, Microarchitecture);
    }
}