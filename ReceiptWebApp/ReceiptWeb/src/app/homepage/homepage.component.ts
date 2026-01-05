import { Component,OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LocalStorageService } from '../service/local-storage.service';

@Component({
  selector: 'app-homepage',
  imports: [],
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.css'
})
export class HomepageComponent implements OnInit {
   IsUserLogin = false;
  constructor (private localStorageService: LocalStorageService,
   private router: Router) { }
  ngOnInit(): void {
    this.localStorageService.isLoggedIn$.subscribe(status => {
      this.IsUserLogin = status;
    });
    if (!this.IsUserLogin) {
      this.router.navigate(['/login']);
    }
  }
  
}
