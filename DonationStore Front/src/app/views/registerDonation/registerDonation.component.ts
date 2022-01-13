import { state } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { addressModel } from 'src/app/models/addressModel';
import { ImageModel } from 'src/app/models/donationModel';
import { UserViewModel } from 'src/app/models/userViewModel';
import { AuthenticationService } from 'src/app/services/authenticationService';
import { DonationService } from 'src/app/services/donationService';
import { ExternalService } from 'src/app/services/externalService';
import { FileUploadService } from 'src/app/services/fileUploadService';
import { UserService } from 'src/app/services/userService';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { Loader } from "@googlemaps/js-api-loader"
import { GeolocationService } from 'src/app/services/geolocationService';


@Component({
  selector: 'app-registerDonation',
  templateUrl: './registerDonation.component.html',
  styleUrls: ['./registerDonation.component.less']
})
export class RegisterDonationComponent implements OnInit {

  requestError = '';

  registerDonationForm = this.formBuilder.group({
    title: ['', [Validators.required,Validators.minLength(5), Validators.maxLength(50)]],
    description: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(500)]],
    state: ['', [Validators.required]],
    city: ['', [Validators.required]],
    district: ['', [Validators.required]],
    address: ['', [Validators.required, Validators.maxLength(50)]],
    zipCode: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(10)]],
    addressNumber: ['',[Validators.required]],
    images: this.formBuilder.array([
      new FormGroup({
        fileName: new FormControl(),
        file: new FormControl(),
      }),
    ]),
    phone: ['', [Validators.required]],
    email: ['', []],
    showPhoneNumber: [true, [Validators.required]],
    showEmail: [true, [Validators.required]],
    geocoding: new FormGroup({
        lat: new FormControl(),
        lng: new FormControl(),
      })
  });


  get form() { return this.registerDonationForm.controls; }

  public wizardState: number = 1;
  public imagePath: string = '';
  public imagesModel: ImageModel[] = [];
  public user: UserViewModel = new UserViewModel();
  public phoneRegistration: boolean = false;

  fileToUpload: File | null = null;

  loader = false;

  constructor(private formBuilder: FormBuilder,
    private Router: Router,
    private donationService: DonationService,
    private externalService: ExternalService,
    private authenticationService: AuthenticationService,
    private fileUploadService: FileUploadService,
    private userService: UserService,
    private geolocationService: GeolocationService) { }

  ngOnInit() {
    if (this.authenticationService.currentUser == null)
      this.Router.navigate(['/login']);

    this.userService.getUser().subscribe((response: UserViewModel) => {
      this.registerDonationForm.controls.phone.setValue(response.phone);
      this.registerDonationForm.controls.email.setValue(response.email);
      if (!response.phone) {
        this.phoneRegistration = true;
      }
    });
  }

  registerDonation() {

    if (this.registerDonationForm.invalid || this.loader)
      return;

    this.loader = true;

    this.donationService.register(this.registerDonationForm.value).subscribe((response: any) => {
      this.Router.navigate(['/mydonations']);
    }, err => { this.requestError = err.error; }).add(() => { this.loader = false; });;
  }

  getAddressByZipCode() {
    let zipcode: string = this.registerDonationForm.controls.zipCode.value;

    this.externalService.getFullAddress(zipcode).subscribe((response: addressModel) => {
      this.registerDonationForm.controls.state.setValue(response.uf);
      this.registerDonationForm.controls.city.setValue(response.localidade);
      this.registerDonationForm.controls.district.setValue(response.bairro);
      this.registerDonationForm.controls.address.setValue(response.logradouro);

    })
  }

  getUserGeoCoding(){
    this.getGeocoding(this.registerDonationForm.controls.address.value + ' ' + this.registerDonationForm.controls.addressNumber.value + ' - ' + this.registerDonationForm.controls.district.value);
  }

  next() {
    this.wizardState++;
  }

  back() {
    this.wizardState--;
  }

  handleFileInput(event: any) {

    if (this.loader)
      return;

    this.fileToUpload = event.target.files.item(0);

    if (this.fileToUpload) {
      var file = this.fileToUpload as File;

      this.fileUploadService.postFile(file).subscribe((response: any) => {
        setTimeout(() => {
            var imagesForm = this.registerDonationForm.get('images') as FormArray;
            var model: ImageModel = { fileName: response.fileName, fileUrl:  response.fileUrl };
            imagesForm.push(this.formBuilder.group(model));

            this.imagesModel.push(response);
        }, 250);
      });
    }
  }

  registerPhone() {
    if (this.loader)
      return;

    this.loader = true;

    let phone: string = this.registerDonationForm.controls.phone.value;
    this.userService.registerPhone(phone).subscribe(() => {
      this.phoneRegistration = false;
      this.loader = false;
    });
  }

  getGeocoding(address: string) {
    var request = { address: address };

    const loader = new Loader({
      apiKey: this.geolocationService.getGoogleApiKey(),
      version: "weekly"
    });

    loader.load().then(() => {
      var geocoder = new google.maps.Geocoder();
      geocoder.geocode(request)
        .then((result) => {
          var geo = { lat : result.results[0].geometry.location.lat(), lng : result.results[0].geometry.location.lng() };
          var geocodingForm = this.registerDonationForm.get('geocoding') as FormGroup;
          geocodingForm.setValue(geo);
        })
        .catch((e) => {
          console.log("Geocode was not successful for the following reason: " + e);
        });
    });
  }
}
