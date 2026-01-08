import { Component, OnInit } from '@angular/core';
import { LocalStorageService } from '../service/local-storage.service';
import { WingsService } from '../service/wings.service';
import { NgFor,NgIf } from '@angular/common';
import { Router,ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-winglist',
  imports: [NgFor, NgIf],
  templateUrl:'./winglist.component.html',
  styleUrl: './winglist.component.css'
})
export class WinglistComponent implements OnInit  {

    IsUserLogin = false;
    currentSiteId: number = 0;
    wings: any[] = [];

    constructor (private localStorageService: LocalStorageService,
      private router: Router,
      private wingsService: WingsService,
      private route: ActivatedRoute) { }

      ngOnInit(): void {
        this.localStorageService.isLoggedIn$.subscribe(status => {
          this.IsUserLogin = status;
        });
        this.localStorageService.currentSiteId$.subscribe(siteId => {
          if(siteId > 0){
            this.currentSiteId = siteId;
            this.getAllWingArray();
          }
        });
    }

      getAllWingArray():void{
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

      openEditWing(wingMasterId:Number):void{
        const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/wing-details/'+wingMasterId; 
        this.router.navigate([returnUrl]);
      }
}
