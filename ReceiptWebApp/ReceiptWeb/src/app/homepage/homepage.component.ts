import { Component,OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LocalStorageService } from '../service/local-storage.service';
import { WingsService } from '../service/wings.service';
import { NgIf,NgFor } from '@angular/common';
@Component({
  selector: 'app-homepage',
  imports: [NgIf,NgFor],
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.css'
})
export class HomepageComponent implements OnInit {
   IsUserLogin = false;
   currentSiteId: number = 0;
   wings: any[] = [];
  constructor (private localStorageService: LocalStorageService,
   private router: Router,
   private wingsService: WingsService) { }

  ngOnInit(): void {
    this.localStorageService.isLoggedIn$.subscribe(status => {
      this.IsUserLogin = status;
    });
    this.localStorageService.currentSiteId$.subscribe(siteId => {
      if(siteId > 0){
       this.currentSiteId = siteId;
       this.getAllWings();
      }
    });
    if (!this.IsUserLogin) {
      this.router.navigate(['/login']);
    }
  }
  
  getAllWings(): void {
    if(!this.IsUserLogin){
      return;
    }
    this.wings=[];
    this.wingsService.getWingsList().subscribe(
      (response) => {
        this.wings = response;
        console.log('Wings list fetched:', this.wings);
      },
      (error) => {
        console.error('Error fetching wings:', error);
      }
    );
  }

}