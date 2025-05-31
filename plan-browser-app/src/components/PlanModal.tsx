import { useEffect } from "react";
import { usePlanDetail } from "../hooks/usePlans";

interface PlanModalProps {
  planId: number | null;
  onClose: () => void;
}

const PlanModal: React.FC<PlanModalProps> = ({ planId, onClose }) => {
  const { plan, loading, error } = usePlanDetail(planId);

  // Close modal on ESC key press
  useEffect(() => {
    const handleKeyDown = (e: KeyboardEvent) => {
      if (e.key === "Escape") {
        onClose();
      }
    };
    if (planId !== null) {
      window.addEventListener("keydown", handleKeyDown);
    }
    return () => window.removeEventListener("keydown", handleKeyDown);
  }, [planId, onClose]);

  if (planId === null) {
    return null; // Modal closed
  }

  return (
    <div
      className="modal fade show"
      style={{ display: "block", backgroundColor: "rgba(0,0,0,0.5)" }}
      tabIndex={-1}
      role="dialog"
      aria-modal="true"
      aria-labelledby="planModalTitle"
    >
      <div className="modal-dialog modal-dialog-centered" role="document">
        <div className="modal-content">
          <div className="modal-header">
            <h5 className="modal-title" id="planModalTitle">
              {loading ? "Loading..." : plan?.name || "Plan Details"}
            </h5>
            <button
              type="button"
              className="btn-close"
              aria-label="Close"
              onClick={onClose}
            />
          </div>
          <div className="modal-body">
            {loading && <p>Loading plan details...</p>}

            {error && (
              <div className="alert alert-danger" role="alert">
                {error}
              </div>
            )}

            {!loading && !error && plan && (
              <div>
                <p>
                  <strong>Price:</strong> ${plan.price.toFixed(2)}
                </p>
                <p>
                  <strong>Type:</strong> {plan.type}
                </p>
                <p>
                  <strong>Data Limit:</strong> {plan.dataLimit}
                </p>
                <p>
                  <strong>Validity:</strong> {plan.validityDays} days
                </p>
                <p>
                  <strong>Description:</strong> {plan.description}
                </p>
              </div>
            )}
          </div>
          <div className="modal-footer">
            <button
              type="button"
              className="btn btn-secondary"
              onClick={onClose}
            >
              Close
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default PlanModal;
