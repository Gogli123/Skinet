import { IProduct } from "./Product"

export interface IPagination {
    index: number
    size: number
    count: number
    data: IProduct[]
  }