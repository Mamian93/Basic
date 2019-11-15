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
            var path = $"..\\{nameof(Name)}.txt";
            using (StreamWriter sr = File.AppendText(path))
            {
                sr.WriteLine(score);

                ScoreAdded?.Invoke(this, new EventArgs());

                sr.Close();
            }
        }

        public override int ConvertLetterToNumber(string input)
        {
            return base.ConvertLetterToNumber(input);
        }

        public override StatisticsModel GetStatistics()
        {
            var result = new StatisticsModel();

            var path = $"..\\{nameof(Name)}.txt";
            using (var sr = File.OpenText(path))
            {
                var line = sr.ReadLine();
                while (line != null)
                {
                    if (int.TryParse(line, out int num))
                    {
                        result.Add(num);
                    }
                    line = sr.ReadLine();
                }
            }
            return result;
        }

        public override void ShowStatistics(StatisticsModel statisticsModel)
        {
            base.ShowStatistics(statisticsModel);
        }
    }
}
