using System;
using System.Collections.Generic;

namespace Design_Patterns.Structural_Patterns.Flyweight.Concrete
{
    public class Tester
    {
        public void Test()
        {
            PixelFactory pixelFactory = new PixelFactory();

            List<Pixel> pixels = new List<Pixel>();

            pixels.Add(pixelFactory["Red"]);
            pixels.Add(pixelFactory["Red"]);
            pixels.Add(pixelFactory["Red"]);
            pixels.Add(pixelFactory["Green"]);
            pixels.Add(pixelFactory["Green"]);
            pixels.Add(pixelFactory["Green"]);
            pixels.Add(pixelFactory["Blue"]);
            pixels.Add(pixelFactory["Blue"]);
            pixels.Add(pixelFactory["Blue"]);

            Random random = new Random();

            foreach (Pixel pixel in pixels)
            {
                Console.WriteLine(pixel.GetHashCode());
                pixel.Draw(random.Next(0, 100), random.Next(0, 100));
            }
        }
    }

    public abstract class Pixel
    {
        public Pixel(string color) => Color = color;

        public string Color { get; }

        public abstract void Draw(int x, int y);
    }
    public class Red : Pixel
    {
        public Red() : base("Red") { }

        public override void Draw(int x, int y) => Console.WriteLine($"A Red Pixel Is Drawn At A Point With Coordinates ({x}, {y})");
    }
    public class Green : Pixel
    {
        public Green() : base("Green") { }

        public override void Draw(int x, int y) => Console.WriteLine($"A Green Pixel Is Drawn At A Point With Coordinates ({x}, {y})");
    }
    public class Blue : Pixel
    {
        public Blue() : base("Blue") { }

        public override void Draw(int x, int y) => Console.WriteLine($"A Blue Pixel Is Drawn At A Point With Coordinates ({x}, {y})");
    }
    public class PixelFactory
    {
        private Dictionary<string, Pixel> pixels = new Dictionary<string, Pixel>();

        public Pixel this[string color]
        {
            get
            {
                if (!pixels.ContainsKey(color))
                {
                    switch (color)
                    {
                        case "Red":
                            pixels.Add("Red", new Red());
                            break;
                        case "Green":
                            pixels.Add("Green", new Green());
                            break;
                        case "Blue":
                            pixels.Add("Blue", new Blue());
                            break;
                        default:
                            break;
                    }
                }
                return pixels[color];
            }
        }
    }
}