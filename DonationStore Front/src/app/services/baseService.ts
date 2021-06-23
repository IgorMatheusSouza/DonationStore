import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { UserLoginViewModel } from '../models/userLoginViewModel';

export class BaseService {
    public currentUser: UserLoginViewModel | null = null;
    protected Baseurl: string =  environment.donationsStoreUrl;
    
    constructor(protected http: HttpClient) {
        var user = localStorage.getItem('User');

        if(user)
            this.currentUser = JSON.parse(user);
    }
}