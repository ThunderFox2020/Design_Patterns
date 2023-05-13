using System;

namespace Design_Patterns.Behavior_Patterns.Strategy.Abstract
{
    public class Tester
    {
        public void Test()
        {
            StrategyUser strategyUser = new StrategyUser(new Strategy1());
            strategyUser.UseStrategy();

            strategyUser.Strategy = new Strategy2();
            strategyUser.UseStrategy();
        }
    }

    public class StrategyUser
    {
        public StrategyUser(IStrategy strategy) => Strategy = strategy;

        public IStrategy Strategy { get; set; }

        public void UseStrategy() => Strategy.Algorithm();
    }

    public interface IStrategy
    {
        public void Algorithm();
    }
    public class Strategy1 : IStrategy
    {
        public void Algorithm() => Console.WriteLine("Strategy 1");
    }
    public class Strategy2 : IStrategy
    {
        public void Algorithm() => Console.WriteLine("Strategy 2");
    }
}