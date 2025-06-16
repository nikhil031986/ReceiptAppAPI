import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

const API_URL = 'http://localhost:8080/api/test/';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8','XApiKey':'pgH7QzFHJx4w46fI~5Uzi4RvtTwlEXp' })
};

@Injectable({
  providedIn: 'root'
})
export class UserServicesService {
  private isLogin = new BehaviorSubject<boolean>(false);
  private TOKEN_KEY="userLogin";
  constructor(private http: HttpClient) { }

  setUserLogin(){
    window.sessionStorage.removeItem(this.TOKEN_KEY);
    window.sessionStorage.setItem(this.TOKEN_KEY, "1");
    this.isLogin.next(true);
  }
  setUserLogOff(){
    window.sessionStorage.removeItem(this.TOKEN_KEY);
    this.isLogin.next(false);
  }
  userLogin(){
    var check = window.sessionStorage.getItem(this.TOKEN_KEY);
    if(check != undefined && check != null){
      if(check.includes("1")){
        this.isLogin.next(true);
      }
    }
    return this.isLogin.value;
  }
}
