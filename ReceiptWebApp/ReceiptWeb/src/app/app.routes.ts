import { Routes } from '@angular/router';
import { AuthService } from './auth.service';

export const routes: Routes = [
    {path: 'login', loadComponent: () => import('./loginpage/loginpage.component').then(m => m.LoginpageComponent)},
    {path: 'home', loadComponent: () => import('./homepage/homepage.component').then(m => m.HomepageComponent),canActivate:[AuthService]},
    {path: 'wing', loadComponent: () => import('./winglist/winglist.component').then(m => m.WinglistComponent),canActivate:[AuthService]},
    {path: 'wing-details/:id', loadComponent: () => import('./wingdetail/wingdetail.component').then(m => m.WingdetailComponent),canActivate:[AuthService]},
    {path: 'customerlist',loadComponent:() => import('./customer/customer.component').then(m => m.CustomerComponent),canActivate:[AuthService]},
    {path: 'customer/:id',loadComponent:() => import('./customer-details/customer-details.component').then(m => m.CustomerDetailsComponent),canActivate:[AuthService]},
    {path: 'receiptlist',loadComponent:() => import('./receipt-list/receipt-list.component').then(m => m.ReceiptListComponent),canActivate:[AuthService]},
    {path: 'userlist',loadComponent:() => import('./user-list/user-list.component').then(m => m.UserListComponent),canActivate:[AuthService]},
    {path: 'userdetail/:id',loadComponent:() => import('./user-detail/user-detail.component').then(m => m.UserDetailComponent),canActivate:[AuthService]},
];
