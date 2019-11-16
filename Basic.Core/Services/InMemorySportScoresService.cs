using Basic.Core.Delegates;
using Basic.Core.Interfaces;
using Basic.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basic.Core.Services
{
    public class InMemorySportScoresService : SportScores
    {
        private List<int> _scores;

        public override event ScoreAddedDelegate ScoreAdded;
        public override event ZeroScoreWarningDelegate ZeroScoreWarning;

        public InMemorySportScoresService(string name) : base(name)
        {
            _scores = new List<int>();
            Name = name;
        }

        public override void AddNumber(int input)
        {
            if (input >= 0 && input <= 100)
            {
                _scores.Add(input);

                //jeżeli ScoreAdded jest nullem to znaczy, że nikt nie nasłuchuje tego eventu
                //this informuje, że to ta metoda wywołuje ten event
                ScoreAdded?.Invoke(this, new EventArgs());
            }
            else
            {
                throw new ArgumentException($"Invalid argument {nameof(input)}");
            }
        }

        public override int ConvertLetterToNumber(string input)
        {
            return base.ConvertLetterToNumber(input);
        }

        public override StatisticsModel GetStatistics()
        {
            var statisticModel = new StatisticsModel();                  

            foreach (var score in _scores)
            {
                statisticModel.Add(score);
            }

            return statisticModel;
        }

        public override void ShowStatistics(StatisticsModel statisticsModel)
        {
            base.ShowStatistics(statisticsModel);
        }
    }
}
