import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { AuthenticationService } from '@app/_services';
import { pipe } from 'rxjs';

@Component({ templateUrl: 'login.component.html' })
export class LoginComponent implements OnInit {
    loginForm!: FormGroup;
    loading = false;
    submitted = false;
    error = '';

    constructor(
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private authenticationService: AuthenticationService
    ) {
        // redirect to home if already logged in
        if (this.authenticationService.userValue) {
            this.router.navigate(['/']);
        }
    }

    ngOnInit() {
        this.loginForm = this.formBuilder.group({
            username: ['', Validators.required],
            password: ['', Validators.required]
        });
    }

    // convenience getter for easy access to form fields
    get f() { return this.loginForm.controls; }

    onSubmit() {
        this.submitted = true;

        // stop here if form is invalid
        if (this.loginForm.invalid) {
            return;
        }

        this.error = '';
        this.loading = true;
        this.authenticationService.UserLogin(this.f.username.value, this.f.password.value)
            .subscribe({
                next: data => {
                    console.log(data);
                    if (data.Message == "Invalid credentials") {
                        this.error = "Invalid credentials";
                    }
                    if (data.Message == "Invalid email or password.") {
                        this.error = "Invalid email or password.";
                    }
                    if (data.Message.includes("Authenticated")) {
                        this.router.navigate(['/']);
                    }
                },
                error: error => {
                    this.error = error;
                    this.loading = false;
                }
        });
    }
}