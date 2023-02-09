using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorTimeCalculator.Model
{
    public class WorkUnit
    {

        public WorkUnit()
        {
            this.Date = GetCurrentDate();
        }

        public int Id { get; set; }

        public WorkReport WorkReport { get; set; } = new WorkReport();
        public int MyProperty { get; set; }

        public string Description { get; set; } = string.Empty;
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public TimeOnly Lunch { get; set; } = new TimeOnly(0,0);

        [NotMapped]
        public string Name { get; set; } = string.Empty;

        [NotMapped]
        public DayOfWeek DayOfWeek { get { return Date.DayOfWeek; } }

        [NotMapped]
        public bool IsRedDay
        {
            get
            {
                return Date.IsRedDay();
            }
        }

        [NotMapped]
        public TimeSpan TotalWorkTime
        {
            get
            {
                return EndTime.ToTimeSpan() - StartTime.ToTimeSpan() - Lunch.ToTimeSpan();
            }
        }


        [NotMapped]
        public TimeSpan TimeWithObZero
        {
            get
            {
                if (Date.DayOfWeek == DayOfWeek.Sunday)
                    return TimeSpan.Zero;

                if (IsRedDay)
                    return TimeSpan.Zero;

                if ((Date.DayOfWeek == DayOfWeek.Saturday))
                    return GetTimeInRange(new TimeOnly(0,0,0), new TimeOnly(12,0,0));

                return GetTimeInRange(new TimeOnly(0, 0, 0), new TimeOnly(18, 15, 0)) - Lunch.ToTimeSpan();
            }
        }

        [NotMapped]
        public TimeSpan TimeWithOb50
        {
            get
            {                
                if (IsRedDay)
                {
                    return TimeSpan.Zero;
                }

                if (!Date.IsWorkingDay())
                {
                    return TimeSpan.Zero;
                }

                return GetTimeInRange(new TimeOnly(18,15,0), new TimeOnly(20,0,0));
            }
        }

        [NotMapped]
        public TimeSpan TimeWithOb70
        {
            get
            {
                if (IsRedDay)
                {
                    return TimeSpan.Zero;
                }

                if (!Date.IsWorkingDay())
                {
                    return TimeSpan.Zero;
                }

                return GetTimeInRange(new TimeOnly(20, 0, 0), new TimeOnly(0, 0, 0));
            }
        }

        [NotMapped]
        public TimeSpan TimeWithOb100
        {
            get
            {
                if (IsRedDay || (Date.DayOfWeek == DayOfWeek.Sunday))
                {
                    return TotalWorkTime;
                }

                if (Date.DayOfWeek == DayOfWeek.Saturday)
                {
                    return GetTimeInRange(new TimeOnly(12,0,0), new TimeOnly(0,0,0)) - Lunch.ToTimeSpan();
                }

                return TimeSpan.Zero;

            }

        }

        [NotMapped]
        public bool Check
        {
            get
            {
                if ((TimeWithObZero + TimeWithOb50 + TimeWithOb70 + TimeWithOb100) == TotalWorkTime)
                {
                    return true;
                }

                return false;
            }
        }


        private TimeSpan GetTimeInRange(TimeOnly rangeMin, TimeOnly rangeMax)
        {
            var isStartInRange = StartTime.IsBetween(rangeMin, rangeMax);
            var isEndInRange = EndTime.IsBetween(rangeMin, rangeMax);

            if (isStartInRange && isEndInRange)
                return EndTime.ToTimeSpan() - StartTime.ToTimeSpan();

            if (isStartInRange && !isEndInRange)
                return rangeMax.ToTimeSpan() - StartTime.ToTimeSpan();

            if (!isStartInRange && isEndInRange)
                return EndTime.ToTimeSpan() - rangeMin.ToTimeSpan();

            return TimeSpan.Zero;
        }


        public static string GetHeaders()
        {
            return
                $"{"Description",-40}" +
                $"{"Date",-15}" +
                $"{"DayOfWeek",-15}" +
                $"{"StartTime",-15}" +
                $"{"EndTime",-15}" +
                $"{"Lunch",-15}" +
                $"{"TotalWorkTime",-15}" +
                $"{"ObZero",-15}" +
                $"{"Ob50",-15}" +
                $"{"Ob70",-15}" +
                $"{"Ob100",-15}" +
                $"{"IsRedDay",-15}";
        }

        public override string ToString()
        {
            return
                $"{Description,-40}" +
                $"{Date,-15}" +
                $"{DayOfWeek,-15}" +
                $"{StartTime,-15}" +
                $"{EndTime,-15}" +
                $"{Lunch,-15}" +
                $"{TotalWorkTime,-15}" +
                $"{TimeWithObZero,-15}" +
                $"{TimeWithOb50,-15}" +
                $"{TimeWithOb70,-15}" +
                $"{TimeWithOb100,-15}" +
                $"{IsRedDay,-15}";
        }

        public string RenderDetails()
        {
            return
                "Description: " + Description + "\n"
                + "StartTime: " + StartTime + "\n"
                + "EndTime: " + EndTime + "\n"
                + "DayOfWeek: " + DayOfWeek + "\n"
                + "IsRedDay: " + IsRedDay + "\n"
                + "TotalWorkTime: " + TotalWorkTime + "\n"
                + "TimeWithObZero: " + TimeWithObZero + "\n"
                + "TimeWithOb50: " + TimeWithOb50 + "\n"
                + "TimeWithOb70: " + TimeWithOb70 + "\n"
                + "TimeWithOb100: " + TimeWithOb100 + "\n"
                + "Check: " + Check;
        }

        private DateOnly GetCurrentDate()
        {
            var dateTime = DateTime.Now;
            return new DateOnly(dateTime.Year, dateTime.Month, dateTime.Day);
        }

    }

}


