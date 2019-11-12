using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Basic.Core.Delegates;
using Basic.Core.Models;

namespace Basic.Core.Services
{
    public class DiskSportScoresService : SportScores
    {
        public DiskSportScoresService(string name) : base(name)
        { }

        public override event ScoreAddedDelegate ScoreAdded;

        public override void AddNumber(int score)
        {
            var path = $"{nameof(Name)}.txt";
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            File.AppendText(path).Write(score.ToString());
        }

        public override void ConvertLetterToNumber(string input)
        {
            throw new NotImplementedException();
        }

        public override StatisticsModel GetStatistics()
        {
            throw new NotImplementedException();
        }

        public override void ShowStatistics(StatisticsModel statisticsModel)
        {
            throw new NotImplementedException();
        }
    }
}
