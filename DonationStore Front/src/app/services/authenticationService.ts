import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthenticationUserModel } from '../models/authenticationUserModel';
import { UserLoginViewModel } from '../models/userLoginViewModel';
import { BaseService } from './baseService';

@Injectable({
  providedIn: 'root'
})

export class AuthenticationService extends BaseService {

  constructor(public http: HttpClient) { super(http)}

  private urlAuthetication: String = this.Baseurl + 'authentication/';

  private urls = {
    register: this.urlAuthetication + 'users',
    login: this.urlAuthetication + 'users/login'
  }

  register(data : AuthenticationUserModel): Observable<UserLoginViewModel>{
    return this.http.post<UserLoginViewModel>(this.urls.register, data).pipe();
  }
  
  login(data : AuthenticationUserModel): Observable<UserLoginViewModel>{
    return this.http.post<UserLoginViewModel>(this.urls.login, data).pipe();
  }

  saveLoginCredentials(loginData: UserLoginViewModel){
      localStorage.setItem("User",JSON.stringify(loginData));
  }
}
