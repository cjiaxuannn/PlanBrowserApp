using PlanBrowserAPI.Models;
using PlanBrowserAPI.Filters;

namespace PlanBrowserAPI.Repositories
{
    public interface IPlanRepository
    {
        Task<IEnumerable<Plan>> GetPlansAsync(PlanQueryParameters query);
        Task<Plan?> GetPlanByIdAsync(int id);
    }
}
