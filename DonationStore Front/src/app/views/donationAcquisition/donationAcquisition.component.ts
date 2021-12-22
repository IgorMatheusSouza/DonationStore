import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DonationAcquisitionStatusEnum } from 'src/app/enums/donationAcquisitionStatus.enum';
import { DonationStatusEnum } from 'src/app/enums/donationStatus.enum';
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

  public get DonationAcquisitionEnum(): typeof DonationAcquisitionStatusEnum {
    return DonationAcquisitionStatusEnum;
  }

  public get DonationEnum(): typeof DonationStatusEnum {
    return DonationStatusEnum;
  }

  cancelDonationAcquisition(donation : DonationModel){
    this.donationService.changeDonationAcquisitionStatus(donation.id, DonationAcquisitionStatusEnum.Cancelled).subscribe(() => {
      donation.status = DonationStatusEnum.Active;
      donation.donationAcquisitions[0].status = DonationAcquisitionStatusEnum.Cancelled;
    });
  }
}
