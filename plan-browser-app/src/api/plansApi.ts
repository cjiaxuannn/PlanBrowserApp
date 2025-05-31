import axios from 'axios';
import type { PlanSummary, PlanDetail } from '../hooks/usePlans';

const API_BASE = 'http://localhost:5228'; // your backend URL

export const getPlans = async (): Promise<PlanSummary[]> => {
  const response = await axios.get(`${API_BASE}/plans`);
  return response.data;
};

export const getPlanById = async (id: number): Promise<PlanDetail> => {
  const response = await axios.get(`${API_BASE}/plans/${id}`);
  return response.data;
};