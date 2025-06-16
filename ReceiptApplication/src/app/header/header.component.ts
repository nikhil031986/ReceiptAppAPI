import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  imports: [],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent implements OnInit {
  contactDetails:any;
  constructor() { 
    this.contactDetails = {
      phone: '+91 9925031760',
      Name:'Nikhil Sharma',
      email: 's.nikhil4@gmail.com'
    }
  }

  ngOnInit(): void {
    // Initialization logic can go here
  }

}
