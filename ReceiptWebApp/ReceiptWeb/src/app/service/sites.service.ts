import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders,withFetch } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LocalStorageService } from './local-storage.service';

@Injectable({
  providedIn: 'root'
})

export class SitesService {

  private apiURl = 'http://localhost:5179/api';
  private token: string | null = '';

  constructor(private http: HttpClient,private localStorageService: LocalStorageService) 
  { }

   getHttpOptions() {
    this.token = this.localStorageService.getToken();
    const headers = new HttpHeaders({ 
      'Content-Type': 'application/json; charset=utf-8',  
      'XApiKey':'pgH7QzFHJx4w46fI~5Uzi4RvtTwlEXp',
      'Authorization': `Bearer ${this.token}`
    });
    return { headers: headers };
  }

  getSitesList(): Observable<any> {
    return this.http.get(this.apiURl+"/UserMaster/GetUserSite/"+this.localStorageService.getUserId(), this.getHttpOptions());
  }
}
