import { environment } from '../../environments/environment';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { UserLoginViewModel } from '../models/userLoginViewModel';
import { Observable } from 'rxjs';

export class BaseService {
    public currentUser: UserLoginViewModel | null = null;

    protected Baseurl: string =  environment.donationsStoreUrl;
    protected header: { headers: HttpHeaders } = {  headers: new HttpHeaders() };

    constructor(protected http: HttpClient) {
        var user = localStorage.getItem('User');

        if(user)
        {
          this.currentUser = JSON.parse(user);
          const headers = new HttpHeaders();
          headers.append('userToken', this.currentUser?.token ?? '');
          this.header  = { headers: headers };
        }
    }
}
