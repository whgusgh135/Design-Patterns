using System;

namespace SOLID_Principle
{
    class Program
    {
        static void Main(string[] args)
        {
            // Single responsibility
            
            var j = new Journal();
            j.AddEntry("I cried today");
            j.AddEntry("I stared at the ceiling for 8 hours");
            Console.WriteLine(j);

            var ps = new Persistence();
            var filename = @"e:\Coding\Course\journal.txt";
            ps.SaveToFile(j, filename, true);
            /*Process.Start(filename);*/
            
            
            // Open/Closed
            
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);

            Product[] products = {apple, tree, house};
            
            var pf = new ProductFilter();
            Console.WriteLine("Green products (old):");
            foreach (var p in pf.FilterByColor(products, Color.Green))
            {
                Console.WriteLine($" - {p.Name} is green");
            }
            
            var bf = new BetterFilter();
            Console.WriteLine("Green products (new):");
            foreach (var p in bf.Filter(products, new ColorSpecification(Color.Green)))
            {
                Console.WriteLine(($" - {p.Name} is green"));
            }
            
            Console.WriteLine("Large blue items:");
            foreach (var p in bf.Filter(
                products,
                new AndSpecification<Product>(
                    new ColorSpecification(Color.Blue),
                    new SizeSpecification(Size.Large)
                )
            ))
            {
                Console.WriteLine($" - {p.Name} is big and blue");
            }
            
            
            
            // Liskov Substition

            static int Area(Rectangle r) => r.Width * r.Height;
            Rectangle rc = new Rectangle(2, 3);
            Console.WriteLine($"{rc} has area {Area(rc)}");
            
            // this should work but not with the initial method
            Rectangle sq = new Square();
            sq.Width = 4;
            Console.WriteLine($"{sq} has area {Area(sq)}");
        }
    }
}