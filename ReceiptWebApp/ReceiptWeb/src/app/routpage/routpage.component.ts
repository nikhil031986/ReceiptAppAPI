import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router,RouterModule } from '@angular/router';
import { filter } from 'rxjs/internal/operators/filter';
import { SitesService } from '../service/sites.service';
import { NgForOf, NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { LocalStorageService } from '../service/local-storage.service';
import { AuthService } from '../auth.service';
import { CapitalizePipePipe } from '../capitalize-pipe.pipe';

@Component({
  selector: 'app-routpage',
  standalone: true,
  imports: [NgForOf, FormsModule, NgIf,CapitalizePipePipe,RouterModule],
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
   private localStorageService : LocalStorageService,
   private authService: AuthService) { }
  
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
        this.currentRoute = route.routeConfig?.path?.split('/')[0] || '';
      });
  }

  getSitesList(): void {
    if(!this.IsUserLogin || this.localStorageService.getUserId() === null || 
   this.localStorageService.getUserId()===0){
      return;
    }
    this.sites=[];
    this.sitesService.getSitesList().subscribe(
      (data) => {
        console.log('Sites list fetched:', data);
        data.forEach((dat: any) => {
          this.sites.push(dat.site);
          if(dat.isDefault){
            this.selectSiteId = dat.siteId;
            this.localStorageService.setCurrentSiteId(dat.siteId);
            this.authService.setSiteId(dat.siteId);
          }
        });       
      },
      (error) => {
        console.error('Error fetching sites list:', error);
      }
    );
  }

  SiteChange(event: any): void {
    const selectedSiteId = Number(this.selectSiteId);
    if (isNaN(selectedSiteId)) {
      console.error('Invalid site ID selected:', this.selectSiteId);
      return;
    }
    if(selectedSiteId <= 0){
      return;
    }
    this.authService.setSiteId(selectedSiteId);
  }
}
