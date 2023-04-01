using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASClient
{
    public class DeteminantPair
    {
        public string GetPairByTime(DateTime attendanceDateTime)
        {
            TimeOnly attendanceTime = TimeOnly.FromDateTime(attendanceDateTime);
            TimeOnly startPair = new(21, 20, 00);
            TimeOnly endPair = new(22, 30, 00);
            if (attendanceTime >= startPair && attendanceTime <= endPair)
            {
                return "1 пара";
            }
            else
            {
                return "Другая пара";
            }
        }
    }
}
