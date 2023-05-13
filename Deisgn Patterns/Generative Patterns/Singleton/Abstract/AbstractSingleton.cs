using System;

namespace Design_Patterns.Generative_Patterns.Singleton.Abstract
{
    public class Tester
    {
        public void Test()
        {
            Singleton singleton;
            singleton = Singleton.GetInstance(1);
            Console.WriteLine(singleton.ID);
            singleton = Singleton.GetInstance(2);
            Console.WriteLine(singleton.ID);
        }
    }

    public class Singleton
    {
        private Singleton(int id) => ID = id;

        private static Singleton instance;
        private static object locker = new object();

        public int ID { get; set; }

        public static Singleton GetInstance(int id)
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                        instance = new Singleton(id);
                }
            }
            return instance;
        }
    }
}