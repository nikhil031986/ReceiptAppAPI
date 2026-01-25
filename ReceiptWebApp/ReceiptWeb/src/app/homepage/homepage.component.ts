import { Component,OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LocalStorageService } from '../service/local-storage.service';
import { WingsService } from '../service/wings.service';
import { NgFor } from '@angular/common';

declare var c3: any;
@Component({
  selector: 'app-homepage',
  imports: [NgFor],
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
    
    // if (!this.IsUserLogin) {
    //   this.router.navigate(['/login']);
    // }
  }
  
  CreateChart():void{
    var chart = c3.generate({
        bindto: '#visitor',
        data: {
            columns: [
                ['Other', 30],
                ['Desktop', 10],
                ['Tablet', 40],
                ['Mobile', 50],
            ],

            type: 'donut',
        },
        donut: {
            label: {
                show: false
            },
            title: "Our visitor",
            width: 20,

        },

        legend: {
            hide: true
                //or hide: 'data1'
                //or hide: ['data1', 'data2']
        },
        color: {
            pattern: ['#eceff1', '#745af2', '#26c6da', '#1e88e5']
        }
    });
  }

  getAllWings(): void {
    if(!this.IsUserLogin){
      return;
    }
    if(this.wings.length > 0){
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
  openWingDetails(wingId: number): void {
    if(wingId <= 0){
      return;
    }
    this.router.navigate(['/wing-details', wingId]);
  }
}