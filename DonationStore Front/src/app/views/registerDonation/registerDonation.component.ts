import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DonationService } from 'src/app/services/donationService';


@Component({
  selector: 'app-registerDonation',
  templateUrl: './registerDonation.component.html',
  styleUrls: ['./registerDonation.component.less']
})
export class RegisterDonationComponent implements OnInit {

  registerDonationForm = this.formBuilder.group({
    title: ['', [Validators.required, Validators.email, Validators.maxLength(40)]],
    description: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(500)]],
    state: ['', [Validators.required]],
    city: ['', [Validators.required]],
    address: ['', [Validators.required]],
    zipCode: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(25)]],
  });

  public states = ['Rio de Janeiro', 'Bahia'];
  public cities = ['Rio de Janeiro', 'Nova Iguaçu'];

  get form() { return this.registerDonationForm.controls; }

  constructor(private formBuilder: FormBuilder, private Router: Router, private donationService: DonationService) {}

  ngOnInit() {
  }

  registerDonation() {
    if (this.registerDonationForm.invalid)
      return;

    this.donationService.register(this.registerDonationForm.value).subscribe((response: any) => {
        this.Router.navigate(['/donations']);
    });
  }
}
