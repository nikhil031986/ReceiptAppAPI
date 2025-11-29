export interface User {
    Id: string;
    UserName: string;
    Email: string;
    Roles: any[];
    IsVerified: boolean;
    JWToken?: string;
    RefreshToken?: string;
}