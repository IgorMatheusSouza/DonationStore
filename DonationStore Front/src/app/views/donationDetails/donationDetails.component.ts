import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DonationService } from 'src/app/services/donationService';
import { Router } from '@angular/router';
import { DonationModel } from 'src/app/models/donationModel';
import { AuthenticationService } from 'src/app/services/authenticationService';

@Component({
  selector: 'app-donationDetails',
  templateUrl: './donationDetails.component.html',
  styleUrls: ['./donationDetails.component.less']
})

export class DonationDetailsComponent implements OnInit {

  constructor(private route: ActivatedRoute, public authenticationService: AuthenticationService, private donationService: DonationService, private router: Router) { }

  donation: DonationModel = new DonationModel();
  mainImageIndex: number = 0;
  loader = false;
  isDonationOwner = false;

  ngOnInit() {
    var id = this.route.snapshot.paramMap.get('id');

    if(!id)
      this.router.navigate(['/donations']);

    this.donationService.getDonation(id ?? '').subscribe((response: DonationModel) => {
      this.donation = response;
      if(this.authenticationService.currentUser?.email == this.donation.user.email || this.authenticationService.currentUser?.name == this.donation.user.name){
        this.isDonationOwner = true;
      }
    });
  }

  selectMainImage(index: number){
    this.mainImageIndex = index;
  }

  acquireDonation(){
    if(this.loader) return;

    if (this.authenticationService.currentUser == null)
        this.router.navigate(['/login']);

    this.loader = true;

    var request = { donationId : this.donation.id };

    this.donationService.acquireDonation(request).subscribe((response: any) => {
      this.router.navigate(['/myAcquisition']);
    }, err => { console.log(err.error) }).add(() => { this.loader = false; });;
  }

  editDonation(){
    this.router.navigate(['/underConstruction']);
  }
}
