import { HttpClient, HttpHeaders } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Product_Create_update, Products } from "./models/products";

@Injectable({providedIn:'root'})
export  class ProductService{
private readonly _http =inject(HttpClient)
private readonly _apiUrl ='http://34.219.166.49:5001/api/product'

getProducts():Observable<Products[]>{
    return this._http.get<Products[]>(this._apiUrl)
}

postProduct(dto:any):Observable<any>{
    let headers = new HttpHeaders();

return this._http.post<any>(this._apiUrl,dto)
}
}