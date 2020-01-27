using System;

namespace Adapter
{
    public interface IInteger
    {
        int Value { get; }
    }

    public static class Dimensions
    {
        public class Two : IInteger
        {
            public int Value => 2;
        }
    
        public class Three : IInteger
        {
            public int Value => 3;
        }
    }
    
    public class Vector<T, D>
        where D : IInteger, new()
    {
        protected T[] data;

        public Vector()
        {
            // This doesn't work in C#
            // data = new T[D]
            data = new T[new D().Value];
        }

        public Vector(params T[] values)
        {
            var requiredSize = new D().Value;
            data = new T[requiredSize];

            var providedSize = values.Length;

            for (int i = 0; i < Math.Min(requiredSize, providedSize); i++)
                data[i] = values[i];
        }

        public T this[int index]
        {
            get => data[index];
            set => data[index] = value;
        }
    }

    public class Vector2i : Vector<int, Dimensions.Two>
    {
        
    }
}