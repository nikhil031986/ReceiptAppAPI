import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { DOCUMENT } from '@angular/common';

@Injectable({
  providedIn: 'root'
})

export class LocalStorageService {
  private loggedIn = new BehaviorSubject<boolean>(false);
  private userloginName = new BehaviorSubject<string>('');
  private userId = new BehaviorSubject<number>(0);
  private localStorage: Storage;
  isLoggedIn$: Observable<boolean> = this.loggedIn.asObservable();
  userloginName$: Observable<string> = this.userloginName.asObservable();
  userId$: Observable<number> = this.userId.asObservable();
  constructor(@Inject(DOCUMENT) private document: Document, private http: HttpClient, private router: Router) {
    this.localStorage = this.document.defaultView?.localStorage!;
  }  

  setToken(token: string) {
    this.localStorage.setItem('token', token);
    this.loggedIn.next(true);
  }

  setUserName(username: string) {
    this.userloginName.next(username);
  }

  setUserId(id: number) {
    this.userId.next(id);
  }

  getToken(): string | null {
    return this.localStorage ? this.localStorage.getItem('token') : null;
  }
  getUserName(): string | null {
    return this.userloginName.getValue();
  }
  getUserId(): number {
    return this.userId.getValue();
  }
   logout() {
    this.localStorage.removeItem('token');
    this.loggedIn.next(false);
    this.userloginName.next('');
    this.userId.next(0);
  }

}
