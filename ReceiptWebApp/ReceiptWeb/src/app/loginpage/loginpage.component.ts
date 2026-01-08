import { Component,OnInit } from '@angular/core';
import { on } from 'events';
import { FormsModule } from '@angular/forms';
import { Router,ActivatedRoute } from '@angular/router';
import { LoginService } from '../service/login.service';
import { LocalStorageService } from '../service/local-storage.service';
import { error } from 'console';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-loginpage',
  imports: [FormsModule],
  templateUrl: './loginpage.component.html',
  styleUrl: './loginpage.component.css'
})
export class LoginpageComponent implements OnInit {
  username: string = '';
  password: string = '';
  errorMessage: string = '';
  constructor(private loginService: LoginService,
     private localStorageService: LocalStorageService,
     private router: Router,
    private authService: AuthService,
    private route: ActivatedRoute) { }
  ngOnInit(): void {
    // Initialization logic if needed
  }
  onChange(): void {
    if(this.username !== '' || this.password !== ''){
      this.errorMessage = '';
    }else{
      this.errorMessage = 'please enter username and password';
    }
  }
   onSubmit(): void {
    if (this.username === '' && this.password === '') {
        this.errorMessage = 'Invalid username or password';
      } else {
        this.errorMessage = '';
      } 
     this.loginService.userLogin(this.username, this.password).subscribe((response: any) => {
        if (response) {
          console.log('Login successful', response);
            this.authService.setToken(response.data.jwToken);  
            this.localStorageService.setToken(response.data.jwToken);
            this.authService.setUserId(response.data.id);
            this.authService.setUserName(response.data.userName);
            const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/home'; 
            this.router.navigate([returnUrl]);
          }
          else {
            //;
          }
      },
        (error) => {
          this.errorMessage = 'Login failed. Please check your credentials and try again.';
        },
      );
  }
}