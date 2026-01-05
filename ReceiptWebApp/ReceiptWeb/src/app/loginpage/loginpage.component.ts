import { Component,OnInit } from '@angular/core';
import { on } from 'events';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from '../service/login.service';
import { LocalStorageService } from '../service/local-storage.service';
import { error } from 'console';

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
     private router: Router) { }
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
            this.localStorageService.setToken(response.data.jwToken);
            this.localStorageService.setUserId(response.data.id);
            this.localStorageService.setUserName(response.data.userName);
            this.router.navigate(['/home']);
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