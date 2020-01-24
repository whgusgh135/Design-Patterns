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

            
            // Monostate pattern
            var ceo = new CEO();
            ceo.Name = "Adam Smith";
            ceo.Age = 55;
            
            var ceo2 = new CEO();
            ceo2.Name = "Kevin Cho";
            ceo2.Age = 28;
            Console.WriteLine(ceo);
        }
    }
}