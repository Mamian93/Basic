using Basic.Core.Delegates;
using Basic.Core.Interfaces;
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
            var mathService = new DiskSportScoresService("Damian scores");
            mathService.ScoreAdded += OnScoreAdded;
            EnterScores(mathService);

            //var result = mathService.GetStatistics();
            //mathService.ShowStatistics(result);

            Console.ReadKey();
        }

        private static void EnterScores(ISportScores mathService)
        {
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
                        //mathService.ConvertLetterToNumber(input.ToUpper());
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("You gave invalid number!!!");
                }
            }
        }

        static void OnScoreAdded(object sender, EventArgs args)
        {
            Console.WriteLine("A score was added!");
        }
    }
}
