using System;

namespace Design_Patterns.Behavior_Patterns.Visitor.Concrete
{
    public class Tester
    {
        public void Test()
        {
            PSD psd = new PSD();
            PNG png = new PNG();
            JPG jpg = new JPG();

            ToPSD toPSD = new ToPSD();
            ToPNG toPNG = new ToPNG();
            ToJPG toJPG = new ToJPG();

            psd.Receive(toPSD);
            psd.Receive(toPNG);
            psd.Receive(toJPG);
            Console.WriteLine();
            png.Receive(toPSD);
            png.Receive(toPNG);
            png.Receive(toJPG);
            Console.WriteLine();
            jpg.Receive(toPSD);
            jpg.Receive(toPNG);
            jpg.Receive(toJPG);
        }
    }

    public interface IVisitor
    {
        public void FromPSD(PSD psd);
        public void FromPNG(PNG png);
        public void FromJPG(JPG jpg);
    }
    public class ToPSD : IVisitor
    {
        public void FromPSD(PSD psd) => Console.WriteLine($"Convert From {psd} To PSD");
        public void FromPNG(PNG png) => Console.WriteLine($"Convert From {png} To PSD");
        public void FromJPG(JPG jpg) => Console.WriteLine($"Convert From {jpg} To PSD");
    }
    public class ToPNG : IVisitor
    {
        public void FromPSD(PSD psd) => Console.WriteLine($"Convert From {psd} To PNG");
        public void FromPNG(PNG png) => Console.WriteLine($"Convert From {png} To PNG");
        public void FromJPG(JPG jpg) => Console.WriteLine($"Convert From {jpg} To PNG");
    }
    public class ToJPG : IVisitor
    {
        public void FromPSD(PSD psd) => Console.WriteLine($"Convert From {psd} To JPG");
        public void FromPNG(PNG png) => Console.WriteLine($"Convert From {png} To JPG");
        public void FromJPG(JPG jpg) => Console.WriteLine($"Convert From {jpg} To JPG");
    }

    public interface IExtensible
    {
        public void Receive(IVisitor visitor);
    }
    public class PSD : IExtensible
    {
        public void Receive(IVisitor visitor) => visitor.FromPSD(this);
    }
    public class PNG : IExtensible
    {
        public void Receive(IVisitor visitor) => visitor.FromPNG(this);
    }
    public class JPG : IExtensible
    {
        public void Receive(IVisitor visitor) => visitor.FromJPG(this);
    }
}