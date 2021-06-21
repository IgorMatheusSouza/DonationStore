import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators  } from '@angular/forms';
import { MustMatch } from 'src/app/helpers/validationHelper';
import {AuthenticationService } from './../../services/authenticationService';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.less']
})
export class SignupComponent implements OnInit {
  
  registerForm = this.formBuilder.group({
    email: ['', [Validators.required, Validators.email]],
    name: ['', [Validators.required, Validators.minLength(5)]],
    password: ['', [Validators.required, Validators.minLength(6)]],
    passwordConfirmation: ['', [Validators.required, Validators.minLength(6)]],
   }, { validator: MustMatch('password', 'passwordConfirmation') });

   get form() { return this.registerForm.controls; }

  constructor(private formBuilder: FormBuilder, private authenticationService: AuthenticationService) { }
  
  ngOnInit() {
  }
  
  registerUser(){
    if (this.registerForm.invalid) {
        return;
    }
    var result = this.authenticationService.register(this.registerForm.value);    
    
  }
}
