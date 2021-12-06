import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DonationModel } from 'src/app/models/donationModel';
import { DonationService } from 'src/app/services/donationService';

@Component({
  selector: 'app-donationAcquisition',
  templateUrl: './donationAcquisition.component.html',
  styleUrls: ['./donationAcquisition.component.less']
})
export class DonationAcquisitionComponent implements OnInit {

  donations: DonationModel[] = [];
  constructor(private donationService: DonationService, private router: Router) { }

  ngOnInit() {
    this.donationService.getMyDonationAcquisitions().subscribe((response: DonationModel[]) => {
        this.donations = response;
    });
  }
}
