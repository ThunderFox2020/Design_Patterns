using System;
using System.Collections.Generic;

namespace Design_Patterns.Behavior_Patterns.Observer.Abstract
{
    public class Tester
    {
        public void Test()
        {
            Observable observable = new Observable();
            observable.AddObserver(new Observer());
            observable.AddObserver(new Observer());
            observable.ChangeState();
        }
    }

    public interface IObservable
    {
        public void AddObserver(IObserver observer);
        public void RemoveObserver(IObserver observer);
        public void Notify(Info info);
    }
    public class Observable : IObservable
    {
        private List<IObserver> observers = new List<IObserver>();

        public void AddObserver(IObserver observer) => observers.Add(observer);
        public void RemoveObserver(IObserver observer) => observers.Remove(observer);
        public void Notify(Info info)
        {
            foreach (IObserver observer in observers)
                observer.Notify(info);
        }
        public void ChangeState() => Notify(new Info(this));
    }

    public interface IObserver
    {
        public void AddObservable(IObservable observable);
        public void RemoveObservable(IObservable observable);
        public void Notify(Info info);
    }
    public class Observer : IObserver
    {
        private List<IObservable> observables = new List<IObservable>();

        public void AddObservable(IObservable observable)
        {
            observables.Add(observable);
            observable.AddObserver(this);
        }
        public void RemoveObservable(IObservable observable)
        {
            observables.Remove(observable);
            observable.RemoveObserver(this);
        }
        public void Notify(Info info) => Console.WriteLine($"Received a notification from object {info.Sender}");
    }

    public class Info
    {
        public Info(object sender) => Sender = sender;

        public object Sender { get; }
    }
}