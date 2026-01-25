import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders,withFetch } from '@angular/common/http';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8','XApiKey':'pgH7QzFHJx4w46fI~5Uzi4RvtTwlEXp' })
};

@Injectable({
  providedIn: 'root'
})

export class LoginService {
  private apiURl = 'http://localhost:5179/api/UserMaster';
 
    getHttpOptions() {
    const headers = new HttpHeaders({ 
      'Content-Type': 'application/json; charset=utf-8',  
      'X-API-KEY':'C10D6AB6-8CBF-45F9-A5C2-4769CE171DF9',
    });
    return { headers: headers };
  }
  constructor(private http: HttpClient) { }
  userLogin(username: string, password: string): Observable<any> {
    return this.http.post(this.apiURl+"/Login?emailId="+username+"&password="+password, this.getHttpOptions());
  }

}
