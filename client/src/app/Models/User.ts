import { Client } from "./Client";
import { Role } from "./Role";

export interface User{
    id?: string;
    email: string;
    password: string;
    confirmPassword: string;
    client: Client
    role?: Role;
    active?: boolean;
}