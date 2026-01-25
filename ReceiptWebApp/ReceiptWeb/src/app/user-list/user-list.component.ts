import { Component, OnInit } from '@angular/core';
import { LocalStorageService } from '../service/local-storage.service';
import { NgFor,NgIf,NgClass,SlicePipe } from '@angular/common';
import {NgxNavigateBackService} from 'ngx-navigate-back';
import { Router,ActivatedRoute } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { LargeNumberLike } from 'crypto';
import { UserServiceService } from '../service/user-service.service';
import { first } from 'rxjs';

@Component({
  selector: 'app-user-list',
  imports: [NgFor, NgIf,FormsModule,NgClass,SlicePipe],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css'
})
export class UserListComponent implements OnInit {

  IsUserLogin = false;
  currentSiteId: number = 0;
  Users: any[] = [];
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
    private userServiceService: UserServiceService,
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
        }
      });
    this.getAllUserArray();
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
  openuserDetails():void{
      const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/user-details/'+0; 
      this.router.navigate([returnUrl]);
  }

  get filterData(){
    if(!this.searchText.trim()){
      return this.Users;
    }
    const lowerSearch = this.searchText.toLocaleLowerCase();
    return this.Users.filter((item:any)=>
      Object.values(item).some(val=> String(val).toLocaleLowerCase().includes(lowerSearch)
      )
    );
  }

  range(start: number, end: number): number[] {
    return [...Array(end).keys()].map((el) => el + start);
  }

  getAllUserArray():void{
    this.Users=[];
    this.userServiceService.getUserList().subscribe(
        (response) => {
          let userList = response as any[];
          
          userList.forEach(user => {
            let sitesName ='';
            user.usersSite.forEach((element: any) => {
              sitesName += element.site.display_Name + ', ';
            });
            sitesName = sitesName.replace(/, $/, ''); // Remove trailing comma and space
            let userData = {
                  userId: user.userId,
                  userName: user.userName,
                  firstName: user.first_Name,
                  lastName: user.last_Name,
                  email: user.emailId,
                  role: user.isAdmin ? 'Admin' : 'User',
                  userSites: sitesName,
              };              
              this.Users.push(userData);
          });
          this.total=this.Users.length;
          this.limit=5;
          this.endrecordNumber= this.limit;
          const pagesCount = Math.ceil(this.total / this.limit);
          this.pages = this.range(1, pagesCount);
          console.log('Users list fetched:', this.Users);
        },
        (error) => {
          console.error('Error fetching users:', error);
        }
      );
  }

    openEdituser(userId:Number):void{
      const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/user-details/'+userId; 
      this.router.navigate([returnUrl]);
    } 
}
