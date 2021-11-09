import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { addressModel } from '../models/addressModel';
import { BaseService } from './baseService';

@Injectable({
  providedIn: 'root'
})

export class ExternalService extends BaseService {

  constructor(public http: HttpClient) { super(http) }

  getFullAddress(zipCode : string) : Observable<addressModel>{
    return this.http.get<addressModel>(`https://viacep.com.br/ws/${zipCode}/json/`).pipe();
  }
}