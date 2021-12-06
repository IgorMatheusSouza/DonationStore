import { DonationAcquisitionModel } from "./DonationAcquisitionModel";
import { UserViewModel } from "./userViewModel";

export class DonationModel {
    id: string = '';
    title: string = '';
    description: string = '';
    state: string = '';
    city: string = '';
    address: string = '';
    district: string = '';
    zipCode: string = '';
    creationDate: Date = new Date();
    images: ImageModel[] = [];
    donationAcquisitions : DonationAcquisitionModel[] = [];
    user: UserViewModel = new UserViewModel();
}

export class ImageModel {
  fileName : string = '';
  file : string = '';
}
