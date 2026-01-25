import { Component, OnInit } from '@angular/core';
import { LocalStorageService } from '../service/local-storage.service';
import { WingsService } from '../service/wings.service';
import { NgFor,NgIf,NgClass,SlicePipe } from '@angular/common';
import {NgxNavigateBackService} from 'ngx-navigate-back';
import { Router,ActivatedRoute } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { LargeNumberLike } from 'crypto';

@Component({
  selector: 'app-winglist',
  imports: [NgFor, NgIf,FormsModule,NgClass,SlicePipe],
  templateUrl:'./winglist.component.html',
  styleUrl: './winglist.component.css'
})
export class WinglistComponent implements OnInit  {

    IsUserLogin = false;
    currentSiteId: number = 0;
    wings: any[] = [];
    searchText: string = '';
    showIdColumn:boolean=false;
    currentPage: number = 1;
    total: number = 0;
    recordNumber:number=0;
    endrecordNumber:number=0;
    limit: number = 5;
    pages: number[] = [];

    constructor (private localStorageService: LocalStorageService,
      private router: Router,
      private wingsService: WingsService,
      private route: ActivatedRoute,
      private ngxNavigateBackService:NgxNavigateBackService) {
        this.ngxNavigateBackService.recordUrlHistory();
       }

      ngOnInit(): void {
        this.showIdColumn= false;
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

    changePage(page: number): void {
      this.currentPage = page;
      this.UpdatePagesData();
    }
    prevous():void{
      var minpage = this.pages.reduce((max,current)=> Math.min(max,current),0);
      if(minpage>=(this.currentPage-1)){
        return;
      }
      this.currentPage = this.currentPage-1;
      this.UpdatePagesData();
    }
    UpdatePagesData():void{
      const startIndex = (this.currentPage - 1) * this.limit;
      const endIndex = startIndex + this.limit;
      this.recordNumber = startIndex;
      this.endrecordNumber = endIndex;
    }
    nextpage():void{
      var maxpage = this.pages.reduce((max,current)=> Math.max(max,current),0);
      if(maxpage<(this.currentPage+1)){
        return;
      }
      this.currentPage = this.currentPage+1;
      this.UpdatePagesData();
    }

    backPage():void{
      var backlocation =this.ngxNavigateBackService.getHistory()[0];
      this.router.navigate([backlocation]);
    }
    openWingDetails():void{
        const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/wing-details/'+0; 
        this.router.navigate([returnUrl]);
    }

    get filterData(){
      if(!this.searchText.trim()){
        return this.wings;
      }
      const lowerSearch = this.searchText.toLocaleLowerCase();
      return this.wings.filter((item:any)=>
        Object.values(item).some(val=> String(val).toLocaleLowerCase().includes(lowerSearch)
        )
      );
    }

    range(start: number, end: number): number[] {
      return [...Array(end).keys()].map((el) => el + start);
    }

    getAllWingArray():void{
      this.wings=[];
      this.wingsService.getWingsList().subscribe(
          (response) => {
            this.wings = response;
            this.total=this.wings.length;
            this.limit=5;
            this.endrecordNumber= this.limit;
            const pagesCount = Math.ceil(this.total / this.limit);
            this.pages = this.range(1, pagesCount);
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
