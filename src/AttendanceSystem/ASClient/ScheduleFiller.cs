using System;
using System.Collections.Generic;

namespace ASClient
{
    public class ScheduleFiller
    {
        private Schedule _schedule;

        public ScheduleFiller(Schedule schedule)
        {
            _schedule = schedule;
        }

        public List<Schedule> GetSchedule()
        {
            List<Schedule> schedules = new()
            {
                new Schedule() { PairNumber = "1 пара", StartPair = new TimeOnly(8, 0, 0) },
                new Schedule() { PairNumber = "2 пара", StartPair = new TimeOnly(10, 5, 0) },
                new Schedule() { PairNumber = "3 пара", StartPair = new TimeOnly(11, 50, 0) },
                new Schedule() { PairNumber = "4 пара", StartPair = new TimeOnly(13, 55, 0) },
                new Schedule() { PairNumber = "5 пара", StartPair = new TimeOnly(15, 40, 0) },
                new Schedule() { PairNumber = "6 пара", StartPair = new TimeOnly(17, 35, 0) }
            };
            return schedules;
        }
    }
}
