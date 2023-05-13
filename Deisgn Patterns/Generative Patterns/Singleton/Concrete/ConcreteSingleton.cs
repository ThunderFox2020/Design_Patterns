using System;

namespace Design_Patterns.Generative_Patterns.Singleton.Concrete
{
    public class Tester
    {
        public void Test()
        {
            CPU cpu;
            cpu = CPU.GetCPU("Core i3");
            Console.WriteLine(cpu.Model);
            cpu = CPU.GetCPU("Core i5");
            Console.WriteLine(cpu.Model);
        }
    }

    public class CPU
    {
        private CPU(string model) => Model = model;

        private static CPU cpu;
        private static object locker = new object();

        public string Model { get; set; }

        public static CPU GetCPU(string model)
        {
            if (cpu == null)
            {
                lock (locker)
                {
                    if (cpu == null)
                        cpu = new CPU(model);
                }
            }
            return cpu;
        }
    }
}