using System;

namespace Design_Patterns.Additional_Patterns.Fluent_Builder.Concrete
{
    public class Tester
    {
        public void Test()
        {
            Computer computer1 = new Computer() { Motherboard = "Motherboard", CPU = "CPU", RAM = "RAM", SSD = "SSD", GPU = "GPU", SoundCard = "Sound Card", PowerSupply = "Power Supply" };
            Computer computer2 = new ComputerBuilder().SetMotherboard("Motherboard").SetCPU("CPU").SetRAM("RAM").SetSSD("SSD").SetGPU("GPU").SetSoundCard("Sound Card").SetPowerSupply("Power Supply").BuildComputer();

            Console.WriteLine($"{computer1.Motherboard} - {computer1.CPU} - {computer1.RAM} - {computer1.SSD} - {computer1.GPU} - {computer1.SoundCard} - {computer1.PowerSupply}");
            Console.WriteLine($"{computer2.Motherboard} - {computer2.CPU} - {computer2.RAM} - {computer2.SSD} - {computer2.GPU} - {computer2.SoundCard} - {computer2.PowerSupply}");
        }
    }

    public class Computer
    {
        public string Motherboard { get; set; }
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string SSD { get; set; }
        public string GPU { get; set; }
        public string SoundCard { get; set; }
        public string PowerSupply { get; set; }
    }
    public class ComputerBuilder
    {
        private Computer computer = new Computer();

        public ComputerBuilder SetMotherboard(string motherboard)
        {
            computer.Motherboard = motherboard;
            return this;
        }
        public ComputerBuilder SetCPU(string cpu)
        {
            computer.CPU = cpu;
            return this;
        }
        public ComputerBuilder SetRAM(string ram)
        {
            computer.RAM = ram;
            return this;
        }
        public ComputerBuilder SetSSD(string ssd)
        {
            computer.SSD = ssd;
            return this;
        }
        public ComputerBuilder SetGPU(string gpu)
        {
            computer.GPU = gpu;
            return this;
        }
        public ComputerBuilder SetSoundCard(string soundCard)
        {
            computer.SoundCard = soundCard;
            return this;
        }
        public ComputerBuilder SetPowerSupply(string powerSupply)
        {
            computer.PowerSupply = powerSupply;
            return this;
        }
        public Computer BuildComputer() => computer;
    }
}