import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { DOCUMENT } from '@angular/common';
import { AuthService } from '../auth.service';

@Injectable({
  providedIn: 'root'
})

export class LocalStorageService {
  private loggedIn = new BehaviorSubject<boolean>(false);
  private userloginName = new BehaviorSubject<string>('');
  private userId = new BehaviorSubject<number>(0);
  private currentSiteId = new BehaviorSubject<number>(0);
  isLoggedIn$: Observable<boolean> = this.loggedIn.asObservable();
  userloginName$: Observable<string> = this.userloginName.asObservable();
  userId$: Observable<number> = this.userId.asObservable();
  currentSiteId$: Observable<number> = this.currentSiteId.asObservable();
  constructor(
   private authService: AuthService) {
  }  

  setToken(token: string) {
    this.loggedIn.next(true);
  }

  setUserName(username: string) {
    this.userloginName.next(username);
  }

  setUserId(id: number) {
    this.userId.next(id);
  }

  setCurrentSiteId(siteId: number) {
    this.currentSiteId.next(siteId);
  }

  getUserName(): string | null {
    return this.userloginName.getValue();
  }
  getUserId(): number {
    return this.userId.getValue();
  }
  getCurrentSiteId(): number {
    return this.currentSiteId.getValue();
  }
  
  logout() {
    this.authService.clearToken();
    this.loggedIn.next(false);
    this.userloginName.next('');
    this.userId.next(0);
  }

}
