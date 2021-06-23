import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserLoginViewModel } from 'src/app/models/userLoginViewModel';
import { AuthenticationService } from 'src/app/services/authenticationService';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.less']
})
export class LoginComponent implements OnInit {

  constructor(private formBuilder: FormBuilder, private authenticationService: AuthenticationService, private Router: Router) { }

  loginForm = this.formBuilder.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(6)]],
   });

  get form() { return this.loginForm.controls; }

  ngOnInit() {
    if(this.authenticationService.currentUser != null)
          this.Router.navigate(['/donations']);
  }

  loginUser(){
    if (this.loginForm.invalid)
          return;
    
    this.authenticationService.login(this.loginForm.value).subscribe((response: UserLoginViewModel) => {
          this.authenticationService.saveLoginCredentials(response);
          this.Router.navigate(['/donations']);
      });
  }
}
