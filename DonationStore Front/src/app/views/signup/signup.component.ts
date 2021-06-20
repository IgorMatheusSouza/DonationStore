import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators  } from '@angular/forms';
import {AuthenticationService } from './../../services/authenticationService';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.less']
})
export class SignupComponent implements OnInit {
  
  registerForm = this.formBuilder.group({
    email: ['', [Validators.required, Validators.email]],
    name: ['', [Validators.required, Validators.minLength(6)]],
    password: ['', Validators.required, Validators.minLength(6)],
    passwordConfirmation: ['', Validators.required, Validators.minLength(6)],
   });

  constructor(private formBuilder: FormBuilder, private authenticationService: AuthenticationService) { }
  
  ngOnInit() {
  }
  
  registerUser(){
    var result = this.authenticationService.register(this.registerForm.value);    
    console.log(this.registerForm.value);
  }
}
