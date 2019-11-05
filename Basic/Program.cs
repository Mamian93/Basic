using Basic.Core.Repository;
using Basic.Core.Services;
using System;

namespace Basic
{
    class Program
    {
        static void Main(string[] args)
        {
            var vehicleService = new VehicleService();
            Console.WriteLine("Choose vehicle type from 1 to 3");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                vehicleService.PowerGroupCalculation(number);
            }
            else
            {
                Console.WriteLine("Wrong input");
            }
            Console.ReadKey();
        }
    }
}
