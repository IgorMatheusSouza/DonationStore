import { HttpClient, HttpHeaders } from '@angular/common/http';
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
    login: this.urlAuthetication + 'users/login',
    logout: this.urlAuthetication + 'users/logout'
  }

  register(data : AuthenticationUserModel): Observable<UserLoginViewModel>{
    return this.http.post<UserLoginViewModel>(this.urls.register, data).pipe();
  }

  login(data : AuthenticationUserModel): Observable<UserLoginViewModel>{

    return this.http.post<UserLoginViewModel>(this.urls.login, data).pipe();
  }

  saveLoginCredentials(loginData: UserLoginViewModel){
    sessionStorage.setItem("forceReaload", "true");
    localStorage.setItem("User",JSON.stringify(loginData));
  }

  logout(){
    localStorage.removeItem("User");
    sessionStorage.setItem("forceReaload", "true");
    return this.http.post(this.urls.logout, null, this.header).pipe();;
  }
}
