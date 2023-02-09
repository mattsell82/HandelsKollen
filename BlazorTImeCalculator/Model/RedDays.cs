namespace BlazorTimeCalculator.Model
{
    public static class RedDays
    {
        private static HashSet<DateOnly> redDays = new HashSet<DateOnly>
        {
            new DateOnly(2022,01,01),
            new DateOnly(2022,01,06),
            new DateOnly(2022,04,15),
            new DateOnly(2022,04,17),
            new DateOnly(2022,05,01),
            new DateOnly(2022,05,26),
            new DateOnly(2022,06,05),
            new DateOnly(2022,06,24),
            new DateOnly(2022,06,25),
            new DateOnly(2022,11,05),
            new DateOnly(2022,12,24),
            new DateOnly(2022,12,25),
            new DateOnly(2022,12,26),
            new DateOnly(2022,12,31)
        };

        public static bool IsRedDay(this DateOnly date)
        {
            return redDays.Contains(date);
        }

    }


}


