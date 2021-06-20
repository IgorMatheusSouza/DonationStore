import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';

export class BaseService {

    constructor(protected http: HttpClient) {}

    Baseurl: string =  environment.donationsStoreUrl;
}
