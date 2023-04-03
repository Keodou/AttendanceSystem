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
            TimeOnly currentTime = TimeOnly.FromDateTime(attendanceDateTime);

            // Расписание пар и перерывов
            TimeOnly[] schedule = new TimeOnly[]
            {
                new TimeOnly(8, 30, 0),   // Первая пара
                new TimeOnly(10, 15, 0),   // Вторая пара
                new TimeOnly(12, 20, 0),  // Третья пара
                new TimeOnly(14, 5, 0),  // Четвертая пара
                new TimeOnly(15, 50, 0),   // Пятая пара
                new TimeOnly(17, 35, 0),
                new TimeOnly(19, 10, 0)
            };

            // Определение текущей пары
            int currentPair = 0;
            for (int i = 0; i < schedule.Length; i++)
            {
                if (currentTime >= schedule[i] && currentTime < schedule[i + 1])
                {
                    currentPair = i + 1;
                }
                else
                {
                    currentPair = 0;
                }
            }

            // Вывод результата
            return $"{currentPair} пара";
        }
    }
}
