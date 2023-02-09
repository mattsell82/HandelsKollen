namespace BlazorTimeCalculator.Model
{
    public static class WorkingDays
    {
        private static HashSet<DayOfWeek> workingDays = new HashSet<DayOfWeek>
        {
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday
        };

        public static bool IsWorkingDay(this DateOnly date)
        {
            if (date.IsRedDay())
            {
                return false;
            }

            return workingDays.Contains(date.DayOfWeek);
        }
    }


}


