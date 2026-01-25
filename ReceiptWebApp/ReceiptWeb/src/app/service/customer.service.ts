import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders,withFetch } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from '../auth.service';
import { LocalStorageService } from './local-storage.service';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

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

  getCustomerList(): Observable<any>{
    return this.http.get(this.apiURl+"/Customer/GetCustomerBySitId/"+this.localStorageService.getCurrentSiteId(), this.getHttpOptions());
  }

  getCustomer(customerId:number):Observable<any>{
    return this.http.get(this.apiURl+"/Customer/GetCustomerById/"+customerId, this.getHttpOptions());
  }

  getCustomerDetail(customerDetailId:number):Observable<any>{
    return this.http.get(this.apiURl+"/Customer/GetCustomerDetail/"+customerDetailId,this.getHttpOptions());
  }
  AddCustomer(customer:any):Observable<any>{
   //Customer
   return this.http.post(this.apiURl+"/Customer",customer,this.getHttpOptions());
  }
  UpdateCustomerCustomer(customer:any):Observable<any>{
    return this.http.post(this.apiURl+"/Customer/UpdateCustomer",customer,this.getHttpOptions());
  }
  submitcustomerDetails(customerDetail:any):Observable<any>{
    customerDetail.siteId=this.localStorageService.getCurrentSiteId();
    return this.http.post(this.apiURl+"/Customer/AddUpdateCustomerDetail",customerDetail,this.getHttpOptions());
  }

  deleteCustomerDetail(customerDetailId:number):Observable<any>{
    return this.http.delete(this.apiURl+"/Customer/DeleteCustomerDetail/"+customerDetailId,this.getHttpOptions());
  }
}
