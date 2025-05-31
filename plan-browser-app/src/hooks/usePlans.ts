import { useState, useEffect } from 'react';
import * as plansApi from '../api/plansApi';

export interface PlanSummary {
  id: number;
  name: string;
  price: number;
  type: string;
}

export interface PlanDetail extends PlanSummary {
  dataLimit: string;
  validityDays: number;
  description: string;
}

// Hook to fetch all plans
export const usePlans = () => {
  const [plans, setPlans] = useState<PlanSummary[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    plansApi.getPlans()
      .then(setPlans)
      .catch(() => setError('Failed to load plans.'))
      .finally(() => setLoading(false));
  }, []);

  return { plans, loading, error };
};

// Hook to fetch a single plan by id
export const usePlanDetail = (id: number | null) => {
  const [plan, setPlan] = useState<PlanDetail | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    if (id === null) return;

    setLoading(true);
    plansApi.getPlanById(id)
      .then(setPlan)
      .catch(() => setError('Failed to load plan details.'))
      .finally(() => setLoading(false));
  }, [id]);

  return { plan, loading, error };
};
