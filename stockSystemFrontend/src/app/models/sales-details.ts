import { salesListDetails } from "./product-sale-list";

export interface Sale {
    id: number;
    createdAt: string;
    total: number;
    username: string;
    salesDetails: salesListDetails[]
  }