import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DonationService } from 'src/app/services/donationService';
import { DonationModel } from 'src/app/models/donationModel';

@Component({
  selector: 'app-donations',
  templateUrl: './donations.component.html',
  styleUrls: ['./donations.component.less']
})
export class DonationsComponent implements OnInit {

  constructor(private donationService: DonationService) { }

  public mainDonations: DonationModel[] = [];

  ngOnInit() {
    if(this.reloadPage())
      return;

    this.getLocation();

    this.donationService.getDonations().subscribe((response: DonationModel[]) => {
        this.mainDonations = response;
    });
  }

  private getLocation(){
    var lat,lng = 0;
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition((position: any) => {
        if (position) {
          console.log("Latitude: " + position.coords.latitude +
            "Longitude: " + position.coords.longitude);
          lat = position.coords.latitude;
          lng = position.coords.longitude;
          console.log(lat);
          console.log(lng);
        }
      },
        (error: any) => console.log(error));
    } else {
      alert("Geolocation is not supported by this browser.");
    }
  }

  private reloadPage (){
    var reload = sessionStorage.getItem("forceReaload");

    if(reload){
      sessionStorage.removeItem("forceReaload");
      setTimeout(() => {
        window.location.reload();
      }, 50);
      return true;
    }
    return false;
  }
}
