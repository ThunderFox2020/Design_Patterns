using System;

namespace Design_Patterns.Structural_Patterns.Decorator.Concrete
{
    public class Tester
    {
        public void Test()
        {
            SpiderMan spiderMan1 = new PeterParker();
            spiderMan1.UseGadget();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            SpiderMan spiderMan2 = new PeterParker();
            spiderMan2 = new WebBomb(spiderMan2);
            spiderMan2.UseGadget();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            SpiderMan spiderMan3 = new PeterParker();
            spiderMan3 = new WebBomb(spiderMan3);
            spiderMan3 = new ImpactWeb(spiderMan3);
            spiderMan3.UseGadget();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            SpiderMan spiderMan4 = new PeterParker();
            spiderMan4 = new WebBomb(spiderMan4);
            spiderMan4 = new ImpactWeb(spiderMan4);
            spiderMan4 = new ElectricWeb(spiderMan4);
            spiderMan4.UseGadget();
        }
    }

    public abstract class SpiderMan
    {
        public abstract void UseGadget();
    }
    public class PeterParker : SpiderMan
    {
        public override void UseGadget()
        {
            Console.WriteLine("Use A Web Shooters");
            Console.WriteLine();
        }
    }

    public abstract class GadgetEquiper : SpiderMan
    {
        public GadgetEquiper(SpiderMan spiderMan) => this.spiderMan = spiderMan;

        private protected SpiderMan spiderMan;

        public override void UseGadget()
        {
            spiderMan.UseGadget();
            Console.WriteLine();
        }
    }
    public class WebBomb : GadgetEquiper
    {
        public WebBomb(SpiderMan spiderMan) : base(spiderMan) { }

        public override void UseGadget()
        {
            spiderMan.UseGadget();
            Console.WriteLine("Use A Web Bombs");
            Console.WriteLine();
        }
    }
    public class ImpactWeb : GadgetEquiper
    {
        public ImpactWeb(SpiderMan spiderMan) : base(spiderMan) { }

        public override void UseGadget()
        {
            spiderMan.UseGadget();
            Console.WriteLine("Use An Impact Web");
            Console.WriteLine();
        }
    }
    public class ElectricWeb : GadgetEquiper
    {
        public ElectricWeb(SpiderMan spiderMan) : base(spiderMan) { }

        public override void UseGadget()
        {
            spiderMan.UseGadget();
            Console.WriteLine("Use An Electric Web");
            Console.WriteLine();
        }
    }
}