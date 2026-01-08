import { Injectable, Inject, PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { NG_ASYNC_VALIDATORS } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class AuthService implements CanActivate {

  private readonly TOKEN_KEY = 'auth_token';
  private readonly USER_Id_KEY = 'user_id';
  private readonly USER_Name_KEY = 'user_name';
  private readonly SITE_Id_KEY = 'site_id';

  constructor(private router: Router, @Inject(PLATFORM_ID) private platformId: Object) { }

  setToken(token: string): void {
    if (isPlatformBrowser(this.platformId)) {
      localStorage.setItem(this.TOKEN_KEY, token);
    }
  }

  setUserId(userId: number): void {
    if (isPlatformBrowser(this.platformId)) {
      localStorage.setItem(this.USER_Id_KEY, userId.toString());
    }
  }

  setUserName(userName: string): void {
    if (isPlatformBrowser(this.platformId)) {
      localStorage.setItem(this.USER_Name_KEY, userName);
    } 
  }

  setSiteId(siteId: number): void {
    if (isPlatformBrowser(this.platformId)) {
      localStorage.setItem(this.SITE_Id_KEY, siteId.toString());
    }
  }

  isTokenExpired(): boolean | null {
    const token = this.getToken();
    if (!token) {
      return null;
    }

    try {
      // support tokens stored as "Bearer <token>"
      const raw = token.startsWith('Bearer ') ? token.split(' ')[1] : token;
      const parts = raw.split('.');
      if (parts.length !== 3) {
        return null;
      }

      const base64Url = parts[1];
      const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
      const padded = base64.padEnd(base64.length + (4 - (base64.length % 4)) % 4, '=');
      const payloadJson = atob(padded);
      const payload = JSON.parse(payloadJson);

      if (typeof payload.exp !== 'number') {
        return null;
      }

      return payload.exp * 1000 < Date.now();
    } catch (e) {
      console.warn('isTokenExpired: failed to parse token', e);
      return null;
    }
  }

  getToken(): string | null {
    if (isPlatformBrowser(this.platformId)) {
      return localStorage.getItem(this.TOKEN_KEY);
    }
    return null;
  }

  getUserId(): number | null {
    if (isPlatformBrowser(this.platformId)) {
      const userId = localStorage.getItem(this.USER_Id_KEY);
      return userId ? parseInt(userId, 10) : null;
    } 
    return null;
  }

  getUserName(): string | null {
    if (isPlatformBrowser(this.platformId)) {
      return localStorage.getItem(this.USER_Name_KEY);
    }
    return null;
  }

  getSiteId(): number | null {
    if (isPlatformBrowser(this.platformId)) {
      const siteId = localStorage.getItem(this.SITE_Id_KEY);
      return siteId ? parseInt(siteId, 10) : null;
    }
    return null;
  }

  clearToken(): void {
    if (isPlatformBrowser(this.platformId)) {
      localStorage.removeItem(this.TOKEN_KEY);
      localStorage.removeItem(this.USER_Id_KEY);
      localStorage.removeItem(this.USER_Name_KEY);
      localStorage.removeItem(this.SITE_Id_KEY);
    }
  }

  isAuthenticated(): boolean {
    const token = this.getToken();
    return !!token;
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree {
    const isAuthenticated = this.isAuthenticated();
    if (isAuthenticated) {
      return true;
    } else {
      return this.router.createUrlTree(['/login'], {
        queryParams: { returnUrl: state.url }
      });
    }
  }
}
