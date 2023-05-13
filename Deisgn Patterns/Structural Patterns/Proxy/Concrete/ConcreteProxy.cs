using System;

namespace Design_Patterns.Structural_Patterns.Proxy.Concrete
{
    public class Tester
    {
        public void Test()
        {
            IGamePad dualShock = new DualShock();
            dualShock.UseGamePad();

            Console.WriteLine();

            IGamePad dualSence = new DualSence() { IsSupported = true };
            dualSence.UseGamePad();
        }
    }

    public interface IGamePad
    {
        public void UseGamePad();
    }
    public class DualShock : IGamePad
    {
        public void UseGamePad()
        {
            Console.WriteLine("GamePad Are Used");
            UseVibrationMotors();
        }
        private void UseVibrationMotors() => Console.WriteLine("Vibration Motors Are Involved");
    }
    public class DualSence : IGamePad
    {
        private DualShock dualShock = new DualShock();

        public bool IsSupported { get; set; } = false;

        public void UseGamePad()
        {
            dualShock.UseGamePad();
            if (IsSupported)
                UseAdaptiveTriggers();
        }
        private void UseAdaptiveTriggers() => Console.WriteLine("Adaptive Triggers Are Involved");
    }
}