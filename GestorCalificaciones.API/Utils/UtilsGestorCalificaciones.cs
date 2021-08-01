using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.Utils
{
    public class UtilsGestorCalificaciones
    {
        public static string GetPreviousPeriod(string currentPeriod)
        {
            if (currentPeriod.Length == 7)
            {
                var numbers = currentPeriod.Split('-');
                int year = Convert.ToInt32(numbers[0]);
                int semester = Convert.ToInt32(numbers[1]);

                int previousYear = year;
                int previousSemester = semester;

                if (semester==2)
                {
                    previousSemester = 1;
                }
                if (semester==1)
                {
                    previousYear = year - 1;
                    previousSemester = 2;
                }

                return $"{previousYear}-0{previousSemester}";
            }
            else
            {
                throw new Exception("Length of Periodo is incorrect, must be 7");
            }
        }
    }
}
