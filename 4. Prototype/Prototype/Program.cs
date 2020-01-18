using System;

namespace Prototype
{
    // Prototype
    
    // A partially or fully initialized object that you copy and make use of
    
    
    class Program
    {
        static void Main(string[] args)
        {
            var john = new Person(new []{"John", "Smilth"}, new Address("London Road", 123));

            var jane = john;
            jane.Names[0] = "Jane";

            Console.WriteLine(john);
            Console.WriteLine(jane);

            // Copy Constructor
            var hamish = new Person(john);
            hamish.Address.HouseNumber = 321;
            Console.WriteLine(hamish);
            
            // Deep Copy Interface pattern
            var kevin = john.DeepCopy();
            kevin.Address.HouseNumber = 555;
            Console.WriteLine(kevin);
            
            // Copy through serialization pattern
            var dick = john.DeepCopyXml();
            dick.Names[0] = "Dick";
            dick.Address.HouseNumber = 777;
            Console.WriteLine(dick);
        }
    }
}