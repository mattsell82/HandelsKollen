using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorTimeCalculator.Model
{
    public class WorkReport
    {
        public int Id { get; set; }
        public string Description  { get; set; } = string.Empty;
        public bool IsOpen { get; set; } = true;

        public List<WorkUnit> WorkUnits { get; set; } = new List<WorkUnit>();

        public DateTime Created { get; set; } = DateTime.Now;

        [NotMapped]
        public TimeSpan WorkTimeTotal 
        { 
            get
            {
                return new TimeSpan(WorkUnits.Sum(w => w.TotalWorkTime.Ticks));
            }
        }

        [NotMapped]
        public TimeSpan ObZeroTotal
        {
            get
            {
                return new TimeSpan(WorkUnits.Sum(w => w.TimeWithObZero.Ticks));
            }
        }

        [NotMapped]
        public TimeSpan Ob50Total
        {
            get
            {
                return new TimeSpan(WorkUnits.Sum(w => w.TimeWithOb50.Ticks));
            }
        }

        [NotMapped]
        public TimeSpan Ob70Total
        {
            get
            {
                return new TimeSpan(WorkUnits.Sum(w => w.TimeWithOb70.Ticks));
            }
        }

        [NotMapped]
        public TimeSpan Ob100Total
        {
            get
            {
                return new TimeSpan(WorkUnits.Sum(w => w.TimeWithOb100.Ticks));
            }
        }
    }
}
