using System;
using System.Collections.Generic;

namespace Design_Patterns.Behavior_Patterns.Observer.Concrete
{
    public class Tester
    {
        public void Test()
        {
            Channel channel = new Channel();
            channel.AddObserver(new Subscriber());
            channel.AddObserver(new Subscriber());
            channel.CreateVideo();
        }
    }

    public interface IObservable
    {
        public void AddObserver(IObserver observer);
        public void RemoveObserver(IObserver observer);
        public void Notify(Info info);
    }
    public class Channel : IObservable
    {
        private List<IObserver> subscribers = new List<IObserver>();

        public void AddObserver(IObserver subscriber) => subscribers.Add(subscriber);
        public void RemoveObserver(IObserver subscriber) => subscribers.Remove(subscriber);
        public void Notify(Info video)
        {
            foreach (IObserver subscriber in subscribers)
                subscriber.Notify(video);
        }
        public void CreateVideo() => Notify(new Info(this));
    }

    public interface IObserver
    {
        public void AddObservable(IObservable observable);
        public void RemoveObservable(IObservable observable);
        public void Notify(Info info);
    }
    public class Subscriber : IObserver
    {
        private List<IObservable> channels = new List<IObservable>();

        public void AddObservable(IObservable channel)
        {
            channels.Add(channel);
            channel.AddObserver(this);
        }
        public void RemoveObservable(IObservable channel)
        {
            channels.Remove(channel);
            channel.RemoveObserver(this);
        }
        public void Notify(Info video) => Console.WriteLine($"The {video.Sender} has released a new video");
    }

    public class Info
    {
        public Info(object sender) => Sender = sender;

        public object Sender { get; }
    }
}