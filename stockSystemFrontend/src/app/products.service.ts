import { HttpClient, HttpHeaders } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import {Products } from "./models/products";

@Injectable({providedIn:'root'})
export  class ProductService{
private readonly _http =inject(HttpClient)
private readonly _apiUrl ='http://35.160.227.98:5001/api/product'

getProducts():Observable<Products[]>{
    return this._http.get<Products[]>(this._apiUrl)
}

postProduct(dto:any):Observable<any>{


return this._http.post<any>(this._apiUrl,dto)
}
updateProducts(products: Products[]): Observable<any> {
    return this._http.put(this._apiUrl, products); // Enviar los productos modificados al backend
  }
  updateProduct(product: any): Observable<any> {
    return this._http.put(this._apiUrl, product); // Enviar los productos modificados al backend
  }

  deleteProduct(productId: number): Observable<any> {
    return this._http.delete(`${this._apiUrl}/${productId}`);
  }
}