import { Component,OnInit } from '@angular/core';
import { Router,ActivatedRoute } from '@angular/router';
import { UserServiceService } from '../service/user-service.service';
import { LocalStorageService } from '../service/local-storage.service';
import { FormsModule} from '@angular/forms';
import { NgFor,NgIf } from '@angular/common';
import { response } from 'express';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-user-detail',
  imports: [FormsModule, NgFor, NgIf],
  templateUrl: './user-detail.component.html',
  styleUrl: './user-detail.component.css'
})
export class UserDetailComponent implements OnInit {
  private isUserLogin = false;
  private userId: number = 0;
  private userDetails: any;
  userSite={
    userSitId:0,
    userId:0,
    siteId:0,
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
    userSites: [] as any[]
  };
  constructor(private userServiceService: UserServiceService,
    private localStorageService: LocalStorageService,
    private router: Router,
    private route: ActivatedRoute,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.userId = Number(this.route.snapshot.paramMap.get('id'));
  }

  getUserDetails():void{
    this.userServiceService.getUserList().subscribe(
      (response) => {
        let userList = response as any[];
        userList.forEach(user => {
          if(user.userId == this.userId){
            this.userdetailsForm={
              userId: user.userId,
              userName: user.userName,
              first_Name: user.first_Name,
              last_Name: user.last_Name,
              emailId: user.emailId,
              password: '',
              contactNo: user.contactNo,
              isAdmin: user.isAdmin,
              userSites: user.usersSites
            };
          }
        });
      },
      (error) => {
        console.error('Error fetching user details:', error);
      }
    );
  }
}