import { Component,OnInit } from '@angular/core';
import { Router,ActivatedRoute } from '@angular/router';
import { WingsService } from '../service/wings.service';
import { LocalStorageService } from '../service/local-storage.service';
import { FormsModule} from '@angular/forms';
import { NgFor,NgIf } from '@angular/common';
import { response } from 'express';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-wingdetail',
  imports: [FormsModule, NgFor, NgIf],
  templateUrl:'./wingdetail.component.html',
  styleUrl: './wingdetail.component.css'
})
export class WingdetailComponent implements OnInit {

  private wingId: number = 0;
  private isUserLogin = false;
  showIdColumn = false;
  private wingDetails: any;
  wingdetailsForm={
    wingDetailId: 0,
    wingMasterId: 0,
    flatNo:'',
    wingName:'',
    land:0.0,
    carpate:0.0,
    wb:0.0,
    total:0.0,
    amount:0.0,
    east:'',
    west:'',
    north:'',
    south:'',
    flowrName:'',
    openTarrace:''
  };
  formData={
    wingMasterId: 0,
    displayName: '',
    floarCount: 0,
    houseCount: 0,
    startNumber:0,
    endNumber:0,
    siteId:0,
    wingDetails:[ {
      wingDetailId: 0,
      wingMasterId: 0,
      flatNo:'',
      wingName:'',
      land:0.0,
      carpate:0.0,
      wb:0.0,
      total:0.0,
      amount:0.0,
      east:'',
      west:'',
      north:'',
      south:'',
      flowrName:'',
      openTarrace:''
    }]
  };

  constructor(private router: Router,
    private route: ActivatedRoute, 
    private wingsService: WingsService,
    private localStorageService: LocalStorageService,
    private toastrService : ToastrService
  ) { }

  ngOnInit(): void {    
    this.showIdColumn = false;
    this.wingId = Number(this.route.snapshot.paramMap.get('id'));
    this.resateFormData();
    this.getWingDetails();
  }

  closeWingDetailModal(id: string): void {
    const modal = document.getElementById(id);
    if (modal) {
      modal.style.display = 'none';
      document.body.classList.remove('modal-open');
    }
  }

  AddNewWingDetails(modelId:string): void {
    this.resateWingDetailsForm();
    const modal = document.getElementById(modelId);
    if (modal) {
      this.resateWingDetailsForm();
      this.wingdetailsForm.wingMasterId = this.wingDetails.wingMasterId;
      this.wingdetailsForm.wingName=this.wingDetails.displayName;
      modal.style.display = 'block';
      document.body.classList.add('modal-open');
    }
  }

