using PlanBrowserAPI.Models;
using PlanBrowserAPI.Filters;
using PlanBrowserAPI.Repositories;

namespace PlanBrowserAPI.Services
{
    public class PlanService : IPlanService
    {
        private readonly IPlanRepository _repository;

        public PlanService(IPlanRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Plan>> GetPlansAsync(PlanQueryParameters query)
        {
            return _repository.GetPlansAsync(query);
        }

        public Task<Plan?> GetPlanByIdAsync(int id)
        {
            return _repository.GetPlanByIdAsync(id);
        }
    }
}
