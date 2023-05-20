using System;
using System.Collections.Generic;

namespace ASClient
{
    public class PairFiller
    {
        private Pair _schedule;

        public PairFiller(Pair pair)
        {
            _schedule = pair;
        }

        public List<Pair> GetSchedule()
        {
            List<Pair> pairs = new()
            {
                new Pair() { PairNumber = "1 пара", StartPair = new TimeOnly(8, 0, 0) },
                new Pair() { PairNumber = "2 пара", StartPair = new TimeOnly(10, 5, 0) },
                new Pair() { PairNumber = "3 пара", StartPair = new TimeOnly(11, 50, 0) },
                new Pair() { PairNumber = "4 пара", StartPair = new TimeOnly(13, 55, 0) },
                new Pair() { PairNumber = "5 пара", StartPair = new TimeOnly(15, 40, 0) },
                new Pair() { PairNumber = "6 пара", StartPair = new TimeOnly(17, 35, 0) },
                new Pair() { PairNumber = "0 пара", StartPair = new TimeOnly(19, 10, 0) }
            };
            return pairs;
        }
    }
}
