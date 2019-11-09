using System;
using System.Collections.Generic;
using System.Text;

namespace Basic.Core.Services
{
    public class MathService<T>
    {
        private List<T> _numbers = new List<T>();
        private List<int> _scores = new List<int>();

        public void AddNumber(int input)
        {
            _scores.Add(input);
        }

        public void ShowStatistics()
        {
            var lowestScore = int.MaxValue;
            var highestScore = int.MinValue;
            var avgScore = 0;

            foreach (var score in _scores)
            {
                highestScore = Math.Max(highestScore, score);
                lowestScore = Math.Min(lowestScore, score);

                avgScore += score;
            }

            Console.WriteLine(highestScore);
            Console.WriteLine(lowestScore);
            Console.WriteLine(avgScore / _scores.Count);
        }

        public void ShowStatisticsExternalGeneric(List<T> numberList)
        {
            if (numberList is null)
                throw new ArgumentNullException(nameof(numberList)); 
        }

        public void ShowStatisticsInternalGeneric()
        {
            var lowestScore = int.MaxValue;
            var highestScore = int.MinValue;
            var avgScore = 0;

            foreach (var score in _numbers)
            {
            //    if (score > highestScore)
            //        highestScore = score;
            }
        }

        public void AddNumberGeneric(T input)
        {
            _numbers.Add(input);
        }
    }
}