  openModal(id: string,wingDetailId:number): void {
    const modal = document.getElementById(id);
    if(wingDetailId > 0){
      this.wingsService.getWingDetailsById(wingDetailId).subscribe(
        (data) => {
          this.resateWingDetailsForm();
          this.wingdetailsForm.wingDetailId = data.wingDetailId;
          this.wingdetailsForm.wingMasterId = data.wingMasterId;
          this.wingdetailsForm.flatNo = data.flatNo;
          this.wingdetailsForm.wingName = data.wingName;
          this.wingdetailsForm.land = data.land;
          this.wingdetailsForm.carpate = data.carpate;
          this.wingdetailsForm.wb = data.wb;
          this.wingdetailsForm.total = data.total;
          this.wingdetailsForm.amount = data.amount;
          this.wingdetailsForm.east = data.east;
          this.wingdetailsForm.west = data.west;
          this.wingdetailsForm.north = data.north;
          this.wingdetailsForm.south = data.south;
          this.wingdetailsForm.flowrName = data.flowrName;
          this.wingdetailsForm.openTarrace = data.openTarrace;
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

  getWingDetails(): void {
    if(this.wingId>0){
      this.wingsService.getwingById(this.wingId).subscribe(
      (data) => {
        this.wingDetails = data;
        console.log('Wing details fetched:', this.wingDetails); 
        this.formData.wingMasterId = this.wingDetails.wingMasterId; 
        this.formData.displayName = this.wingDetails.displayName; 
        this.formData.floarCount = this.wingDetails.floarCount; 
        this.formData.houseCount = this.wingDetails.houseCount; 
        this.formData.startNumber = this.wingDetails.startNumber; 
        this.formData.endNumber = this.wingDetails.endNumber; 
        this.formData.siteId = this.wingDetails.siteId; 
        this.wingDetails.wingDetails.forEach((detail: any) => {
          this.formData.wingDetails.push({
            wingDetailId: detail.wingDetailId,
            wingMasterId: detail.wingMasterId,
            flatNo: detail.flatNo,
            wingName: detail.wingName,
            land: detail.land,
            carpate: detail.carpate,
            wb: detail.wb,
            total: detail.total,
            amount: detail.amount,
            east: detail.east,
            west: detail.west,
            north: detail.north,
            south: detail.south,
            flowrName: detail.flowrName,
            openTarrace: detail.openTarrace
          });
        });
        this.formData.wingDetails = this.wingDetails.wingDetails;
      },
      (error) => {
        console.error('Error fetching wing details:', error);
      }
    );
    }
    
  }

  Save(): void {
    if(this.formData.wingMasterId > 0){
       this.wingsService.updateWing(this.formData).subscribe(
          (response) => {
            console.log('Wing updated successfully:', response);
            this.toastrService.success('wing updated successfully!', 'Success');
            this.router.navigate(['/home']);
          },
          (error) => {
            this.toastrService.error('Something went wrong!', 'Error');
          }
        );
    }
    else{
      const newwing ={
        wingMasterId: this.formData.wingMasterId,
        displayName: this.formData.displayName,
        floarCount: this.formData.floarCount,
        houseCount: this.formData.houseCount,
        startNumber:this.formData.startNumber,
        endNumber:this.formData.endNumber,
        siteId:0
      };

      this.wingsService.addNewWing(newwing).subscribe(
        (response)=>{
          this.toastrService.success('wing added successfully!', 'Success');
          this.router.navigate(['/home']);
        },
        (error) => {
            this.toastrService.error('Something went wrong!', 'Error');
          }
      );
    }
   
  }

  SaveWingDetails(id:string): void {
    // Implement save wing details functionality here
    console.log('Saving wing details:', this.wingdetailsForm);

    this.wingsService.submitWingDetails(this.wingdetailsForm).subscribe(
      (response) => {
        this.toastrService.success('wing detail save successfully!', 'Success');
        this.closeWingDetailModal(id);
        this.getWingDetails(); // Refresh the wing details after saving
      },
      (error) => {
        this.toastrService.error('Something went wrong!', 'Error');
      }
    );    
  }

  DeleteWingDetails(wingDetailId:number): void {
    this.wingsService.deleteWingDetail(wingDetailId).subscribe(
      (response) => {
        this.toastrService.success('wing detail deleted successfully!', 'Success');
        this.getWingDetails(); // Refresh the wing details after deletion
      },
      (error) => {
        this.toastrService.error('Something went wrong!', 'Error');
      }
    );  
  }

  resateWingDetailsForm(): void {
    this.wingdetailsForm={
      wingDetailId: 0,
      wingMasterId: 0,
      flatNo:'',
      wingName:'',
      land:0.0,
      carpate:0.0,
      wb:0.0,
      total:0.0,
      amount:0.0,
      east:'',
      west:'',
      north:'', 
      south:'',
      flowrName:'',
      openTarrace:''
    };
  }

  resateFormData(): void {
    this.formData={
        wingMasterId: 0,
        displayName: '',
        floarCount: 0,
        houseCount: 0,
        startNumber:0,
        endNumber:0,
        siteId:0,
        wingDetails:[ {
          wingDetailId: 0,
          wingMasterId: 0,
          flatNo:'',
          wingName:'',
          land:0.0,
          carpate:0.0,
          wb:0.0,
          total:0.0,
          amount:0.0,
          east:'',
          west:'',
          north:'',
          south:'',
          flowrName:'',
          openTarrace:''
        }]
      }
  }

}