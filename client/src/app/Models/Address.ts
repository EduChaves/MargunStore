export interface Address {
    id?: number;
    street?: string;
    number?: number;
    district?: string;
    city?: string;
    state?: string;
    complement?: string;
    cep?: number;
    active?: boolean;
}