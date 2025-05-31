import type { PlanSummary } from '../hooks/usePlans';

interface PlanCardProps {
  plan: PlanSummary;
  onViewDetails: () => void;
}

const PlanCard: React.FC<PlanCardProps> = ({ plan, onViewDetails }) => {
  return (
    <div className="card h-100 shadow-sm">
      <div className="card-body d-flex flex-column">
        <h5 className="card-title">{plan.name}</h5>
        <h6 className="card-subtitle mb-2 text-muted">{plan.type}</h6>
        <p className="card-text mb-4">
          Price: <strong>${plan.price.toFixed(2)}</strong>
        </p>
        <button
          type="button"
          className="btn btn-primary mt-auto"
          onClick={onViewDetails}
          aria-label={`View details for ${plan.name}`}
        >
          View Details
        </button>
      </div>
    </div>
  );
};

export default PlanCard;