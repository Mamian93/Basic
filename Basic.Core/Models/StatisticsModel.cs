using System;
using System.Collections.Generic;
using System.Text;

namespace Basic.Core.Models
{
    public class StatisticsModel
    {
        public int Avg
        {
            get
            {
                return Sum / Count;
            }
        }
        public int Min { get; set; }
        public int Max { get; set; }
        public int Count { get; set; }
        public int Sum { get; set; }

        public StatisticsModel()
        {
            Min = int.MaxValue;
            Max = int.MinValue;
            Count = 0;
            Sum = 0;
        }

        public void Add(int number)
        {
            Sum += number;
            Count++;
            Min = Math.Min(Min, number);
            Max = Math.Max(Max, number);
        }
    }
}
