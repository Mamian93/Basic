using Basic.Core.Repository;
using Basic.Core.Services;
using Basic.Data.Models;
using System;
using System.Collections.Generic;

namespace Basic
{
    class Program
    {
        static void Main(string[] args)
        {
            var mathService = new SportService("Damian scores");
            mathService.AddNumber(12);
            mathService.AddNumber(89);
            mathService.AddNumber(-12);
            mathService.AddNumber(1);

            var result = mathService.GetStatistics();
            mathService.ShowStatistics(result);

            Console.ReadKey();
        }
    }
}
