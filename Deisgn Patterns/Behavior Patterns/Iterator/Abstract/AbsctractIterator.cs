using System;
using System.Collections;

namespace Design_Patterns.Behavior_Patterns.Iterator.Abstract
{
    public class Tester
    {
        public void Test()
        {
            IIterable iterable = new Iterable(new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            IIterator iterator = iterable.GetIterator();
            while (iterator.Next())
                Console.WriteLine(iterator.Current);
        }
    }

    public interface IIterator
    {
        public object Current { get; }

        public bool Next();
        public void Reset();
    }
    public interface IIterable
    {
        public IIterator GetIterator();
    }

    public class Iterable : IIterable
    {
        public Iterable(IList list) => this.list = list;

        private IList list;

        public IIterator GetIterator() => new Iterator(this);

        public class Iterator : IIterator
        {
            public Iterator(Iterable iterable) => this.iterable = iterable;

            private Iterable iterable;
            private int current = -1;

            public object Current
            {
                get
                {
                    if (-1 < current && current < iterable.list.Count)
                        return iterable.list[current];
                    else
                        return default;
                }
            }

            public bool Next()
            {
                if (current + 1 >= iterable.list.Count)
                    return false;
                current++;
                return true;
            }
            public void Reset()
            {
                current = -1;
            }
        }
    }
}