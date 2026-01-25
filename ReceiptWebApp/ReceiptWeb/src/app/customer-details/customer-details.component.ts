import { Component, OnInit } from '@angular/core';
import { LocalStorageService } from '../service/local-storage.service';
import { WingsService } from '../service/wings.service';
import { Router } from '@angular/router';
import { CustomerService } from '../service/customer.service';
import { ActivatedRoute } from '@angular/router';
import { NgFor,NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { GridViewComponent } from '../grid-view/grid-view.component';
@Component({
  selector: 'app-customer-details',
  imports: [NgFor, NgIf, FormsModule, GridViewComponent],
  templateUrl:'./customer-details.component.html',
  styleUrl: './customer-details.component.css'
})
export class CustomerDetailsComponent implements OnInit {

  customerDetails:any[]=[];
  wing:any[]=[];
  girdColumns=[
    { field: 'customerDetailsId', header: 'ID',hideColumn:true },
    { field: 'customerName', header: 'Customer Name'},
    { field: 'address', header: 'Address' },
    { field: 'contDetails', header: 'Contact Details' },
    { field: 'panNumber', header: 'PAN Number' },
    { field: 'aadharNumber', header: 'Aadhar Number' },
    { field: 'religin', header: 'Religion' },
    { field: 'ocupation', header: 'Occupation' },
    { field: 'contactNumber', header: 'Contact Number' },
    { field: 'emaiId', header: 'Email ID' },
    { field: 'isMain', header: 'Is Main', isBoolean:true },
  ];
  wingDetails:any[]=[];
  currentSiteId:number=0;
  showIdColumn:boolean=false;
  selectedWingDetailsId:number=0;
  customerDetailsForm={
    customerDetailsId:0,
    customerId:0,
    customerName:'',
    address:'',
    contDetails:'',
    panNumber:'',
    aadharNumber:'000-000-000',
    religin:'',
    ocupation:'',
    contactNumber:'',
    emaiId:'',
    isMain:false,
  }
  customerForm={
    customerMasterId:0,
    wingMasterId:0,
    wingDetailId:0,
    isBanakhat:false,
    banakhatNumber:'',
    banakhatDate:'',
    finacialName:'',
    dastavgNo:'',
    dastavgDate:'',
    siteId:0,
    customerDetails:[{
      customerDetailsId:0,
      customerId:0,
      customerName:'',
      address:'',
      contDetails:'',
      panNumber:'',
      aadharNumber:'000-000-000',
      religin:'',
      ocupation:'',
      contactNumber:'',
      emaiId:'',
      isMain:false,
    }]
  }
  constructor(private localStorageService: LocalStorageService,
      private router: Router,
      private toastrService:ToastrService,
      private customerservice: CustomerService,
      private route: ActivatedRoute,
      private wingservice:WingsService){}
      private customerId:number =0;

 async ngOnInit() {
    this.customerId = Number(this.route.snapshot.paramMap.get('id'));
    await this.getAllWings();
    if(this.customerId>0){
      this.getCustomerDetails(this.customerId);
    }
  }
  
  Save():void{
    var siteId = this.localStorageService.getCurrentSiteId();
    this.customerForm.siteId=siteId;
    if(this.customerForm.customerMasterId>0){
        this.customerservice.UpdateCustomerCustomer(this.customerForm).subscribe(
          (response) => {
            this.toastrService.success('Customer details updated successfully!', 'Success');
            this.router.navigate(['/customerlist']);
          },
          (error) => {
            this.toastrService.error('Something went wrong!', 'Error');
          }
        );
    }
    else{
      this.customerForm.customerDetails=[];
      this.customerservice.AddCustomer(this.customerForm).subscribe(
          (response) => {
            this.toastrService.success('Customer details save successfully!', 'Success');
            this.router.navigate(['/customerlist']);
          },
          (error) => {
            this.toastrService.error('Something went wrong!', 'Error');
          }
        );
    }
    
  }

  onEditRecord(row: any) {
    this.openModal('editCustomerDetails',row.customerDetailsId);
  }

  onDeleteRecord(row: any) {
    this.DeleteCustomerDetails(row.customerDetailsId);
  }

  async getAllWings(){  
    this.wing=[];
    this.wingservice.getWingsList().subscribe(
      (response) => {
        this.wing = response;
        console.log('Wings list fetched:', this.wing);
      },
      (error) => {
        console.error('Error fetching wings:', error);
      }
    );
  }

 getWingDetails(wingMasterId:number):void{
     if(wingMasterId > 0){
      this.wingDetails=[];
      const filterData = this.wing.filter( element =>
        element.wingMasterId===Number(wingMasterId)
       );
      filterData.forEach(wing=>{
        wing.wingDetails.forEach((wingdetails:any) => {
          this.wingDetails.push(wingdetails);
        });
      });
     }
  }

  AddNewCustomer(formId:string):void{
    
    const modal = document.getElementById(formId);
    if (modal) {
      this.clearCustomerDetails();
      this.customerDetailsForm.customerId = this.customerForm.customerMasterId;
      modal.style.display = 'block';
      document.body.classList.add('modal-open');
    }
  }

   getCustomerDetails(customerId:number):void{
    this.customerservice.getCustomer(customerId).subscribe(
      (response) => {
        var customer=response;
        this.customerForm.customerMasterId=customer.customerMasterId;
        this.customerForm.wingMasterId=customer.wingMasterId;
        this.getWingDetails(this.customerForm.wingMasterId);
        this.customerForm.wingDetailId = customer.wingDetailId;
        this.customerForm.isBanakhat=customer.isBanakhat;
        this.customerForm.banakhatNumber=customer.banakhatNumber;
        this.customerForm.banakhatDate = customer.banakhatDate;
        this.customerForm.dastavgNo = customer.dastavgNo;
        this.customerForm.dastavgDate = customer.dastavgDate;
        this.customerForm.finacialName=customer.finacialName;
        this.customerForm.customerDetails=[];
        customer.customerDetails.forEach((element:any) => {
          this.clearCustomerDetails();
          this.customerDetailsForm.customerDetailsId = element.customerDetailsId;
          this.customerDetailsForm.customerId = element.customerId;
          this.customerDetailsForm.customerName = element.customerName;
          this.customerDetailsForm.address = element.address;
          this.customerDetailsForm.contDetails = element.contDetails;
          this.customerDetailsForm.panNumber = element.panNumber;
          this.customerDetailsForm.aadharNumber = element.aadharNumber;
          this.customerDetailsForm.religin = element.religin;
          this.customerDetailsForm.ocupation = element.ocupation;
          this.customerDetailsForm.contactNumber = element.contactNumber;
          this.customerDetailsForm.emaiId = element.emaiId;
          this.customerDetailsForm.isMain = element.isMain;
          this.customerForm.customerDetails.push(this.customerDetailsForm);
        });
      },
      (error) => {
        console.error('Error fetching wings:', error);
      });
  }
  clearCustomerDetails():void{
    this.customerDetailsForm={
      customerDetailsId:0,
      customerId:0,
      customerName:'',
      address:'',
      contDetails:'',
      panNumber:'',
      aadharNumber:'000-000-000',
      religin:'',
      ocupation:'',
      contactNumber:'',
      emaiId:'',
      isMain:false,
    }
  }
  wingChange(event: any): void {
    this.getWingDetails(this.customerForm.wingMasterId);
  }

  wingDetailChange(event:any):void{

  }

  openModal(id: string,customerDetailId:number): void {
     const modal = document.getElementById(id);
     this.clearCustomerDetails();
    if(customerDetailId > 0){
      this.customerservice.getCustomerDetail(customerDetailId).subscribe(
        (data) => {
          this.customerDetailsForm.customerDetailsId = data.customerDetailsId;
          this.customerDetailsForm.customerId = data.customerId;
          this.customerDetailsForm.customerName = data.customerName;
          this.customerDetailsForm.address = data.address;
          this.customerDetailsForm.contDetails = data.contDetails;
          this.customerDetailsForm.panNumber = data.panNumber;
          this.customerDetailsForm.aadharNumber = data.aadharNumber;
          this.customerDetailsForm.religin = data.religin;
          this.customerDetailsForm.ocupation = data.ocupation;
          this.customerDetailsForm.contactNumber = data.contactNumber;
          this.customerDetailsForm.emaiId = data.emaiId;
          this.customerDetailsForm.isMain = data.isMain;
          if (modal) {
            modal.style.display = 'block';
            document.body.classList.add('modal-open');
          }
        },
        (error) => {
          console.error('Error fetching wing detail:', error);
        }
      );
    }
  }

  DeleteCustomerDetails(customerDetailId:number): void {
     this.customerservice.deleteCustomerDetail(customerDetailId).subscribe(
      (response) => {
        this.toastrService.success('Customer detail deleted successfully.', 'Success');
        this.getCustomerDetails(this.customerId); // Refresh the customer details after deletion
      },
      (error) => {
        this.toastrService.success('Error deleting Customer detail.', 'Error');
      }
    ); 
  }

  closeCustomerDetailModal(dialogModuleId:string):void{
    const modal = document.getElementById(dialogModuleId);
    if (modal) {
      modal.style.display = 'none';
      document.body.classList.remove('modal-open');
    }
  }

  SaveCustomerDetails(dialogModuleId:string):void{
     // Implement save customer details functionality here
    console.log('Saving customer details:', this.customerDetailsForm);

    this.customerservice.submitcustomerDetails(this.customerDetailsForm).subscribe(
      (response) => {
        this.toastrService.success('Customer detail saved successfully.', 'Success');
        this.closeCustomerDetailModal(dialogModuleId);
        this.getCustomerDetails(this.customerId); // Refresh the customer after saving
      },
      (error) => {
         this.toastrService.success('Error saving Customer detail.', 'Error');
      }
    );    
  }
}
