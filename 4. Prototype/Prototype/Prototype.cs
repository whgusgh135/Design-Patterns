using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Prototype
{
    // Copy through serialization
    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            object copy = formatter.Deserialize(stream);
            return (T) copy;
        }

        public static T DeepCopyXml<T>(this T self)
        {
            using (var ms = new MemoryStream())
            {
                var s = new XmlSerializer(typeof(T));
                s.Serialize(ms, self);
                ms.Position = 0;
                return (T) s.Deserialize(ms);
            }
        }
}
    
    public interface IPrototype<T>
    {
        T DeepCopy();
    }
    public class Person : IPrototype<Person>
    {
        public string[] Names;
        public Address Address;

        public Person()
        {
            
        }
        public Person(string[] names, Address address)
        {
            Names = names;
            Address = address;
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }

        // Not useful!!
        // ICloneable makes shallow copy
        // We need deep copy for prototype pattern
        /*public object Clone()
        {
            return new Person(Names, Address);
        }*/

        // Copy constructor
        // This is C++ thing
        public Person(Person other)
        {
            Names = other.Names;
            Address = new Address(other.Address);
        }

        // Explicit deep copy interface pattern
        public Person DeepCopy()
        {
            return new Person(Names, Address.DeepCopy());
        }
    }

    public class Address : IPrototype<Address>
    {
        public string StreetName;
        public int HouseNumber;
        
        public Address()
        {
            
        }

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }

        public Address(Address other)
        {
            StreetName = other.StreetName;
            HouseNumber = other.HouseNumber;
        }

        public Address DeepCopy()
        {
            return new Address(StreetName, HouseNumber);
        }
    }
}