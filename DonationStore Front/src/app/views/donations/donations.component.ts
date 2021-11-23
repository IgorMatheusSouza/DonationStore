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

  public donations: number[] = [1,2,5,5,1,1,1,1,1,1,1,1,];

  ngOnInit() {
    var reload = sessionStorage.getItem("forceReaload");
    console.log(5);
    if(reload){
      sessionStorage.removeItem("forceReaload");
      setTimeout(() => {
        window.location.reload();
      }, 50);
    }
    else{
      this.donationService.getDonations().subscribe((response: DonationModel[]) => {
        this.mainDonations = response;
      });
    }
  }
}
