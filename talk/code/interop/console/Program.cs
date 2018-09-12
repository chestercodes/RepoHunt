using shared.domain;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            var john = new Person(
                "John", 
                30,
                new Address("1 lane", "1 street", "BS11BS"));
        }
    }
}
