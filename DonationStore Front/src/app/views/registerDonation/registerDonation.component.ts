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
    title: ['', [Validators.required, Validators.maxLength(50)]],
    description: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(3000)]],
    state: ['', [Validators.required]],
    city: ['', [Validators.required]],
    address: ['', [Validators.required, Validators.maxLength(50)]],
    zipCode: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(10)]]
  });

  public states: any  = ['Rio de Janeiro', 'Bahia'];
  public cities: any = ['Rio de Janeiro', 'Nova Iguaçu'];

  get form() { return this.registerDonationForm.controls; }

  constructor(private formBuilder: FormBuilder, private Router: Router, private donationService: DonationService) {}

  ngOnInit() {
  }

  registerDonation() {
    console.log(5);

    if (this.registerDonationForm.invalid)
      return;

    this.donationService.register(this.registerDonationForm.value).subscribe((response: any) => {
        this.Router.navigate(['/donations']);
    });
  }
}
