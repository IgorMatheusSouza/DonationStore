export class DonationModel {
    title: string = '';
    description: string = '';
    state: string = '';
    city: string = '';
    address: string = '';
    district: string = '';
    zipCode: string = '';
    images: ImageModel | undefined;
}

export class ImageModel {
  fileName : string = '';
  file : string = '';
}
