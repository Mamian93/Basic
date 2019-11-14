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

        public abstract void ConvertLetterToNumber(string input);

        public abstract StatisticsModel GetStatistics();

        public virtual void ShowStatistics(StatisticsModel statisticsModel)
        {
            Console.WriteLine(statisticsModel.Min);
            Console.WriteLine(statisticsModel.Max);
            Console.WriteLine(statisticsModel.Avg);
        }
    }
}
