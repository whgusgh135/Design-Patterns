using System;
using System.Collections.Generic;

namespace Builder
{
    public class FuncPerson
    {
        public string Name, Position;
    }

    public class FuncPersonBuilder
    {
        // this is public so we can extend it in different class
        public readonly List<Action<FuncPerson>> Actions = new List<Action<FuncPerson>>();
        
        public FuncPersonBuilder Called(string name)
        {
            Actions.Add(p => { p.Name = name; });
            return this;
        }
        
        public FuncPerson Build()
        {
            var p = new FuncPerson();
            Actions.ForEach(a => a(p));
            return p;
        }
    }

    // Extending the method
    public static class FuncPersonBuilderExtensions
    {
        public static FuncPersonBuilder WorksAsA
            (this FuncPersonBuilder builder, string position)
        {
            builder.Actions.Add(p => { p.Position = position; });
            return builder;
        }
    }
}