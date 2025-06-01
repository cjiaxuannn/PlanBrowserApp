import { useState } from 'react';
import { usePlans } from '../hooks/usePlans';
import PlanCard from '../components/PlanCard';
import PlanModal from '../components/PlanModal';

const filterOptions = ['All', 'Prepaid', 'Postpaid'] as const;
type FilterType = typeof filterOptions[number];

const PlansPage: React.FC = () => {
  const [filter, setFilter] = useState<FilterType>('All');
  const { plans, loading, error } = usePlans(filter);
  //const { plans, loading, error } = usePlans();
  const [selectedPlanId, setSelectedPlanId] = useState<number | null>(null);
  //const [filter, setFilter] = useState<FilterType>('All');

  // Filter plans based on selected type
  const filteredPlans =
    filter === 'All' ? plans : plans.filter(plan => plan.type === filter);

  return (
    <div className="container mt-4">
      <h2>Browse Plans</h2>

      {/* Filter Buttons */}
      <div className="btn-group my-3" role="group" aria-label="Filter Plans">
        {filterOptions.map(option => (
          <button
            key={option}
            type="button"
            className={`btn btn-outline-primary ${filter === option ? 'active' : ''}`}
            onClick={() => setFilter(option)}
          >
            {option}
          </button>
        ))}
      </div>

      {/* Loading/Error */}
      {loading && <p>Loading plans...</p>}
      {error && <p className="text-danger">{error}</p>}

      {/* Plans Grid */}
      <div className="row">
        {filteredPlans.map(plan => (
          <div key={plan.id} className="col-md-4 mb-4">
            <PlanCard
              plan={plan}
              onViewDetails={() => setSelectedPlanId(plan.id)}
            />
          </div>
        ))}
      </div>

      {/* Plan Detail Modal */}
      {selectedPlanId && (
        <PlanModal
          planId={selectedPlanId}
          onClose={() => setSelectedPlanId(null)}
        />
      )}
    </div>
  );
};

export default PlansPage;
