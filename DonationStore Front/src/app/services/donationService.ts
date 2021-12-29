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
    get: this.urlAuthetication,
    acquireDonation: this.urlAuthetication + 'acquire/',
    userdonations: this.urlAuthetication + 'user/',
    changeDonationAcquisitionStatus: this.urlAuthetication + 'acquire/status',
    changeDonationStatus: this.urlAuthetication + 'status/'
  }

  register(data : AuthenticationUserModel) {
    return this.http.post<DonationModel>(this.urls.register, data, this.header).pipe();
  }

  getDonations() {
    return this.http.get<DonationModel[]>(this.urls.getAll).pipe();
  }

  getDonation(id : string) {
    return this.http.get<DonationModel>(this.urls.get + id).pipe();
  }

  acquireDonation(request : any){
    return this.http.post<DonationModel>(this.urls.acquireDonation, request, this.header).pipe();
  }

  getMyDonationAcquisitions(){
    return this.http.get<DonationModel[]>(this.urls.acquireDonation, this.header).pipe();
  }

  getMyDonations(){
    return this.http.get<DonationModel[]>(this.urls.userdonations, this.header).pipe();
  }

  changeDonationAcquisitionStatus(id : string, status : number){
    return this.http.put(this.urls.changeDonationAcquisitionStatus, { donationId : id, status }, this.header).pipe();
  }

  changeDonationStatus(id : string, status : number){
    return this.http.put(this.urls.changeDonationStatus, { donationId : id, status }, this.header).pipe();
  }
}
