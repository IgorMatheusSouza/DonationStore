import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DonationService } from 'src/app/services/donationService';
import { Router } from '@angular/router';
import { DonationModel } from 'src/app/models/donationModel';

@Component({
  selector: 'app-donationDetails',
  templateUrl: './donationDetails.component.html',
  styleUrls: ['./donationDetails.component.less']
})

export class DonationDetailsComponent implements OnInit {

  constructor(private route: ActivatedRoute, private donationService: DonationService, private router: Router) { }

  donation: DonationModel = new DonationModel();

  mainImageIndex: number = 0;

  ngOnInit() {
    var id = this.route.snapshot.paramMap.get('id');

    if(!id)
      this.router.navigate(['/donations']);

    this.donationService.getDonation(id ?? '').subscribe((response: DonationModel) => {
      this.donation = response;
    });
  }

  selectMainImage(index: number){
    console.log(index);
    this.mainImageIndex = index;
  }

}
