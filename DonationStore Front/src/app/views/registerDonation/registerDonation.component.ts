import { state } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { addressModel } from 'src/app/models/addressModel';
import { DonationService } from 'src/app/services/donationService';
import { ExternalService } from 'src/app/services/externalService';


@Component({
  selector: 'app-registerDonation',
  templateUrl: './registerDonation.component.html',
  styleUrls: ['./registerDonation.component.less']
})
export class RegisterDonationComponent implements OnInit {

  registerDonationForm = this.formBuilder.group({
    title: ['', [Validators.required, Validators.maxLength(50)]],
    description: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(3000)]],
    state: ['', [Validators.required]],
    city: ['', [Validators.required]],
    district: ['', [Validators.required]],
    address: ['', [Validators.required, Validators.maxLength(50)]],
    zipCode: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(10)]]
  });

  get form() { return this.registerDonationForm.controls; }

  public wizardState: number = 1;

  constructor(private formBuilder: FormBuilder, private Router: Router, private donationService: DonationService, private externalService: ExternalService) { }

  ngOnInit() {
  }

  registerDonation() {
    console.log(5);

    if (this.registerDonationForm.invalid)
      return;

    this.donationService.register(this.registerDonationForm.value).subscribe((response: any) => {
      this.Router.navigate(['/donations']);
    }, err => console.log(err));
  }

  getAddressByZipCode() {
    let zipcode : string = this.registerDonationForm.controls.zipCode.value;

    this.externalService.getFullAddress(zipcode).subscribe((response: addressModel) => {
      this.registerDonationForm.controls.state.setValue(response.uf);
      this.registerDonationForm.controls.city.setValue(response.localidade);
      this.registerDonationForm.controls.district.setValue(response.bairro);
      this.registerDonationForm.controls.address.setValue(response.logradouro);
    })
  }

  next() {
    this.wizardState++;
  }

  back() {
    this.wizardState--;
  }
}
