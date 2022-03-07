using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Greedy
{
    class GasStation
    {
        public static int StartingStation(List<int> gas, List<int> dist)
        {
            var tank = 0;
            var result = 0;
            var totalDifference = gas.Sum() - dist.Sum();
            if (totalDifference < 0) return -1;
            for(int i=0;i<gas.Count;i++)
            {
                var difference =  gas[i] - dist[i];
                tank += difference;
                if (tank < 0)
                {
                    tank = 0;
                    result = i + 1;
                }
            }
            return result;
        }
    }
}
