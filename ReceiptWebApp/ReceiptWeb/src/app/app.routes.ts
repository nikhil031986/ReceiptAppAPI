import { Routes } from '@angular/router';

export const routes: Routes = [
    {path: 'login', loadComponent: () => import('./loginpage/loginpage.component').then(m => m.LoginpageComponent)},
    {path: 'home', loadComponent: () => import('./homepage/homepage.component').then(m => m.HomepageComponent)},
];
