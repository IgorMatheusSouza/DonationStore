import { Injectable } from '@angular/core';
import { GeoLocationModel } from '../models/geoLocationModel';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})

export class GeolocationService {

  constructor() { }

  getGoogleApiKey() {
    return environment.googleApiKey;
  }

  getCurrentLocation(): GeoLocationModel{
    var result = new GeoLocationModel();
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition((position: any) => {
        if (position) {
          result.lat = position.coords.latitude;
          result.lng = position.coords.longitude;
        }
        console.log(result)
        return result;
      },
        (error: any) => console.log(error));
    } else {
      alert("Geolocation is not supported by this browser.");
    }
    return result;
  }
}

