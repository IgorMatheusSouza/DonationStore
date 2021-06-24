import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthenticationUserModel } from '../models/authenticationUserModel';
import { DonationModel } from '../models/DonationModel';
import { UserLoginViewModel } from '../models/userLoginViewModel';
import { BaseService } from './baseService';

@Injectable({
  providedIn: 'root'
})

export class DonationService extends BaseService {

  constructor(public http: HttpClient) { super(http)}

  private urlAuthetication: string = this.Baseurl + 'donation/';

  private urls = {
    register: this.urlAuthetication,
    getAll: this.urlAuthetication,
  }

  register(data : AuthenticationUserModel){
    return this.http.post<DonationModel>(this.urls.register, data).pipe();
  }
}