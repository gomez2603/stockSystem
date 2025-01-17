import { Routes } from '@angular/router';
import { StockComponent } from './stock/stock.component';


export const routes: Routes = [
    {path:'',component:StockComponent},
    {path:'products',loadChildren:()=> import('./products/products.routes')}
];
