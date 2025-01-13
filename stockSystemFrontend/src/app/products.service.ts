import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Products } from "./models/products";

@Injectable({providedIn:'root'})
export  class ProductService{
private readonly _http =inject(HttpClient)
private readonly _apiUrl ='http://localhost:5001/api/product'

getProducts():Observable<Products[]>{
    return this._http.get<Products[]>(this._apiUrl)
}



}