using System;

namespace Design_Patterns.Behavior_Patterns.Mediator.Concrete
{
    public class Tester
    {
        public void Test()
        {
            CPU cpu = new CPU();

            AdobeAudition adobeAudition = new AdobeAudition(cpu);
            AdobePhotoshop adobePhotoshop = new AdobePhotoshop(cpu);
            AudioCard audioCard = new AudioCard(cpu);
            VideoCard videoCard = new VideoCard(cpu);

            cpu.AdobeAudition = adobeAudition;
            cpu.AdobePhotoshop = adobePhotoshop;
            cpu.AudioCard = audioCard;
            cpu.VideoCard = videoCard;

            adobeAudition.Send("Process Audio");
            adobePhotoshop.Send("Process Video");
            audioCard.Send("Audio Processed");
            videoCard.Send("Video Processed");
        }
    }

    public abstract class Mediator
    {
        public abstract void Send(Member from, string message);
    }
    public abstract class Member
    {
        public Member(Mediator mediator) => this.mediator = mediator;

        private protected Mediator mediator;

        public abstract void Send(string message);
        public abstract void Receive(string message);
    }

    public class CPU : Mediator
    {
        public AdobeAudition AdobeAudition { get; set; }
        public AdobePhotoshop AdobePhotoshop { get; set; }
        public AudioCard AudioCard { get; set; }
        public VideoCard VideoCard { get; set; }

        public override void Send(Member from, string data)
        {
            if (from == AdobeAudition)
                AudioCard.Receive(data);
            if (from == AdobePhotoshop)
                VideoCard.Receive(data);
            if (from == AudioCard)
                AdobeAudition.Receive(data);
            if (from == VideoCard)
                AdobePhotoshop.Receive(data);
        }
    }
    public class AdobeAudition : Member
    {
        public AdobeAudition(CPU cpu) : base(cpu) { }

        public override void Send(string data) => mediator.Send(this, data);
        public override void Receive(string data) => Console.WriteLine($"Adobe Audition Got: {data}");
    }
    public class AdobePhotoshop : Member
    {
        public AdobePhotoshop(CPU cpu) : base(cpu) { }

        public override void Send(string data) => mediator.Send(this, data);
        public override void Receive(string data) => Console.WriteLine($"Adobe Photoshop Got: {data}");
    }
    public class AudioCard : Member
    {
        public AudioCard(CPU cpu) : base(cpu) { }

        public override void Send(string data) => mediator.Send(this, data);
        public override void Receive(string data) => Console.WriteLine($"Audio Card Got: {data}");
    }
    public class VideoCard : Member
    {
        public VideoCard(CPU cpu) : base(cpu) { }

        public override void Send(string data) => mediator.Send(this, data);
        public override void Receive(string data) => Console.WriteLine($"Video Card Got: {data}");
    }
}