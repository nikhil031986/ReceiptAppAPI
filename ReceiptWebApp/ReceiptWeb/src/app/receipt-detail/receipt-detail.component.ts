import { Component,OnInit } from '@angular/core';
import { Router,ActivatedRoute } from '@angular/router';
import { UserServiceService } from '../service/user-service.service';
import { LocalStorageService } from '../service/local-storage.service';
import { FormsModule} from '@angular/forms';
import { NgFor,NgIf } from '@angular/common';
import { ToastrService } from 'ngx-toastr';
import { SitesService } from '../service/sites.service';
import { WingsService } from '../service/wings.service';
import { CustomerService } from '../service/customer.service';
import { ReceiptServiceService } from '../service/receipt-service.service';
import e from 'express';

@Component({
  selector: 'app-receipt-detail',
  imports: [FormsModule, NgFor, NgIf],
  templateUrl: './receipt-detail.component.html',
  styleUrl: './receipt-detail.component.css'
})
export class ReceiptDetailComponent implements OnInit {
  private isUserLogin = false;
  private receiptId: number = 0
  private receiptDetails: any;
  wingMasterList: any[] = [];
  wingDetailList: any[] = [];
  customerList: any[] = [];
  receiptdetailsForm={
    receiptId: 0,
    wingMasterId: 0,
    wingDetailId: 0,
    customerId: 0,
    receiptNo: '',
    receiptDate: '',
    cheqNeftRtgsNo: '',
    bankName:'',
    branchName:'',
    receivedAs:'',
    amount: 0,
    amountInWord:'',
    PaymentDate: '',
    isCancel: false,
    IsPrint:false,
    description: '',
    siteId:0
  };
  constructor(private userServiceService: UserServiceService,
    private localStorageService: LocalStorageService,
    private router: Router,
    private route: ActivatedRoute,
    private toastr: ToastrService,
    private sitesService: SitesService,
    private wingsService: WingsService,
    private customerService: CustomerService,
    private receiptService: ReceiptServiceService
  ) { }
  ngOnInit(): void {
    this.receiptId = Number(this.route.snapshot.paramMap.get('id'));
    this.localStorageService.isLoggedIn$.subscribe(status => {
      this.isUserLogin = status;
    });
    if (!this.isUserLogin) {
      this.router.navigate(['/login']);
    }
    this.getWingMasterList();
    this.getReceiptDetails();
  } 
  getReceiptDetails():void{
    this.receiptDetails={};
    if(this.receiptId > 0){
      this.receiptService.getReceiptById(this.receiptId).subscribe(
        (response) => {
          let receiptData = response;
          this.receiptDetails.wingMasterId = receiptData.wingMasterId;
          this.getWingDetails(this.receiptDetails.wingMasterId);
          this.receiptDetails.wingDetailId = receiptData.wingDetailId;
          this.getcustomer(this.receiptDetails.wingMasterId,this.receiptDetails.wingDetailId);
          this.receiptDetails.customerId = receiptData.customerId;
          this.receiptDetails.receiptNo = receiptData.receiptNo;
          this.receiptDetails.receiptDate = receiptData.receiptDate;
          this.receiptDetails.cheqNeftRtgsNo = receiptData.cheqNeftRtgsNo;
          this.receiptDetails.bankName = receiptData.bankName;
          this.receiptDetails.branchName = receiptData.branchName;
          this.receiptDetails.receivedAs = receiptData.receivedAs;
          this.receiptDetails.amount = receiptData.amount;
          this.receiptDetails.amountInWord = receiptData.amountInWord;
          this.receiptDetails.PaymentDate = receiptData.paymentDate;
          this.receiptDetails.isCancel = receiptData.isCancel;
          this.receiptDetails.IsPrint = receiptData.isPrint;
          this.receiptDetails.description = receiptData.description;
          this.receiptDetails.siteId = receiptData.siteId;
          console.log('Receipt details fetched:', this.receiptDetails);
        },
        (error) => {
          console.error('Error fetching receipt details:', error);
        }
      );
    }
  }
  getWingMasterList(){
   this.wingMasterList=[];
    this.wingsService.getWingsList().subscribe(
      (response) => {
        this.wingMasterList = response;
        console.log('Wings list fetched:', this.wingMasterList);
      },
      (error) => {
        console.error('Error fetching wings:', error);
      }
    );
  }
  getWingDetails(wingMasterId:number):void{
     if(wingMasterId > 0){
      this.wingDetailList=[];
      const filterData = this.wingMasterList.filter( element =>
        element.wingMasterId===Number(wingMasterId)
       );
      filterData.forEach(wing=>{
        wing.wingDetails.forEach((wingdetails:any) => {
          this.wingDetailList.push(wingdetails);
        });
      });
     }
  }
  save():void{
    // Implement print functionality here
    console.log('Print button clicked. Implement print logic.');
    this.toastr.success('Print functionality is not implemented yet.', 'Info');
  }
  backReceiptList():void{
    this.router.navigate(['/receipts']);
  }
  getcustomer(wingMasterId:number,wingDetailId:number):void{
    this.customerList=[];
    if(wingMasterId > 0 && wingDetailId > 0){
      this.customerService.getCustomerByWing(wingMasterId,wingDetailId).subscribe(
        (response) => {
          this.customerList = response;
          this.receiptDetails.customerId=this.customerList?.[0].customerId || 0;
          console.log('Customer list fetched:', this.customerList);
        },
        (error) => {
          console.error('Error fetching customers:', error);
        }
      );
    }
  }
}
