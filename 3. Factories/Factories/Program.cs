using System;

namespace Factories
{
    // Reason for using Factories Pattern
    
    // Object creation logic becomes too convoluted
    // Constructor is not descriptive
    // - Name mandated by name of containing type
    // - Cannot overload with same sets of arguments with different names
    // - Can turn into 'optional parameter hell'
    // Object creation (non-piecewise, unlike Builder) can be outsourced to
    // - A separate function (Factory Method)
    // - Tha may exist in a separate class (Factory)
    // - Can create hierarchy of factoreis with Abstract Factory
    
    // Factory is
    // A component responsible solely for the wholesale (not piecewise like builder)
    // creation of objects
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}