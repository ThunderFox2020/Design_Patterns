using System;

namespace Design_Patterns.Structural_Patterns.Adapter.Concrete
{
    public class Tester
    {
        public void Test()
        {
            Display display = new Display();
            HDMI hdmi = new HDMI();
            display.ImageOutput(hdmi);

            VGA vga = new VGA();
            Adapter adapter = new Adapter(vga);
            display.ImageOutput(adapter);
        }
    }

    public class VGA
    {
        public void AnalogSignal() => Console.WriteLine("Analog Signal");
    }
    public class Adapter : HDMI
    {
        public Adapter(VGA vga) => this.vga = vga;

        private VGA vga;

        public override void DigitalSignal() => vga.AnalogSignal();
    }
    public class HDMI
    {
        public virtual void DigitalSignal() => Console.WriteLine("Digital Signal");
    }
    public class Display
    {
        public void ImageOutput(HDMI hdmi) => hdmi.DigitalSignal();
    }
}