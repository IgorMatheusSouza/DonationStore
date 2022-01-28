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

  public loader = false;
  public mainDonations: DonationModel[] = [];
  public searchModel = { searchWord: "", searchLocal: ""};

  public get DonationEnum(): typeof DonationStatusEnum {
    return DonationStatusEnum;
  }

  ngOnInit() {
    if (this.reloadPage())
      return;

    this.loader = true;
    var location = this.geolocationService.getCurrentLocation();

    this.donationService.getDonations().subscribe((response: DonationModel[]) => {
      this.mainDonations = response;
      this.loadMap(response, location);
      this.loader = false;
    }).add(() => { this.loader = false; });;
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

  public searchDonations(){
    var location = this.geolocationService.getCurrentLocation();

    this.donationService.getFilteredDonations(this.searchModel.searchWord, this.searchModel.searchLocal).subscribe((response: DonationModel[]) => {
      this.mainDonations = response;
      this.searchOnMap(response, location);
      this.loader = false;
    }).add(() => { this.loader = false; });;

  }

  private loadMap(donations: DonationModel[], location: GeoLocationModel | null) {
    var centerlocation = location;

    if (!location || location.lat == 0)
    {
      location = null;
      centerlocation = { lat:  -23.000448, lng: -43.378379 };
    }

    this.loadBaseMap(donations, location, 12, centerlocation);
  }

  private searchOnMap(donations: DonationModel[], location: GeoLocationModel | null) {
    var centerlocation = location;

    if (!location || location.lat == 0)
    {
      location = null;
      centerlocation = { lat:  -23.000448, lng: -43.378379 };
    }

    if(donations.length > 0)
    {
      centerlocation =  donations[0].geocoding;
    }

    this.loadBaseMap(donations, location, 11, centerlocation);
  }

  private loadBaseMap(donations: DonationModel[], userLocation: GeoLocationModel | null, zoomLevel: number, centerLocation: GeoLocationModel | null) {
    const loader = new Loader({
      apiKey: this.geolocationService.getGoogleApiKey(),
      version: "weekly"
    });

    loader.load().then(() => {

      const map = new google.maps.Map(
        document.getElementById("map") as HTMLElement,
        {
          zoom: zoomLevel,
          center: centerLocation,
        }
      );

      if(userLocation)
      {
        var userPosition = new google.maps.Marker({
          position: userLocation,
          icon: "https://donationstorestorage.blob.core.windows.net/donation-store-blob/map-logo-user.png",
          map: map,
          title: "Você está por aqui! (Baixa precisão :/)"
        });

        userPosition.addListener("click", () => {
          infoWindow.close();
          infoWindow.setContent(userPosition.getTitle());
          infoWindow.open(userPosition.getMap(), userPosition);
        });
      }


      const tourStops: [google.maps.LatLngLiteral, string][] = [];

      for(var i = 0; i < donations.length; i++){
        if(donations[i].geocoding && donations[i].geocoding.lat != 0)
        {
          donations[i].geocoding.lat += Math.random() / 3000 - Math.random() / 3000;
          donations[i].geocoding.lng += Math.random() / 3000 - Math.random() / 3000;
          var title = donations[i].title.length > 25 ?  donations[i].title.substring(0, 25) + '...' :  donations[i].title;
          tourStops.push([ donations[i].geocoding , "<a href='donation/"+donations[i].id+"'><img width='160px' height='80px' class='d-block img-donation' src='"+ donations[i].images[0]?.fileUrl +"'>" + title +"</a>"]);
        }
      }

      const infoWindow = new google.maps.InfoWindow();

      tourStops.forEach(([position, title], i) => {
        const marker = new google.maps.Marker({
          position,
          map,
          title: `${title}`,
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
