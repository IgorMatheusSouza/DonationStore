import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DonationService } from 'src/app/services/donationService';
import { DonationModel } from 'src/app/models/donationModel';
import { DonationStatusEnum } from 'src/app/enums/donationStatus.enum';

@Component({
  selector: 'app-donations',
  templateUrl: './donations.component.html',
  styleUrls: ['./donations.component.less']
})
export class DonationsComponent implements OnInit {

  constructor(private donationService: DonationService) { }

  public mainDonations: DonationModel[] = [];

  public get DonationEnum(): typeof DonationStatusEnum {
    return DonationStatusEnum;
  }

  ngOnInit() {
    if(this.reloadPage())
      return;

    this.getLocation();

    this.donationService.getDonations().subscribe((response: DonationModel[]) => {
        this.mainDonations = response;
    });
  }

  private getLocation(){
    var lat,lng = 0;
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition((position: any) => {
        if (position) {
          console.log("Latitude: " + position.coords.latitude +
            "Longitude: " + position.coords.longitude);
          lat = position.coords.latitude;
          lng = position.coords.longitude;
          console.log(lat);
          console.log(lng);
        }
      },
        (error: any) => console.log(error));
    } else {
      alert("Geolocation is not supported by this browser.");
    }
  }

  private reloadPage (){
    var reload = sessionStorage.getItem("forceReaload");

    if(reload){
      sessionStorage.removeItem("forceReaload");
      setTimeout(() => {
        window.location.reload();
      }, 50);
      return true;
    }
    return false;
  }
}



// // The following example creates five accessible and
// // focusable markers.
// function initMap() {
//   const map = new google.maps.Map(document.getElementById("map"), {
//     zoom: 12,
//     center: { lat: 34.84555, lng: -111.8035 },
//   });
//   // Set LatLng and title text for the markers. The first marker (Boynton Pass)
//   // receives the initial focus when tab is pressed. Use arrow keys to
//   // move between markers; press tab again to cycle through the map controls.
//   const tourStops = [
//     [{ lat: 34.8791806, lng: -111.8265049 }, "<p>Batman sadadagdsgahd gahsdgashda...</p><br><img src='https://files.tecnoblog.net/wp-content/uploads/2021/04/Qual-a-ordem-cronologica-dos-filmes-do-Batman-Deny-Freeman-Flickr.jpg' width='100'height='100'>"],
//     [{ lat: 34.8559195, lng: -111.7988186 }, "Airport Mesa"],
//     [{ lat: 34.832149, lng: -111.7695277 }, "Chapel of the Holy Cross"],
//     [{ lat: 34.823736, lng: -111.8001857 }, "Red Rock Crossing"],
//     [{ lat: 34.800326, lng: -111.7665047 }, "Bell Rock"],
//   ];
//   // Create an info window to share between markers.
//   const infoWindow = new google.maps.InfoWindow();

//   // Create the markers.
//   tourStops.forEach(([position, title], i) => {
//     const marker = new google.maps.Marker({
//       position,
//       map,
//       title: `${i + 1}. ${title}`,
//       label: `${i + 1}`,
//       optimized: false,
//     });

//     // Add a click listener for each marker, and set up the info window.
//     marker.addListener("click", () => {
//       infoWindow.close();
//       infoWindow.setContent(marker.getTitle());
//       alert(5);
//       infoWindow.open(marker.getMap(), marker);
//     });
//   });
}
