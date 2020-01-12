using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Without Builder
            
            var hello = "hello";
            var sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append(hello);
            sb.Append("</p>");
            Console.WriteLine(sb);
            
            var words = new[] {"hello", "world"};
            sb.Clear();
            sb.Append("<ul>");
            foreach (var word in words)
            {
                sb.AppendFormat("<li>{0}</li>", word);
            }
            sb.Append("</ul>");
            Console.WriteLine(sb);

            
            
            // Builder

            var builder = new HtmlElement.HtmlBuilder("ul");
            // Without fluent builder pattern
            // builder.AddChild("li", "hello");
            // builder.AddChild("li", "world");
            builder.AddChild("li", "hello").AddChild("li", "world");
            Console.WriteLine((builder.ToString()));
            
            
            
            // Fleunt Builder Inheritance and Recursive Generics
            
            // var builder2 = new PersonJobBuilder();
            // builder2.Called("kevin");
            //.WorksAsA("dev") <-- this doesnt work!
            // New method
            var me = Person.New
                .Called("kevin")
                .WorksAsA("developer")
                .Build();
            Console.WriteLine(me.ToString());
            
            
            
            // Functional Builder
            var fpb = new FuncPersonBuilder();
            fpb.Called("Kevin")
                .WorksAsA("developer")
                .Build();
            
            
            
            // Faceted Builder
            var pb = new FacetedPersonBuilder();
            FacetedPerson person = pb
                .Works.At("TradeMe")
                      .AsA("Engineer")
                      .Earning(700000)
                .Lives.At("123 London Road")
                      .In("London")
                      .WithPostcode("555");
            Console.WriteLine(person);
        }
    }
}