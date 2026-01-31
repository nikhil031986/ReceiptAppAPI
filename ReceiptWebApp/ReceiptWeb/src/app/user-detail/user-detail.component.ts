import { Component,OnInit } from '@angular/core';
import { Router,ActivatedRoute } from '@angular/router';
import { UserServiceService } from '../service/user-service.service';
import { LocalStorageService } from '../service/local-storage.service';
import { FormsModule} from '@angular/forms';
import { NgFor,NgIf } from '@angular/common';
import { ToastrService } from 'ngx-toastr';
import { GridViewComponent } from '../grid-view/grid-view.component';
import { SitesService } from '../service/sites.service';
import e from 'express';

@Component({
  selector: 'app-user-detail',
  imports: [FormsModule, NgFor, NgIf,GridViewComponent],
  templateUrl: './user-detail.component.html',
  styleUrl: './user-detail.component.css'
})
export class UserDetailComponent implements OnInit {
  private isUserLogin = false;
  private userId: number = 0;
  private userDetails: any;
  sitelst:any[] = [];
   girdColumns=[
    { field: 'userSiteId', header: 'ID',hideColumn:true },
    { field: 'userId', header: 'User Id' ,hideColumn:true },
    { field: 'siteId', header: 'siteId',hideColumn:true },
    { field: 'siteName', header: 'Site Name' },
    { field: 'isDefault', header: 'Is Default' , isBoolean:true},
  ];
  userSite={
    userSiteId:0,
    userId:0,
    siteId:0,
    siteName:'',
    isDefault:false
  }
  userdetailsForm={
    userId: 0,
    userName: '',
    first_Name: '',
    last_Name: '',
    emailId: '',
    password: '',
    contactNo: '',
    isAdmin: false,
    address: '',
    userSites: [] as any[]
  };
  constructor(private userServiceService: UserServiceService,
    private localStorageService: LocalStorageService,
    private router: Router,
    private route: ActivatedRoute,
    private toastr: ToastrService,
    private sitesService: SitesService) { }

  ngOnInit(): void {
    this.userId = Number(this.route.snapshot.paramMap.get('id'));
    this.localStorageService.isLoggedIn$.subscribe(status => {
      this.isUserLogin = status;
    });
    if(this.userId>0){
      this.getUserDetails();
    }
    else{
      this.clearForm();
    }
    this.getSiteList();
  }

  getSiteList():void{
    this.sitesService.getAllSitesList().subscribe(
      (response) => {
        this.sitelst = response;
      },
      (error) => {
        console.error('Error fetching site list:', error);
      }
    );
  }
  clearForm():void{
    this.userdetailsForm={
      userId: 0,
      userName: '',
      first_Name: '',
      last_Name: '',
      emailId: '',
      password: '',
      contactNo: '',
      isAdmin: false,
      address: '',
      userSites: []
    };
  }
  getUserDetails():void{
    this.userServiceService.getUserById(this.userId).subscribe(
      (response) => {
        this.clearForm();
        this.userdetailsForm.userId = response.userId;
        this.userdetailsForm.userName = response.userName;
        this.userdetailsForm.first_Name = response.first_Name;
        this.userdetailsForm.last_Name = response.last_Name;
        this.userdetailsForm.emailId = response.emailId;
        this.userdetailsForm.password = '';
        this.userdetailsForm.contactNo = response.contactNo;
        this.userdetailsForm.isAdmin = response.isAdmin;
        response.usersSite.forEach((element: any) => {
          this.userdetailsForm.userSites.push({
            userSiteId: element.userSiteId,
            userId: element.userId,
            siteId: element.siteId,
            isDefault: element.isDefault,
            siteName: element.site.display_Name 
          });
        });
        
      },
      (error) => {
        console.error('Error fetching user details:', error);
      }
    );
  }

