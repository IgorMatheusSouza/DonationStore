import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})


export class NameFormater {

  getFirstName(name :string){
    var names = name.split(' ');
    return names[0];
  }
}
