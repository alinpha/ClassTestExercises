using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalEx.ClassLib;

namespace ConsoleAppFlight
{
    class Program
    {
        static void Main(string[] args)
        {
            Flight flight = new Flight(123, new DateTime(2019,3,29), "ABC", "ZXC");

            Console.WriteLine("before delay");
            Console.WriteLine(flight.ToString());

            flight.DelayFlight(60);

            Console.WriteLine("after delay");
            Console.WriteLine(flight.ToString());

            Console.ReadLine();

        }
    }
}