  Save(): void {
    if(this.userId===0){
      this.userdetailsForm.userSites = [];
      let currentSite = this.localStorageService.getCurrentSiteId();
      this.userdetailsForm.userSites.push({
        userSiteId: 0,
        userId: 0,
        siteId: currentSite,
        isDefault: true,
        siteName: this.sitelst.find(site=>site.siteId===currentSite)?.display_Name || ''
      });
      this.userServiceService.AddUser(this.userdetailsForm).subscribe(
      (response) => {
        this.toastr.success('User saved successfully.', 'Success');
        this.router.navigate(['/userlist']);
      },
      (error) => {
        this.toastr.error('Error saving user details.', 'Error');
      }
    );
    }
    else{
      this.userServiceService.UpdateUser(this.userId,this.userdetailsForm).subscribe(
      (response) => {
        this.toastr.success('User updated successfully.', 'Success');
        this.router.navigate(['/userlist']);
      },
      (error) => {
        this.toastr.error('Error updating user details.', 'Error');
      }
    );
  }
  }
  AddNewSite(modalId: string): void {
      const modal = document.getElementById(modalId);
    if (modal) {
      this.clearUserSiteForm();
      this.userSite.userId = this.userdetailsForm.userId;
      modal.style.display = 'block';
      document.body.classList.add('modal-open');
    }
  }
  onEditRecord(row: any) {
    this.openModal('editUserSite',row.userSiteId);
  }

  onDeleteRecord(row: any) {
    this.DeleteCustomerDetails(row.userSiteId);
  }
  openModal(id: string, userSiteId:number): void {
    const modal = document.getElementById(id);
    this.clearUserSiteForm();
    this.userSite= this.userdetailsForm.userSites.find(userSite=>userSite.userSiteId===userSiteId);
     if (modal) {
      modal.style.display = 'block';
      document.body.classList.add('modal-open');
    }
  }
  clearUserSiteForm(): void {
    this.userSite={
      userSiteId:0,  
      userId:0,
      siteId:0, 
      siteName:'',
      isDefault:false
    }
  }
  DeleteCustomerDetails(userSiteId:number): void {
   const modal = document.getElementById('userSiteDeleteConforation');
    if (modal) {
      modal.setAttribute('data-usersiteid', userSiteId.toString());
      modal.style.display = 'block';
      document.body.classList.add('modal-open');
    }
  }
  deleteUserSiteModal(dialogModuleId:string): void {
     const modal = document.getElementById(dialogModuleId);
      if (modal) {
      var modaluserSiteId=Number(modal.getAttribute('data-usersiteid'));
      this.userServiceService.deleteUserSite(modaluserSiteId).subscribe(
        (response) => {
          this.toastr.success('User site deleted successfully.', 'Success');
          this.getUserDetails(); // Refresh the user details after deletion
        },
        (error) => {
          this.toastr.success('Error deleting User site detail.', 'Error');
        }
      );  
   
      modal.style.display = 'none';
      document.body.classList.remove('modal-open');
    }
  }
  closeUserSiteModal(dialogModuleId:string): void {
     const modal = document.getElementById(dialogModuleId);
    if (modal) {
      modal.style.display = 'none';
      document.body.classList.remove('modal-open');
    }
  }
  SaveUserSite(dialogModuleId:string): void {
    if(this.userSite.userSiteId>0){
      this.userServiceService.updateUserSite(this.userdetailsForm.userId,this.userSite).subscribe(
        (response) => {
          this.toastr.success('User site updated successfully.', 'Success');
          this.closeUserSiteModal(dialogModuleId);
          this.getUserDetails(); // Refresh the user details after saving
        },
        (error) => {
           this.toastr.success('Error updating User site detail.', 'Error');
        }
      );
    }
    else{
     this.userServiceService.submitUserSite(this.userdetailsForm.userId,this.userSite).subscribe(
      (response) => {
        this.toastr.success('User site saved successfully.', 'Success');
        this.closeUserSiteModal(dialogModuleId);
        this.getUserDetails(); // Refresh the user details after saving
      },
      (error) => {
         this.toastr.success('Error saving User site detail.', 'Error');
      }
    );  
  }  
  }
}
