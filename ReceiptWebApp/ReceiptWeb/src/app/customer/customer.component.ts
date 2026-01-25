import { Component, OnInit } from '@angular/core';
import { LocalStorageService } from '../service/local-storage.service';
import { Router } from '@angular/router';
import { CustomerService } from '../service/customer.service';
import { ActivatedRoute } from '@angular/router';
import { NgFor,NgIf,NgClass,SlicePipe } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-customer',
  imports: [NgFor,NgIf,FormsModule,NgClass,SlicePipe],
  templateUrl:'./customer.component.html',
  styleUrl: './customer.component.css'
})

export class CustomerComponent implements OnInit {

  IsUserLogin = false;
  currentSiteId: number = 0;
  customer: any[] = [];
  showIdColumn:boolean=false;
  searchText:string='';
  currentPage: number = 1;
  total: number = 0;
  recordNumber:number=0;
  endrecordNumber:number=0;
  limit: number = 5;
  pages: number[] = [];

  constructor(private localStorageService: LocalStorageService,
      private router: Router,
      private customerservice: CustomerService,
      private route: ActivatedRoute){}

  ngOnInit(): void {
    this.showIdColumn= false;
    this.localStorageService.isLoggedIn$.subscribe(status => {
      this.IsUserLogin = status;
    });
    this.localStorageService.currentSiteId$.subscribe(siteId => {
      if(siteId > 0){
        this.currentSiteId = siteId;
      }
    });
    this.getCustomerList();
  }

  OpenWingDetails(wingMasterId:Number):void{
     const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/wing-details/'+wingMasterId; 
      this.router.navigate([returnUrl]);
  }

  AddNewCustomer():void{
    const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/customer/'+0; 
    this.router.navigate([returnUrl]);
  }

  EditCustomer(customerId:Number):void{
    //customer
    const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/customer/'+customerId; 
    this.router.navigate([returnUrl]);
  }

  get filterData(){
    if(!this.searchText.trim()){
      return this.customer;
    }
    const lowerSearch = this.searchText.toLocaleLowerCase();
    return this.customer.filter((item:any)=>
      Object.values(item).some(val=> String(val).toLocaleLowerCase().includes(lowerSearch)
      )
    );
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

  getCustomerList():void{
    this.customer=[];
    this.customerservice.getCustomerList().subscribe(
        (response) => {
          const customerList:any[] = response;
          customerList.forEach((element) => {
            let rowcustomerName ='';
            var mainCustomer =element.customerDetails.filter((m: any)=> m.isMain === true); 
             if(mainCustomer.length >0){
              rowcustomerName=mainCustomer[0].customerName;
             }
            var wing_Name = element.wingMaster.displayName;
            var flat_no = element.wingDetail.flatNo;
            var customerRow={
              customerMasterId:element.customerMasterId,
              wingMasterId:element.wingMasterId,
              wingDetailId:element.wingDetailId,
              customerName:rowcustomerName,
              wingName:wing_Name,
              flatNo:flat_no,
              isBanakhat:element.isBanakhat,
              banakhatNumber:element.banakhatNumber,
              banakhatDate:element.banakhatDate,
              finacialName:element.finacialName,
              dastavgNo:element.dastavgNo,
              dastavgDate:element.dastavgDate
            }
            this.customer.push(customerRow);
            
          });
          this.total=this.customer.length;
          this.limit=5;
          this.endrecordNumber= this.limit;
          const pagesCount = Math.ceil(this.total / this.limit);
          this.pages = this.range(1, pagesCount);
          console.log('Wings list fetched:', this.customer);
        },
        (error) => {
          console.error('Error fetching wings:', error);
        }
      );
  }

  range(start: number, end: number): number[] {
      return [...Array(end).keys()].map((el) => el + start);
  }
}
