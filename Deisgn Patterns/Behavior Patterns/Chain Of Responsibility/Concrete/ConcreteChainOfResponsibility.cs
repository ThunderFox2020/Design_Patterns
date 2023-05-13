using System;

namespace Design_Patterns.Behavior_Patterns.Chain_Of_Responsibility.Concrete
{
    public class Tester
    {
        public void Test()
        {
            GeneralSupport generalSupport = new GeneralSupport();

            generalSupport.Helping(new Problem(Problem.ProblemType.Hardware, 1));
            generalSupport.Helping(new Problem(Problem.ProblemType.Hardware, 2));
            generalSupport.Helping(new Problem(Problem.ProblemType.Hardware, 3));
            generalSupport.Helping(new Problem(Problem.ProblemType.Hardware, 4));
            generalSupport.Helping(new Problem(Problem.ProblemType.Hardware, 5));
            generalSupport.Helping(new Problem(Problem.ProblemType.Hardware, 6));
            Console.WriteLine();
            generalSupport.Helping(new Problem(Problem.ProblemType.Software, 1));
            generalSupport.Helping(new Problem(Problem.ProblemType.Software, 2));
            generalSupport.Helping(new Problem(Problem.ProblemType.Software, 3));
            generalSupport.Helping(new Problem(Problem.ProblemType.Software, 4));
            generalSupport.Helping(new Problem(Problem.ProblemType.Software, 5));
            generalSupport.Helping(new Problem(Problem.ProblemType.Software, 6));
        }
    }

    public abstract class Support
    {
        public abstract Support NextSupport { get; set; }
        public abstract void Helping(Problem problem);
    }
    public class LowHardwareSupport : Support
    {
        public override Support NextSupport { get; set; } = new MiddleHardwareSupport();

        public override void Helping(Problem problem)
        {
            if (problem.Type == Problem.ProblemType.Hardware && problem.Rate <= 3)
                Console.WriteLine($"{this} | Problem solved");
            else if (problem.Type == Problem.ProblemType.Hardware)
                NextSupport.Helping(problem);
        }
    }
    public class MiddleHardwareSupport : Support
    {
        public override Support NextSupport { get; set; } = new HighHardwareSupport();

        public override void Helping(Problem problem)
        {
            if (problem.Type == Problem.ProblemType.Hardware && problem.Rate <= 4)
                Console.WriteLine($"{this} | Problem solved");
            else if (problem.Type == Problem.ProblemType.Hardware)
                NextSupport.Helping(problem);
        }
    }
    public class HighHardwareSupport : Support
    {
        public override Support NextSupport { get; set; }

        public override void Helping(Problem problem)
        {
            if (problem.Type == Problem.ProblemType.Hardware && problem.Rate <= 5)
                Console.WriteLine($"{this} | Problem solved");
        }
    }
    public class LowSoftwareSupport : Support
    {
        public override Support NextSupport { get; set; } = new MiddleSoftwareSupport();

        public override void Helping(Problem problem)
        {
            if (problem.Type == Problem.ProblemType.Software && problem.Rate <= 3)
                Console.WriteLine($"{this} | Problem solved");
            else if (problem.Type == Problem.ProblemType.Software)
                NextSupport.Helping(problem);
        }
    }
    public class MiddleSoftwareSupport : Support
    {
        public override Support NextSupport { get; set; } = new HighSoftwareSupport();

        public override void Helping(Problem problem)
        {
            if (problem.Type == Problem.ProblemType.Software && problem.Rate <= 4)
                Console.WriteLine($"{this} | Problem solved");
            else if (problem.Type == Problem.ProblemType.Software)
                NextSupport.Helping(problem);
        }
    }
    public class HighSoftwareSupport : Support
    {
        public override Support NextSupport { get; set; }

        public override void Helping(Problem problem)
        {
            if (problem.Type == Problem.ProblemType.Software && problem.Rate <= 5)
                Console.WriteLine($"{this} | Problem solved");
        }
    }
    public class GeneralSupport : Support
    {
        public override Support NextSupport { get; set; }

        public override void Helping(Problem problem)
        {
            if (problem.Rate < 3)
            {
                Console.WriteLine($"{this} | Problem solved");
            }
            else
            {
                if (problem.Type == Problem.ProblemType.Hardware)
                    NextSupport = new LowHardwareSupport();
                else if (problem.Type == Problem.ProblemType.Software)
                    NextSupport = new LowSoftwareSupport();
                NextSupport.Helping(problem);
            }
        }
    }

    public class Problem
    {
        public Problem(ProblemType type, int rate)
        {
            Type = type;
            Rate = rate;
        }

        public ProblemType Type { get; set; }
        public int Rate { get; set; }

        public enum ProblemType
        {
            Hardware,
            Software
        }
    }
}