using BlazorTimeCalculator.Data;
using BlazorTimeCalculator.Model;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace BlazorTimeCalculator.Services
{

    public class WorkUnitREpository
    {
        private readonly ApplicationDbContext _context;

        public WorkUnitREpository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        //create
        
        public async Task Create(WorkUnit workUnit)
        {
            await _context.WorkUnits.AddAsync(workUnit);
            await _context.SaveChangesAsync();
        }

        //read

        public async Task<WorkUnit> GetById(int id)
        {
            try
            {
                var workUnit = await _context.WorkUnits
                    .FirstOrDefaultAsync(a => a.Id == id);

                return workUnit;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<List<WorkUnit>> GetWorkUnits()
        {
            return await _context.WorkUnits
                .ToListAsync();
        }

        public async Task Update(WorkUnit workUnit)
        {
            _context.WorkUnits.Update(workUnit);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(WorkUnit workUnit)
        {
            _context.WorkUnits.Remove(workUnit);
            await _context.SaveChangesAsync();
        }

    }
}
