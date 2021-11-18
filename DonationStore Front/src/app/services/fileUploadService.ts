import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { BaseService } from "./baseService";

@Injectable({
  providedIn: 'root'
})

export class FileUploadService extends BaseService {

  constructor(public http: HttpClient) { super(http) }

  postFile(fileToUpload: File): any{
    const endpoint = this.Baseurl + 'File';
    const formData: FormData = new FormData();
    formData.append('fileKey', fileToUpload, fileToUpload.name);
    return this.http.post(endpoint, formData, this.header).pipe();
  }
}
