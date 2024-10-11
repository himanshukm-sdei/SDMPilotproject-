import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { Observable } from 'rxjs';
 
@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private https:HttpClient ) { }

  private apiUrl = environment.apiUrl;
  
  getProductData(): Observable<any> 
  {
    return this.https.get<any>(`${this.apiUrl}/Products/getproducts`);
  }

   createProductData(postData:any): Observable<any> 
  {
    return this.https.post(`${this.apiUrl}/Products/product`,postData);
  }

  UpdateProductData(postData:any): Observable<any> 
  {
    return this.https.put(`${this.apiUrl}/Products/product`,postData);
  }
  
  DeleteProductData(id:any): Observable<any> 
  {
    return this.https.delete(`${this.apiUrl}/Products/product/`+id);
  }  


  
}