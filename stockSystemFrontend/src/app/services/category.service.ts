import { HttpClient, HttpHeaders } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import {Products } from "../models/products";
import { catalog } from "../models/catalog";
import { environment } from "../../environments/environment";

@Injectable({providedIn:'root'})
export  class CategoryService{
private readonly _http =inject(HttpClient)
private readonly _apiUrl = environment.apiUrl+"category"

getCategories():Observable<catalog[]>{
    return this._http.get<catalog[]>(this._apiUrl)
}
}