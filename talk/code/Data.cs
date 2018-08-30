using System;
using System.Collections.Generic;
using System.Linq;

namespace code
{
    public class Person : IEquatable<Person>
    {
        public int Age { get; private set; }
        public string Name { get; private set; }
        public Address Address { get; private set; }

        public Person(string name, int age, Address address)
        {
            Name = name;
            Age = age;
            Address = address;
        }

        public bool Equals(Person other)
        {
            return other.Age == Age
                && other.Name == Name
                && other.Address.Equals(Address);
        }
    }
    public class Address : IEquatable<Address>
    {
        public string Line1 { get; private set; }
        public string Line2 { get; private set; }
        public string PostCode { get; private set; }
        public Address(string line1, string line2, string postCode)
        {
            Line1 = line1;
            Line2 = line2;
            PostCode = postCode;
        }

        public bool Equals(Address other)
        {
            return other.Line1 == Line1
                && other.Line2 == Line2 
                && other.PostCode == PostCode;        
        }
    }
}
