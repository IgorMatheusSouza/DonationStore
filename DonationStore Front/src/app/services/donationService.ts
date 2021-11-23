import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthenticationUserModel } from '../models/authenticationUserModel';
import { DonationModel } from '../models/donationModel';
import { UserLoginViewModel } from '../models/userLoginViewModel';
import { BaseService } from './baseService';
import { catchError, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class DonationService extends BaseService {

  constructor(protected http: HttpClient) { super(http)}

  private urlAuthetication: string = this.Baseurl + 'donations/';

  private urls = {
    register: this.urlAuthetication,
    getAll: this.urlAuthetication,
  }

  register(data : AuthenticationUserModel){
    return this.http.post<DonationModel>(this.urls.register, data, this.header).pipe();
  }

  getDonations(){
    return this.http.get<DonationModel[]>(this.urls.getAll).pipe();
  }
}
