using System;

namespace Design_Patterns.Behavior_Patterns.Iterator.Concrete
{
    public class Tester
    {
        public void Test()
        {
            IIterable iterable = new SteamLibrary(new Game[12]
            {
                new Game("Tomb Raider 1"),
                new Game("Tomb Raider 2"),
                new Game("Tomb Raider 3"),
                new Game("Tomb Raider 4"),
                new Game("Tomb Raider 5"),
                new Game("Tomb Raider 6"),
                new Game("Tomb Raider Legend"),
                new Game("Tomb Raider Anniversary"),
                new Game("Tomb Raider Underworld"),
                new Game("Tomb Raider"),
                new Game("Rise Of The Tomb Raider"),
                new Game("Shadow Of The Tomb Raider")
            });
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

    public class SteamLibrary : IIterable
    {
        public SteamLibrary(Game[] games) => this.games = games;

        private Game[] games;

        public IIterator GetIterator() => new Iterator(this);

        public class Iterator : IIterator
        {
            public Iterator(SteamLibrary steamLibrary) => this.steamLibrary = steamLibrary;

            private SteamLibrary steamLibrary;
            private int current = -1;

            public object Current
            {
                get
                {
                    if (-1 < current && current < steamLibrary.games.Length)
                        return steamLibrary.games[current];
                    else
                        return default;
                }
            }

            public bool Next()
            {
                if (current + 1 >= steamLibrary.games.Length)
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
    public class Game
    {
        public Game(string name) => Name = name;

        public string Name { get; set; }

        public override string ToString() => Name;
    }
}