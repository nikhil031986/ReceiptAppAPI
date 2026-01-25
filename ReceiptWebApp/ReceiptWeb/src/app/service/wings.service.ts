import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders,withFetch } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from '../auth.service';
import { LocalStorageService } from './local-storage.service';

@Injectable({
  providedIn: 'root'
})
export class WingsService {

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

  getWingsList(): Observable<any> {
    return this.http.get(this.apiURl+"/Wing/GetwingBySiteId/"+this.localStorageService.getCurrentSiteId(), this.getHttpOptions());
  }
  getwingById(wingId: number): Observable<any> {
    return this.http.get(this.apiURl+"/Wing/GetwingById/"+wingId, this.getHttpOptions());
  }
  
  getWingDetailsById(wingDetailId: number): Observable<any> {
    return this.http.get(this.apiURl+"/Wing/GetWingDetailsById/"+wingDetailId, this.getHttpOptions());
  }
  addNewWing(wing:any):Observable<any>{
    var currentSitId =this.localStorageService.getCurrentSiteId();
    wing.siteId=currentSitId;
    return this.http.post(this.apiURl+"/Wing", wing, this.getHttpOptions());
  }
  updateWing(wingData: any): Observable<any> {
    var currentSiteId = this.localStorageService.getCurrentSiteId();
    wingData.siteId = currentSiteId;
    return this.http.post(this.apiURl+"/Wing/Updatewing", wingData, this.getHttpOptions());
  }

  submitWingDetails(wingDetailsData: any): Observable<any> {
    var SiteId = this.localStorageService.getCurrentSiteId();
    wingDetailsData.siteId = SiteId;
    return this.http.post(this.apiURl+"/Wing/AddAndUpdateWingDetails", wingDetailsData, this.getHttpOptions());
  }

  deleteWingDetail(wingDetailId: number): Observable<any> {
    return this.http.delete(this.apiURl+"/Wing/DeleteWingDetail/"+wingDetailId, this.getHttpOptions());
  }
}
