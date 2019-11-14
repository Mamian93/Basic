﻿using Basic.Core.Delegates;
using Basic.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basic.Core.Interfaces
{
    public interface ISportScores
    {
        void AddNumber(int score);
        StatisticsModel GetStatistics();
        void ShowStatistics(StatisticsModel statisticsModel);
        void ConvertLetterToNumber(string letter);
        public string Name { get; }

        event ScoreAddedDelegate ScoreAdded;
    }
}