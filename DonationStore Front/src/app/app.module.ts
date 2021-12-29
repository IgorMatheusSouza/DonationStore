import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { SignupComponent } from './views/signup/signup.component';
import { LoginComponent } from './views/login/login.component';
import { DonationsComponent } from './views/donations/donations.component';
import { RegisterDonationComponent } from './views/registerDonation/registerDonation.component';
import { MatSelectModule } from '@angular/material/select';
import { LoaderComponent } from './components/loader/loader.component';
import { DonationDetailsComponent } from './views/donationDetails/donationDetails.component';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { MyDonationsComponent } from './views/myDonations/myDonations.component';
import { DonationAcquisitionComponent } from './views/donationAcquisition/donationAcquisition.component';
import { UnderConstructionComponent } from './views/underConstruction/underConstruction.component';

@NgModule({
  declarations: [
    AppComponent,
    SignupComponent,
    LoginComponent,
    DonationsComponent,
    RegisterDonationComponent,
    LoaderComponent,
    DonationDetailsComponent,
    MyDonationsComponent,
    DonationAcquisitionComponent,
    UnderConstructionComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    BrowserAnimationsModule,
    MatInputModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatSelectModule,
    MatCheckboxModule,
    FontAwesomeModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})


export class AppModule { }
