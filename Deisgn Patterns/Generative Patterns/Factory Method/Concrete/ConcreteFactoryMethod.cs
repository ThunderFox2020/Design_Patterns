using System;

namespace Design_Patterns.Generative_Patterns.Factory_Method.Concrete
{
    public class Tester
    {
        public void Test()
        {
            CPUFactory cpuFactory;
            CPU cpu;

            cpuFactory = new Corei3Factory();
            cpu = cpuFactory.CreateCPU();
            Console.WriteLine(cpu);

            cpuFactory = new Corei5Factory();
            cpu = cpuFactory.CreateCPU();
            Console.WriteLine(cpu);
        }
    }

    public abstract class CPU { }
    public class Corei3 : CPU { }
    public class Corei5 : CPU { }

    public abstract class CPUFactory
    {
        public abstract CPU CreateCPU();
    }
    public class Corei3Factory : CPUFactory
    {
        public override CPU CreateCPU() => new Corei3();
    }
    public class Corei5Factory : CPUFactory
    {
        public override CPU CreateCPU() => new Corei5();
    }
}