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
            mathService.ZeroScoreWarning += OnZeroWarningScoreAdded;
            EnterScores(mathService);
            var result = mathService.GetStatistics();
            mathService.ShowStatistics(result);

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
                        if (number < 0 || number > 100)
                        {
                            Console.WriteLine($"Wrong input, the {number} is not valid");
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
                        var num = mathService.ConvertLetterToNumber(input.ToUpper());
                        mathService.AddNumber(num);
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

        static void OnZeroWarningScoreAdded(object sender, EventArgs args)
        {
            Console.WriteLine("Warning of 0 score was reported!");
        }
    }
}
