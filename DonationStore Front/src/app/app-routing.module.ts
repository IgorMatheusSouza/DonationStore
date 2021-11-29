import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DonationDetailsComponent } from './views/donationDetails/donationDetails.component';
import { DonationsComponent } from './views/donations/donations.component';
import { HomeComponent } from './views/home/home.component';
import { LoginComponent } from './views/login/login.component';
import { LogoutComponent } from './views/logout/logout.component';
import { MyDonationsComponent } from './views/myDonations/myDonations.component';
import { RegisterDonationComponent } from './views/registerDonation/registerDonation.component';
import { SignupComponent } from './views/signup/signup.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'home',
    component: HomeComponent
  },
  {
    path: 'signup',
    component: SignupComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'donations',
    component: DonationsComponent
  },
  {
    path: 'registerDonation',
    component: RegisterDonationComponent
  },
  {
    path: 'logout',
    component: LogoutComponent
  },
  {
    path: 'donation/:id',
    component: DonationDetailsComponent
  },
  {
    path: 'mydonations',
    component: MyDonationsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
