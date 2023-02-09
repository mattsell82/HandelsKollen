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
                    .Include(w => w.WorkUnits)
                    .FirstOrDefaultAsync(m => m.Id == id);

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
