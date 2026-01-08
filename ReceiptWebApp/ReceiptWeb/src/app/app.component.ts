import { Component,OnInit,OnDestroy } from '@angular/core';
import { NavigationEnd, Router,RouterOutlet } from '@angular/router';
import { AuthService } from './auth.service';
import { HedarpageComponent } from './hedarpage/hedarpage.component';
import { RoutpageComponent } from "./routpage/routpage.component";
import { filter,takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';
import { LocalStorageService } from './service/local-storage.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HedarpageComponent, RoutpageComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, OnDestroy {
  private destroy$ = new Subject<void>(); // For unsubscribing  
  title = 'ReceiptWeb';
  private readonly PUBLIC_ROUTES = ['/login', '/register', '/forgot-password'];  
  private readonly DEFAULT_PROTECTED_ROUTE = '/home'; // Redirect here after login  
  private readonly DEFAULT_PUBLIC_ROUTE = '/login'; // Redirect here if unauthenticated

  constructor(private authService: AuthService, 
    private router: Router,
    private localStorageService: LocalStorageService) {}
  ngOnInit(): void {
    this.detectRouteChanges();
  }
  private detectRouteChanges(): void {
   this.router.events  
      .pipe(  
        filter(event => event instanceof NavigationEnd), // Only handle completed navigations  
        takeUntil(this.destroy$) // Unsubscribe when component is destroyed  
      )  
      .subscribe((event: NavigationEnd) => {  
        const currentUrl = event.urlAfterRedirects; // Get the final URL (after redirects)  
        const isAuthenticated = this.authService.isAuthenticated();  
        const isTokenExpired = this.authService.isTokenExpired();

        if(isAuthenticated && !isTokenExpired){
            this.localStorageService.setToken('');
            this.localStorageService.setUserId(this.authService.getUserId()!);
            this.localStorageService.setUserName(this.authService.getUserName()!);
            this.localStorageService.setCurrentSiteId(this.authService.getSiteId()!);
        }
   // Avoid infinite redirects: Skip if already on the target route  
      if (  
        (!isAuthenticated && currentUrl === this.DEFAULT_PUBLIC_ROUTE) ||  
        (isAuthenticated && currentUrl === this.DEFAULT_PROTECTED_ROUTE)  
      ) {  
        return;  
      }  
 
      // Redirect unauthenticated users from protected routes  
      if (!isAuthenticated && !this.isPublicRoute(currentUrl)) {  
        this.router.navigate([this.DEFAULT_PUBLIC_ROUTE], {  
          queryParams: { returnUrl: currentUrl } // Let login page know where to redirect after login  
        });  
      }  
 
      // Redirect authenticated users from public routes  
      else if (isAuthenticated && this.isPublicRoute(currentUrl)) {  
        this.router.navigate([this.DEFAULT_PROTECTED_ROUTE]);  
      }   
      });  
  }

  private isPublicRoute(url: string): boolean {  
      return this.PUBLIC_ROUTES.some(route => url.startsWith(route));  
  }  
  ngOnDestroy(): void {  
    this.destroy$.next();  
    this.destroy$.complete(); // Clean up subscription  
  }  
}
