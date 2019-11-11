using Basic.Core.Delegates;
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
            mathService.ScoreAdded += OnScoreAdded; 
            while (true)
            {
                try
                {
                    Console.WriteLine("Provide a number(0 - 100) or a letter(A - F), if you want to exit press [q]: ");
                    var input = Console.ReadLine();
                    if (int.TryParse(input, out int number))
                    {
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
                catch (Exception)
                {
                    Console.WriteLine("You gave invalid number!!!");
                }

            }

            var result = mathService.GetStatistics();
            mathService.ShowStatistics(result);

            Console.ReadKey();
        }

        static void OnScoreAdded(object sender, EventArgs args)
        {
            Console.WriteLine("A score was added!");
        }
    }
}
