using System;
using System.Collections.Generic;

namespace Design_Patterns.Behavior_Patterns.Memento.Concrete
{
    public class Tester
    {
        public void Test()
        {
            AudioPlayer audioPlayer = new AudioPlayer();
            AudioMomentsKeeper audioMomentsKeeper = new AudioMomentsKeeper();

            audioPlayer.Time = new TimeSpan(0, 1, 0);
            Console.WriteLine(audioPlayer.Time);

            audioMomentsKeeper.AudioMoments.Add(audioPlayer.SaveMoment());

            audioPlayer.Time = new TimeSpan(0, 2, 0);
            Console.WriteLine(audioPlayer.Time);

            audioPlayer.LoadMoment(audioMomentsKeeper.AudioMoments[0]);

            Console.WriteLine(audioPlayer.Time);
        }
    }

    public class AudioPlayer
    {
        public TimeSpan Time { get; set; }

        public AudioMoment SaveMoment() => new AudioMoment(Time);
        public void LoadMoment(AudioMoment audioMoment) => Time = audioMoment.Time;
    }
    public class AudioMoment
    {
        public AudioMoment(TimeSpan time) => Time = time;

        public TimeSpan Time { get; }
    }
    public class AudioMomentsKeeper
    {
        public List<AudioMoment> AudioMoments { get; } = new List<AudioMoment>();
    }
}