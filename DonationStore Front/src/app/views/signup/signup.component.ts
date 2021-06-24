import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators  } from '@angular/forms';
import { Router } from '@angular/router';
import { MustMatch } from 'src/app/helpers/validationHelper';
import { UserLoginViewModel } from 'src/app/models/userLoginViewModel';
import { AuthenticationService } from './../../services/authenticationService';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.less']
})
export class SignupComponent implements OnInit {
  
  registerForm = this.formBuilder.group({
    email: ['', [Validators.required, Validators.email, Validators.maxLength(20)]],
    name: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(20)]],
    password: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(25)]],
    passwordConfirmation: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(25)]],
   }, { validator: MustMatch('password', 'passwordConfirmation') });

   get form() { return this.registerForm.controls; }

  constructor(private formBuilder: FormBuilder, private authenticationService: AuthenticationService, private Router: Router) { }
  
  ngOnInit() {
    if(this.authenticationService.currentUser != null)
          this.Router.navigate(['/donations']);
  }
  
  registerUser(){
    if (this.registerForm.invalid)
          return;
          
    this.authenticationService.register(this.registerForm.value).subscribe((response: UserLoginViewModel) => {
          this.authenticationService.saveLoginCredentials(response);
          this.Router.navigate(['/donations']);
      });
  }
}
