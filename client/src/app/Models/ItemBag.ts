import { Product } from "./Product";

export interface ItemBag {
    id: number;
    quantity: number;
    products: Product[]
    active: boolean
}