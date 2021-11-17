import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.less']
})
export class HomeComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    var reload = sessionStorage.getItem("forceReaload");
    if(reload){
      sessionStorage.removeItem("forceReaload");
      setTimeout(() => {
        window.location.reload();
      }, 50);
    }
  }

}
