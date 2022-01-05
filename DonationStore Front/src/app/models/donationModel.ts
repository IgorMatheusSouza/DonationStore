import { DonationAcquisitionModel } from "./DonationAcquisitionModel";
import { GeoLocationModel } from "./geoLocationModel";
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
    status: number = 1;
    creationDate: Date = new Date();
    images: ImageModel[] = [];
    donationAcquisitions : DonationAcquisitionModel[] = [];
    user: UserViewModel = new UserViewModel();
    geocoding: GeoLocationModel = new GeoLocationModel();
}

export class ImageModel {
  fileName : string = '';
  fileUrl : string = '';
}
