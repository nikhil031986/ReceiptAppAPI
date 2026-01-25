import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders,withFetch } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from '../auth.service';
import { LocalStorageService } from './local-storage.service';

@Injectable({
  providedIn: 'root'
})
export class ReceiptServiceService {
  
  private apiURl = 'http://localhost:5179/api';
  private token: string | null = '';

  constructor(private http: HttpClient,
    private authService: AuthService,
    private localStorageService: LocalStorageService) { }
  
  getHttpOptions() {
    this.token = this.authService.getToken();
    const headers = new HttpHeaders({ 
      'Content-Type': 'application/json; charset=utf-8',  
      'X-API-KEY':'C10D6AB6-8CBF-45F9-A5C2-4769CE171DF9',
      'Authorization': `Bearer ${this.token}`
    });
    return { headers: headers };
  }

  getReceiptsList():Observable<any>{
    return this.http.get(this.apiURl+"/ReceipDetails/GetReceiptDetailsBySiteId/"+this.localStorageService.getCurrentSiteId(),this.getHttpOptions());
  }
}
