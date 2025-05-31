using Microsoft.EntityFrameworkCore;
using PlanBrowserAPI.Data;
using PlanBrowserAPI.Models;
using PlanBrowserAPI.Filters;

namespace PlanBrowserAPI.Repositories
{
    public class PlanRepository : IPlanRepository
    {
        private readonly AppDbContext _context;

        public PlanRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Plan>> GetPlansAsync(PlanQueryParameters query)
        {
            var plans = _context.Plans.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Type))
                plans = plans.Where(p => p.Type.ToLower() == query.Type.ToLower());

            if (!string.IsNullOrWhiteSpace(query.Name))
                plans = plans.Where(p => p.Name.ToLower().Contains(query.Name.ToLower()));

            if (!string.IsNullOrWhiteSpace(query.DataLimit))
                plans = plans.Where(p => p.DataLimit == query.DataLimit);

            if (query.ValidityDays.HasValue)
                plans = plans.Where(p => p.ValidityDays == query.ValidityDays.Value);

            if (query.Price.HasValue)
                plans = plans.Where(p => p.Price == query.Price.Value);

            return await plans.ToListAsync();
        }

        public async Task<Plan?> GetPlanByIdAsync(int id)
        {
            return await _context.Plans.FindAsync(id);
        }
    }
}
