import { UserViewModel } from "./userViewModel";

export class DonationAcquisitionModel {
  creationDate : Date = new Date();
  status : number = 0;
  user : UserViewModel = new UserViewModel()
}
