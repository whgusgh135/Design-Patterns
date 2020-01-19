using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = SingletonDatabase.Instance;
            var city = "Tokyo";
            Console.WriteLine($"{city} has population of {db.GetPopulation(city)}");
        }
    }
}