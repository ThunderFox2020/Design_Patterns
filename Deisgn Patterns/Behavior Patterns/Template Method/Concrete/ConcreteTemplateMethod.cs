using System;

namespace Design_Patterns.Behavior_Patterns.Template_Method.Concrete
{
    public class Tester
    {
        public void Test()
        {
            AndrewMaster andrewMaster = new AndrewMaster();
            andrewMaster.BuildComputer();
            Console.WriteLine();
            JackMaster jackMaster = new JackMaster();
            jackMaster.BuildComputer();
            Console.WriteLine();
            JohnMaster johnMaster = new JohnMaster();
            johnMaster.BuildComputer();
            Console.WriteLine();
            MichaelMaster michaelMaster = new MichaelMaster();
            michaelMaster.BuildComputer();
        }
    }

    public abstract class ComputerMaster
    {
        public void BuildComputer()
        {
            SetMotherboard();
            SetCPU();
            SetRAM();
            SetSSD();
            SetExpansionDevices();
            SetPowerSupply();
        }
        public virtual void SetMotherboard() => Console.WriteLine("Set Motherboard");
        public virtual void SetCPU() => Console.WriteLine("Set CPU");
        public virtual void SetRAM() => Console.WriteLine("Set RAM");
        public virtual void SetSSD() => Console.WriteLine("Set SSD");
        public virtual void SetExpansionDevices() => Console.WriteLine("Expansion Devices Not Setted");
        public virtual void SetPowerSupply() => Console.WriteLine("Set Power Supply");
    }
    public class AndrewMaster : ComputerMaster
    {

    }
    public class JackMaster : ComputerMaster
    {
        public override void SetExpansionDevices() => SetSoundCard();
        public void SetSoundCard() => Console.WriteLine("Set Sound Card");
    }
    public class JohnMaster : ComputerMaster
    {
        public override void SetExpansionDevices() => SetGPU();
        public void SetGPU() => Console.WriteLine("Set GPU");
    }
    public class MichaelMaster : ComputerMaster
    {
        public override void SetExpansionDevices()
        {
            SetSoundCard();
            SetGPU();
        }
        public void SetSoundCard() => Console.WriteLine("Set Sound Card");
        public void SetGPU() => Console.WriteLine("Set GPU");
    }
}