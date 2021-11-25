import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services/authenticationService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.less']
})
export class LogoutComponent implements OnInit {

  constructor(private authenticationService: AuthenticationService, private Router: Router) { }

  ngOnInit() {

    this.authenticationService.logout().subscribe((response: any) => {});

    setTimeout(() => {
      this.Router.navigate(['/home']);
    }, 3000);
  }

}
