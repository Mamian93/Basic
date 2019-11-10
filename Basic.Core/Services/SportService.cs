using Basic.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basic.Core.Services
{
    public class SportService
    {
        private List<int> _scores;
        public string name { get; set; }

        public SportService(string name)
        {
            _scores = new List<int>();
            this.name = name;
        }

        public void AddNumber(int input)
        {
            _scores.Add(input);
        }

        public StatisticsModel GetStatistics()
        {
            var statisticModel = new StatisticsModel();
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
