import { Component, OnInit } from '@angular/core';
import { NameFormater } from './helpers/nameFormater';
import { AuthenticationService } from './services/authenticationService';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})

export class AppComponent {

  userName = '';

  constructor(private authenticationService: AuthenticationService,private nameFormater: NameFormater){
    let user = this.authenticationService.currentUser;

    if(user)
    {
      var name = this.nameFormater.getFirstName(user.name);
      this.userName = name;
    }
  }
}
