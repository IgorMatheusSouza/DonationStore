import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-donations',
  templateUrl: './donations.component.html',
  styleUrls: ['./donations.component.less']
})
export class DonationsComponent implements OnInit {

  constructor() { }

  public mainDonations: number[] = [1,2,4,3,5,7,8];

  public donations: number[] = [1,2,5,5,1,1,1,1,1,1,1,1,];

  ngOnInit() {
    var reload = sessionStorage.getItem("forceReaload");
    console.log(5);
    if(reload){
      sessionStorage.removeItem("forceReaload");
      setTimeout(() => {
        window.location.reload();
      }, 50);
    }
  }
}
