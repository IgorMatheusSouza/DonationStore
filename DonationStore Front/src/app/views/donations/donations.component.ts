import { AfterViewInit, Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DonationService } from 'src/app/services/donationService';
import { DonationModel } from 'src/app/models/donationModel';
import { DonationStatusEnum } from 'src/app/enums/donationStatus.enum';
import { Loader } from "@googlemaps/js-api-loader"
import { GeolocationService } from 'src/app/services/geolocationService';
import { GeoLocationModel } from 'src/app/models/geoLocationModel';

@Component({
  selector: 'app-donations',
  templateUrl: './donations.component.html',
  styleUrls: ['./donations.component.less']
})
export class DonationsComponent implements OnInit, AfterViewInit {

  constructor(private donationService: DonationService, private geolocationService: GeolocationService) { }


  public mainDonations: DonationModel[] = [];

  public get DonationEnum(): typeof DonationStatusEnum {
    return DonationStatusEnum;
  }

  ngOnInit() {
    if (this.reloadPage())
      return;

    this.donationService.getDonations().subscribe((response: DonationModel[]) => {
      this.mainDonations = response;
      console.log(5);

      var location = this.geolocationService.getCurrentLocation();
      this.loadMap(response, location)
    });
  }

  ngAfterViewInit(): void {

    //this.loadScript();
  }

  private reloadPage() {
    var reload = sessionStorage.getItem("forceReaload");

    if (reload) {
      sessionStorage.removeItem("forceReaload");
      setTimeout(() => {
        window.location.reload();
      }, 50);
      return true;
    }
    return false;
  }


  private loadMap(donations: DonationModel[], location: GeoLocationModel | null) {
    if (!location)
      location = { lat: -25.363, lng: 131.044 };

    const loader = new Loader({
      apiKey: this.geolocationService.getGoogleApiKey(),
      version: "weekly"
    });

    loader.load().then(() => {

      const map = new google.maps.Map(
        document.getElementById("map") as HTMLElement,
        {
          zoom: 12,
          center: location,
        }
      );

      // const svgMarker = {
      //   path: "M10.453 14.016l6.563-6.609-1.406-1.406-5.156 5.203-2.063-2.109-1.406 1.406zM12 2.016q2.906 0 4.945 2.039t2.039 4.945q0 1.453-0.727 3.328t-1.758 3.516-2.039 3.070-1.711 2.273l-0.75 0.797q-0.281-0.328-0.75-0.867t-1.688-2.156-2.133-3.141-1.664-3.445-0.75-3.375q0-2.906 2.039-4.945t4.945-2.039z",
      //   //path: "M1468.5,670.4a456.3,456.3,0,1,0-745.4,494.2l290.8,290.8a44.9,44.9,0,0,0,63.6,0l290.8-290.8a456.7,456.7,0,0,0,100.2-494.2Zm-422.8,354.8c-101,0-183.2-82.2-183.2-183.2s82.2-183.1,183.2-183.1S1228.9,741,1228.9,842,1146.7,1025.2,1045.7,1025.2Z",
      //   fillColor: "blue",
      //   fillOpacity: 0.6,
      //   strokeWeight: 0,
      //   rotation: 0,
      //   scale: 2,
      //   anchor: new google.maps.Point(15, 30),
      // };

      var userPosition = new google.maps.Marker({
        position: location,
        icon: "https://donationstorestorage.blob.core.windows.net/donation-store-blob/map-logo-user.png",
        map: map,
        title: "Você está por aqui! (Baixa precisão :/)"
      });

      userPosition.addListener("click", () => {
        infoWindow.close();
        infoWindow.setContent(userPosition.getTitle());
        infoWindow.open(userPosition.getMap(), userPosition);
      });

      const tourStops: [google.maps.LatLngLiteral, string][] = [];

      for(var i = 0; i < donations.length; i++){
        if(donations[i].geocoding && donations[i].geocoding.lat != 0)
        {
          tourStops.push([ donations[i].geocoding , "<a href='donation/"+donations[i].id+"'><img width='160px' height='80px' class='d-block img-donation' src='"+ donations[i].images[0].fileUrl +"'>" + donations[i].title+"</a>"]);
        }
      }

      const infoWindow = new google.maps.InfoWindow();

      tourStops.forEach(([position, title], i) => {
        const marker = new google.maps.Marker({
          position,
          map,
          title: `${title}`,
          label: `${i + 1}`,
          optimized: false,
        });

        marker.addListener("click", () => {
          infoWindow.close();
          infoWindow.setContent(marker.getTitle());
          infoWindow.open(marker.getMap(), marker);
        });
      });
    });
  }
}
