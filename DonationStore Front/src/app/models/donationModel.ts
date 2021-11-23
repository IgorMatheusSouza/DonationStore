export class DonationModel {
    title: string = '';
    description: string = '';
    state: string = '';
    city: string = '';
    address: string = '';
    district: string = '';
    zipCode: string = '';
    creationDate: Date = new Date();
    images: ImageModel[] = [];
}

export class ImageModel {
  fileName : string = '';
  file : string = '';
}
