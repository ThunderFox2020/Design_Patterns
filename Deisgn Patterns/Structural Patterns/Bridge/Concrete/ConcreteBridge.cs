using System;

namespace Design_Patterns.Structural_Patterns.Bridge.Concrete
{
    public class Tester
    {
        public void Test()
        {
            Computer desktop = new Desktop(new Integrated());
            desktop.ImageOutput();
            desktop.EnableSLI();
            desktop.VideoCard = new Discrete();
            desktop.ImageOutput();
            desktop.EnableSLI();

            Console.WriteLine();

            Computer notebook = new Notebook(new Integrated());
            notebook.ImageOutput();
            notebook.EnableSLI();
            notebook.VideoCard = new Discrete();
            notebook.ImageOutput();
            notebook.EnableSLI();
        }
    }

    public abstract class Computer
    {
        public Computer(VideoCard videoCard) => VideoCard = videoCard;

        public VideoCard VideoCard { private get; set; }

        public void ImageOutput() => VideoCard.ImageOutput();
        public abstract void EnableSLI();
    }
    public class Desktop : Computer
    {
        public Desktop(VideoCard videoCard) : base(videoCard) { }

        public override void EnableSLI() => Console.WriteLine("SLI Enabled");
    }
    public class Notebook : Computer
    {
        public Notebook(VideoCard videoCard) : base(videoCard) { }

        public override void EnableSLI() => Console.WriteLine("SLI Is Not Supported");
    }

    public abstract class VideoCard
    {
        public abstract void ImageOutput();
    }
    public class Integrated : VideoCard
    {
        public override void ImageOutput() => Console.WriteLine("The Image Is Output From An Integrated Videocard");
    }
    public class Discrete : VideoCard
    {
        public override void ImageOutput() => Console.WriteLine("The Image Is Output From A Discrete Videocard");
    }
}