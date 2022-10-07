import { Category } from "./Category";
import { Image } from "./Image";

export interface Product{
    id: number;
    name: string;
    description: string;
    length: string;
    value: number;
    quantity: number;
    active: boolean;
    categoryId: number;
    category: Category;
    images: Image[];
}