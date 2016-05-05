using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PiramidaAnalize
{
    public static class DateTimeHelper
    {
        /// <summary>
        /// Возвращает первый день той же недели.
        /// Необходимость в этом методе расширения продиктована тем, что
        /// в России первый день недели понедельник, а в .NET - воскресенье
        /// </summary>
        /// <param name="inputDate"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfWeek(this DateTime inputDate)
        {
            int offset = 0;
            switch (inputDate.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    {
                        offset = 0;
                        break;
                    }
                case DayOfWeek.Tuesday:
                    {
                        offset = -1;
                        break;
                    }
                case DayOfWeek.Wednesday:
                    {
                        offset = -2;
                        break;
                    }
                case DayOfWeek.Thursday:
                    {
                        offset = -3;
                        break;
                    }
                case DayOfWeek.Friday:
                    {
                        offset = -4;
                        break;
                    }
                case DayOfWeek.Saturday:
                    {
                        offset = -5;
                        break;
                    }
                case DayOfWeek.Sunday:
                    {
                        offset = -6;
                        break;
                    }
            }
            return inputDate.AddDays(offset);
        }

        /// <summary>
        /// Возвращает количество дней в месяце, к которому относится данная дата
        /// </summary>
        /// <param name="inputDate"></param>
        /// <returns></returns>
        public static int DaysInMonth(this DateTime inputDate)
        {
            DateTime firstDay = new DateTime(inputDate.Year, inputDate.Month, 1);
            firstDay = firstDay.AddMonths(1).AddDays(-1);
            return firstDay.Day;
        }

        /// <summary>
        /// Возвращает количество дней в году, к которому относится данная дата
        /// (корректно учитывает високосный год)
        /// </summary>
        /// <param name="inputDate"></param>
        /// <returns></returns>
        public static int DaysInYear(this DateTime inputDate)
        {
            DateTime februaryDay = new DateTime(inputDate.Year, 2, 1);
            return februaryDay.DaysInMonth() + 337; // 337 дней в году, не считая февраль
        }

        /// <summary>
        /// Возвращает первый день месяца, к которому относится данная дата
        /// </summary>
        /// <param name="inputDate"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfMonth(this DateTime inputDate)
        {
            return new DateTime(inputDate.Year, inputDate.Month, 1, inputDate.Hour, inputDate.Minute, inputDate.Second);
        }

        /// <summary>
        /// Возвращает первый день года, к которому относится данная дата
        /// </summary>
        /// <param name="inputDate"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfYear(this DateTime inputDate)
        {
            return new DateTime(inputDate.Year, 1, 1, inputDate.Hour, inputDate.Minute, inputDate.Second);
        }

        /// <summary>
        /// Возвращает следующую итерацию для даты на основании типа интервала
        /// </summary>
        /// <param name="previousDate"></param>
        /// <param name="interval">тип интервала: halfhour, day, week, month или year</param>
        /// <returns></returns>
        public static DateTime IterateDate(this DateTime previousDate, string interval)
        {
            DateTime result;
            switch (interval)
            {
                case "halfhour":
                    {
                        result = previousDate.AddMinutes(30);
                        break;
                    }
                case "day":
                    {
                        result = previousDate.AddDays(1);
                        break;
                    }
                case "week":
                    {
                        result = previousDate.AddDays(7);
                        break;
                    }
                case "month":
                    {
                        result = previousDate.AddMonths(1);
                        break;
                    }
                case "year":
                    {
                        result = previousDate.AddYears(1);
                        break;
                    }
                default: // То же, что и "day"
                    {
                        result = previousDate.AddDays(1);
                        break;
                    }
            }
            return result;
        }
    }
}
