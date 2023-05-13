using System;

namespace Design_Patterns.Behavior_Patterns.State.Concrete
{
    public class Tester
    {
        public void Test()
        {
            Water water = new Water(new Liquid(50));

            Console.WriteLine(water.WaterState);
            Console.WriteLine(water.Temperature);
            water.Cooling(25);
            Console.WriteLine(water.WaterState);
            Console.WriteLine(water.Temperature);
            water.Cooling(25);
            Console.WriteLine(water.WaterState);
            Console.WriteLine(water.Temperature);
            water.Cooling(25);
            Console.WriteLine(water.WaterState);
            Console.WriteLine(water.Temperature);
            water.Cooling(25);
            Console.WriteLine(water.WaterState);
            Console.WriteLine(water.Temperature);
            water.Heating(25);
            Console.WriteLine(water.WaterState);
            Console.WriteLine(water.Temperature);
            water.Heating(25);
            Console.WriteLine(water.WaterState);
            Console.WriteLine(water.Temperature);
            water.Heating(25);
            Console.WriteLine(water.WaterState);
            Console.WriteLine(water.Temperature);
            water.Heating(25);
            Console.WriteLine(water.WaterState);
            Console.WriteLine(water.Temperature);
            water.Heating(25);
            Console.WriteLine(water.WaterState);
            Console.WriteLine(water.Temperature);
            water.Heating(25);
            Console.WriteLine(water.WaterState);
            Console.WriteLine(water.Temperature);
            water.Heating(25);
            Console.WriteLine(water.WaterState);
            Console.WriteLine(water.Temperature);
            water.Heating(25);
            Console.WriteLine(water.WaterState);
            Console.WriteLine(water.Temperature);
            water.Cooling(25);
            Console.WriteLine(water.WaterState);
            Console.WriteLine(water.Temperature);
            water.Cooling(25);
            Console.WriteLine(water.WaterState);
            Console.WriteLine(water.Temperature);
            water.Cooling(25);
            Console.WriteLine(water.WaterState);
            Console.WriteLine(water.Temperature);
            water.Cooling(25);
            Console.WriteLine(water.WaterState);
            Console.WriteLine(water.Temperature);
        }
    }

    public abstract class WaterState
    {
        public WaterState(int temperature) => Temperature = temperature;

        public int Temperature { get; private protected set; }

        public abstract void Cooling(int degree, Water water);
        public abstract void Heating(int degree, Water water);
    }
    public class Solid : WaterState
    {
        public Solid(int temperature) : base(temperature) { }

        public override void Cooling(int degree, Water water)
        {
            Temperature -= degree;
        }
        public override void Heating(int degree, Water water)
        {
            Temperature += degree;
            if (Temperature >= 0)
                water.WaterState = new Liquid(Temperature);
        }
    }
    public class Liquid : WaterState
    {
        public Liquid(int temperature) : base(temperature) { }

        public override void Cooling(int degree, Water water)
        {
            Temperature -= degree;
            if (Temperature <= 0)
                water.WaterState = new Solid(Temperature);
        }
        public override void Heating(int degree, Water water)
        {
            Temperature += degree;
            if (Temperature >= 100)
                water.WaterState = new Gaseous(Temperature);
        }
    }
    public class Gaseous : WaterState
    {
        public Gaseous(int temperature) : base(temperature) { }

        public override void Cooling(int degree, Water water)
        {
            Temperature -= degree;
            if (Temperature <= 100)
                water.WaterState = new Liquid(Temperature);
        }
        public override void Heating(int degree, Water water)
        {
            Temperature += degree;
        }
    }

    public class Water
    {
        public Water(WaterState waterState) => WaterState = waterState;

        public WaterState WaterState { get; set; }
        public int Temperature { get => WaterState.Temperature; }

        public void Cooling(int degree) => WaterState.Cooling(degree, this);
        public void Heating(int degree) => WaterState.Heating(degree, this);
    }
}