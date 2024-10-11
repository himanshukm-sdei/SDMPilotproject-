import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  constructor(private https:HttpClient ) { }
  private apiUrl = environment.apiUrl;
  CreateContactData(postData:any): Observable<any> 
  {
    return this.https.post(`${this.apiUrl}/ContactForm/contact`,postData);
  }

}
