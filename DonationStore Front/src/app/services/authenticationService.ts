import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthenticationUserModel } from '../models/authenticationUserModel';
import { BaseService } from './baseService';

@Injectable({
  providedIn: 'root'
})

export class AuthenticationService extends BaseService {

  constructor(public http: HttpClient) { super(http)}

  private urlAuthetication: String = this.Baseurl + 'authentication/';

  private urls = {
    register: this.urlAuthetication + 'users'
  }

  register(data : AuthenticationUserModel){
    return this.http.post<any>(this.urls.register, data).subscribe();
  }
}
