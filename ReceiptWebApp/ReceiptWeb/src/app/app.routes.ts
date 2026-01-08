import { Routes } from '@angular/router';
import { AuthService } from './auth.service';

export const routes: Routes = [
    {path: 'login', loadComponent: () => import('./loginpage/loginpage.component').then(m => m.LoginpageComponent)},
    {path: 'home', loadComponent: () => import('./homepage/homepage.component').then(m => m.HomepageComponent),canActivate:[AuthService]},
    {path: 'wing', loadComponent: () => import('./winglist/winglist.component').then(m => m.WinglistComponent),canActivate:[AuthService]},
    {path: 'wing-details/:id', loadComponent: () => import('./wingdetail/wingdetail.component').then(m => m.WingdetailComponent),canActivate:[AuthService]},
];
