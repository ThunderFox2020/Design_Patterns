using System;

namespace Design_Patterns.Generative_Patterns.Abstract_Factory.Concrete
{
    public class Tester
    {
        public void Test()
        {
            Build build;
            CPU cpu;
            GPU gpu;

            build = new Low();
            cpu = build.CreateCPU();
            gpu = build.CreateGPU();
            Console.WriteLine(cpu);
            Console.WriteLine(gpu);

            build = new Middle();
            cpu = build.CreateCPU();
            gpu = build.CreateGPU();
            Console.WriteLine(cpu);
            Console.WriteLine(gpu);
        }
    }

    public abstract class CPU { }
    public class Corei3 : CPU { }
    public class Corei5 : CPU { }

    public abstract class GPU { }
    public class RTX3060 : GPU { }
    public class RTX3070 : GPU { }

    public abstract class Build
    {
        public abstract CPU CreateCPU();
        public abstract GPU CreateGPU();
    }
    public class Low : Build
    {
        public override CPU CreateCPU() => new Corei3();
        public override GPU CreateGPU() => new RTX3060();
    }
    public class Middle : Build
    {
        public override CPU CreateCPU() => new Corei5();
        public override GPU CreateGPU() => new RTX3070();
    }
}