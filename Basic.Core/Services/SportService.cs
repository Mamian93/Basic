using Basic.Core.Delegates;
using Basic.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basic.Core.Services
{
    public class SportService
    {
        private List<int> _scores;
        public string Name { get; set; }

        public event ScoreAddedDelegate ScoreAdded;
        public SportService(string name)
        {
            _scores = new List<int>();
            Name = name;
        }

        public void AddNumber(int input)
        {
            if (input >= 0 && input <= 100)
            {
                _scores.Add(input);
                //jeżeli ScoreAdded jest nullem to znaczy, że nikt nie nasłuchuje tego eventu
                if (ScoreAdded != null)
                {
                    //this informuje, że to ta metoda wywołuje ten event
                    ScoreAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid argument {nameof(input)}");
            }
        }        

        public void ConvertLetterToNumber(string input)
        {
            int result;
            switch (input)
            {
                case "A":
                    result = 100;
                    break;
                case "B":
                    result = 80;
                    break;
                case "C":
                    result = 60;
                    break;
                case "D":
                    result = 40;
                    break;
                case "E":
                    result = 20;
                    break;
                default:
                    result = 0;
                    break;
            }
            _scores.Add(result);
        }

        public StatisticsModel GetStatistics()
        {
            var statisticModel = new StatisticsModel();
            if (!_scores.Any())
            {
                return statisticModel;
            }
            statisticModel.Min = int.MaxValue;
            statisticModel.Max = int.MinValue;
            statisticModel.Avg = 0;

            foreach (var score in _scores)
            {
                statisticModel.Min = Math.Min(statisticModel.Min, score);
                statisticModel.Max = Math.Max(statisticModel.Max, score);

                statisticModel.Avg += score;
            }

            statisticModel.Avg = statisticModel.Avg / _scores.Count;
            return statisticModel;
        }

        public void ShowStatistics(StatisticsModel statisticsModel)
        {
            Console.WriteLine(statisticsModel.Min);
            Console.WriteLine(statisticsModel.Max);
            Console.WriteLine(statisticsModel.Avg);
        }
    }
}
