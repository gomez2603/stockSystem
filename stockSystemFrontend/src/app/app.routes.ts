import { Routes } from '@angular/router';
import { StockComponent } from './stock/stock.component';
import { ProductsComponent } from './products/products.component';

export const routes: Routes = [
    {path:'',component:StockComponent},
    {path:'products',component:ProductsComponent}
];
