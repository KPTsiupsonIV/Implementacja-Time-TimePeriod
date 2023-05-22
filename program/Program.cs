using System;
using czas;
namespace program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Time Czas = new Time("23:59:59:999");
            Time Czas2 = new Time(23,59,59,300);
            Console.WriteLine(Czas >=  Czas2);
            Console.WriteLine(Czas.PlusMilli(1));
        }
    }
}