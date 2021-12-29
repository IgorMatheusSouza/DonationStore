import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DonationAcquisitionStatusEnum } from 'src/app/enums/donationAcquisitionStatus.enum';
import { DonationStatusEnum } from 'src/app/enums/donationStatus.enum';
import { DonationModel } from 'src/app/models/donationModel';
import { DonationService } from 'src/app/services/donationService';

@Component({
  selector: 'app-myDonations',
  templateUrl: './myDonations.component.html',
  styleUrls: ['./myDonations.component.less']
})
export class MyDonationsComponent implements OnInit {

  constructor(private donationService: DonationService, private router: Router) { }

  donations: DonationModel[] = [];

    ngOnInit() {
      this.donationService.getMyDonations().subscribe((response: DonationModel[]) => {
        this.donations = response;
    });
  }

  public get GetDonationAcquisitionStatusEnum(): typeof DonationAcquisitionStatusEnum {
    return DonationAcquisitionStatusEnum;
  }

  public get DonationEnum(): typeof DonationStatusEnum {
    return DonationStatusEnum;
  }

  reserveDonation(donation : DonationModel){
    this.donationService.changeDonationAcquisitionStatus(donation.id, DonationAcquisitionStatusEnum.Active).subscribe(() => {
      donation.status = DonationStatusEnum.Reserved;
    });
  }

  cancelDonationAcquisition(donation : DonationModel){
    this.donationService.changeDonationAcquisitionStatus(donation.id, DonationAcquisitionStatusEnum.Cancelled).subscribe(() => {
      donation.status = DonationStatusEnum.Active;
      donation.donationAcquisitions[0].status = DonationAcquisitionStatusEnum.Cancelled;
      donation.donationAcquisitions = [];
    });
  }

  completeDonationAcquisition(donation : DonationModel){
    this.donationService.changeDonationAcquisitionStatus(donation.id, DonationAcquisitionStatusEnum.Completed).subscribe(() => {
      donation.status = DonationStatusEnum.Completed;
      donation.donationAcquisitions[0].status = DonationAcquisitionStatusEnum.Completed;
    });
  }

  cancelDonation(donation : DonationModel){
    this.donationService.changeDonationStatus(donation.id, DonationStatusEnum.Cancelled).subscribe(() => {
      donation.status = DonationStatusEnum.Cancelled;
    });
  }
}
