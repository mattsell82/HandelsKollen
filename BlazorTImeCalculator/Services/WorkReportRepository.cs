using BlazorTimeCalculator.Data;
using BlazorTimeCalculator.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorTimeCalculator.Services
{
    public class WorkReportRepository
    {
        private readonly ApplicationDbContext _context;

        public WorkReportRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        //create

        public async Task Create(WorkReport workReport)
        {
            await _context.WorkReports.AddAsync(workReport);
            await _context.SaveChangesAsync();
        }

        //read

        public async Task<WorkReport> GetById(int id)
        {
            try
            {
                var workReport = await _context.WorkReports
                    .Include(w => w.WorkUnits.OrderBy(u => u.Date))
                    .FirstOrDefaultAsync(w => w.Id == id);


                var sortedWorkUnits = workReport.WorkUnits.OrderBy(w => w.Date).ThenBy(w => w.StartTime);

                workReport.WorkUnits = sortedWorkUnits.ToList();

                return workReport;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<List<WorkReport>> GetAll()
        {
            return await _context.WorkReports
                .Include(w => w.WorkUnits)
                .ToListAsync();
        }

        public async Task Update(WorkReport workReport)
        {
            _context.WorkReports.Update(workReport);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(WorkReport workReport)
        {
            _context.WorkReports.Remove(workReport);
            await _context.SaveChangesAsync();
        }

    }
}
