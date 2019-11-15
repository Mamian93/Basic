using Basic.Core.Delegates;
using Basic.Core.Interfaces;
using Basic.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basic.Core.Services
{
    public abstract class SportScores : NameServices, ISportScores
    {
        public SportScores(string name) : base(name)
        {
        }

        public abstract event ScoreAddedDelegate ScoreAdded;

        public abstract void AddNumber(int score);

        public virtual int ConvertLetterToNumber(string input)
        {
            switch (input)
            {
                case "A":
                    return 100;
                case "B":
                    return 80;
                case "C":
                    return 60;
                case "D":
                    return 40;
                case "E":
                    return 20;
                default:
                    return 0;
            }
        }

        public abstract StatisticsModel GetStatistics();

        public virtual void ShowStatistics(StatisticsModel statisticsModel)
        {
            Console.WriteLine(statisticsModel.Min);
            Console.WriteLine(statisticsModel.Max);
            Console.WriteLine(statisticsModel.Avg);
        }
    }
}
