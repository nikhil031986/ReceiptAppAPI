import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-toastr',
  imports: [],
  templateUrl: './toastr.component.html',
  styleUrl: './toastr.component.css'
})
export class ToastrComponent {

   constructor(private toastr: ToastrService) {}
  showSuccess() {
    this.toastr.success('Data saved successfully!', 'Success');
  }

  showError() {
    this.toastr.error('Something went wrong!', 'Error');
  }

  showInfo() {
    this.toastr.info('This is an info message.', 'Info');
  }

  showWarning() {
    this.toastr.warning('This is a warning message.', 'Warning');
  }
}
