import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders,withFetch } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LocalStorageService } from './local-storage.service';
import { AuthService } from '../auth.service';

@Injectable({
  providedIn: 'root'
})

export class SitesService {

  private apiURl = 'http://localhost:5179/api';
  private token: string | null = '';

  constructor(private http: HttpClient,
    private localStorageService: LocalStorageService,
    private authService: AuthService) 
  { }

   getHttpOptions() {
    this.token = this.authService.getToken();
    const headers = new HttpHeaders({ 
      'Content-Type': 'application/json; charset=utf-8',  
      'X-API-KEY':'C10D6AB6-8CBF-45F9-A5C2-4769CE171DF9',
      'Authorization': `Bearer ${this.token}`
    });
    return { headers: headers };
  }

  getSitesList(): Observable<any> {
      return this.http.get(this.apiURl+"/UserMaster/GetUserSite/"+this.localStorageService.getUserId(), this.getHttpOptions());
  }

  getAllSitesList(): Observable<any> {
      return this.http.get(this.apiURl+"/Site/GetSite", this.getHttpOptions());
  }
}
