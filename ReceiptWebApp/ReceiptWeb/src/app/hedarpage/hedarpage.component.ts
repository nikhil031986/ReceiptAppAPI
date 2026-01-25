import { Component, OnInit } from '@angular/core';
import { LocalStorageService } from '../service/local-storage.service';
import { Router, ActivatedRoute, NavigationEnd,RouterModule  } from '@angular/router';
import { NgIf } from '@angular/common';
import { filter } from 'rxjs';

  
@Component({
  selector: 'app-hedarpage',
  standalone: true,
  imports: [NgIf,RouterModule],
  templateUrl:'./hedarpage.component.html',
  styleUrls: ['./hedarpage.component.css']
})
export class HedarpageComponent implements OnInit {
  IsUserLogin = false;
  userName: string = '';
  currentRoute: string = '';

  constructor(private localStorageService: LocalStorageService,
   private router: Router, 
   private activatedRoute: ActivatedRoute,) { }

  ngOnInit(): void {
   this.localStorageService.isLoggedIn$.subscribe(status => {
      this.IsUserLogin = status;
    });
    this.localStorageService.userloginName$.subscribe(name => {
      this.userName = name;
    });
     this.router.events
      .pipe(filter(event => event instanceof NavigationEnd))
      .subscribe(() => {
        // Get the last child route (deepest active route)
        let route = this.activatedRoute;
        while (route.firstChild) {
          route = route.firstChild;
        }

        // Option 1: Get route path from route config
        this.currentRoute = route.routeConfig?.path || '';
      });
  }

  getUserLoginStatus(): boolean {
    return this.IsUserLogin;
  }
  
  activeTab(id:string):void{
    var getcontrol = document.getElementById(id);
    getcontrol?.classList.add('active');
  }

  logout() {
    this.localStorageService.logout();
    this.getUserLoginStatus();
    this.router.navigate(['/login']);
  }
}