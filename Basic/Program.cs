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
            while (true)
            {
                Console.WriteLine("Provide a number(0 - 100) or a letter(A - F), if you want to exit press [q]: ");
                var input = Console.ReadLine();
                if (int.TryParse(input, out int number))
                {
                    if (number < 0 || number > 100)
                    {
                        Console.WriteLine("Wrong range, try again");
                        continue;
                    }
                    mathService.AddNumber(number);
                }
                else if (input.Trim().ToLower() == "q")
                {
                    break;
                }
                else
                {
                    mathService.ConvertLetterToNumber(input.ToUpper());
                }
                
            }

            var result = mathService.GetStatistics();
            mathService.ShowStatistics(result);

            Console.ReadKey();
        }
    }
}
