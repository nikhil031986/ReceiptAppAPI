import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs/internal/operators/filter';
import { SitesService } from '../service/sites.service';
import { NgForOf, NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { LocalStorageService } from '../service/local-storage.service';

@Component({
  selector: 'app-routpage',
  standalone: true,
  imports: [NgForOf, FormsModule, NgIf],
  templateUrl: './routpage.component.html',
  styleUrl: './routpage.component.css'
})
export class RoutpageComponent implements OnInit {
  IsUserLogin = false;
  currentRoute: string = '';
  sites: any[] = [];
  selectSiteId: number = 0;

  constructor(private router: Router, 
   private activatedRoute: ActivatedRoute,
   private sitesService: SitesService,
   private localStorageService : LocalStorageService) { }
  
  ngOnInit(): void {
     this.localStorageService.isLoggedIn$.subscribe(status => {
      this.IsUserLogin = status;
      if(this.IsUserLogin){
      }
    });
    this.localStorageService.userId$.subscribe(userId => {
      if(userId > 0){
        this.getSitesList();
      }
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

  getSitesList(): void {
    if(!this.IsUserLogin){
      return;
    }
    this.sitesService.getSitesList().subscribe(
      (data) => {
        console.log('Sites list fetched:', data);
        data.forEach((dat: any) => {
          this.sites.push(dat.site);
          if(dat.isDefault){
            this.selectSiteId = dat.siteId;
          }
        });       
      },
      (error) => {
        console.error('Error fetching sites list:', error);
      }
    );
  }

}
