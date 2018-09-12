using System;
using System.Collections.Generic;
using System.Linq;

namespace code
{
    class Program
    {
        static void Main(string[] args)
        {
            var pc = new PostCodeRegex();
            pc.Run();
            return;

            Enumerable.Range(1, 20)
                .Select(FizzBuzz)
                .ToList().ForEach(Console.WriteLine);
                
            Enumerable.Range(1, 20)
                .Select(FizzBuzz2)
                .ToList().ForEach(Console.WriteLine);

            var john     = new Person(
                "John", 30, 
                new Address("1 lane", "1 street", "BS11BS"));
            var sameJohn = new Person(
                "John", 30, 
                new Address("1 lane", "1 street", "BS11BS"));
            
            Console.WriteLine($"Johns are equal - " + (john.Equals(sameJohn)));
            
            var sameJohnMovedNextDoor = new Person(
                john.Name, john.Age, 
                new Address(
                    "2 lane", // moved next door
                    john.Address.Line2, 
                    john.Address.PostCode)
                );
        }

        static string FizzBuzz(int n)
        {   
            if(n % 15 == 0){
                return "FizzBuzz";
            } else if (n % 3 == 0) {
                return "Fizz";
            } else if (n % 5 == 0) {
                return "Buzz";
            } else {
                return n.ToString();
            }
        }

        public static string FizzBuzz2(int n)
        {
            return  n.DividesBy(15) ? "FizzBuzz" : 
                        n.DividesBy(3) ? "Fizz" :
                            n.DividesBy(5) ? "Buzz" :
                                n.ToString();
        }
    }

    public static class IntExtensions
    {
        public static bool DividesBy(this int n, int mod)
        {
            return n % mod == 0;
        }
    }
}
