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

        public override void ConvertLetterToNumber(string input)
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
