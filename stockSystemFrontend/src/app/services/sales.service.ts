import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { SalesDto } from '../models/salesDto';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SalesService {
private readonly _http =inject(HttpClient)
private readonly _apiUrl = environment.apiUrl+"sales"


postSales(sales: SalesDto): Observable<any> {
  return this._http.post<any>(this._apiUrl, sales);
}
}

