using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq;
using NUnit.Framework;

namespace Singleton
{
    public interface IDatabase
    {
        int GetPopulation(string name);
    }

    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;
        private static int instanceCount; // 0
        public static int Count => instanceCount;

        // make constructor private
        // so its not instantiated more than once
        private SingletonDatabase()
        {
            instanceCount++;
            Console.WriteLine("Initializing database");

            capitals = File.ReadAllLines(
                Path.Combine(
                    new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName, "capitals.txt")
                )
                .Batch(2)
                .ToDictionary(
                    list => list.ElementAt(0).Trim(),
                    list => int.Parse(list.ElementAt(1))
                );
        }

        [TestFixture]
        public class SingletonTests
        {
            [Test]
            public void IsSingletonTest()
            {
                var db = SingletonDatabase.Instance;
                var db2 = SingletonDatabase.Instance;
                Assert.That(db, Is.SameAs(db2));
                Assert.That(SingletonDatabase.Count, Is.EqualTo(1));
            }
        }

         public int GetPopulation(string name)
        {
            return capitals[name];
        }
         
         // Make this lazy in case the client never needs this
         // private static SingletonDatabase instance = new SingletonDatabase();
         
         // Now its lazy, thread safe
         private static Lazy<SingletonDatabase> instance = 
             new Lazy<SingletonDatabase>(() => new SingletonDatabase());

         public static SingletonDatabase Instance => instance.Value;
    }
}