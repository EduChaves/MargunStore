import { Address } from "./Address";
import { Bag } from "./Bag";

export interface Client {
    id?: number;
    name: string;
    active?: boolean;
    bag?: Bag;
    addresses: Address[]
}