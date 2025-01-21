import { Routes } from '@angular/router';
import { StockComponent } from './stock/stock.component';
import { LoginComponent } from './login/login/login.component';


export const routes: Routes = [
    {path:'',component:StockComponent},
    {path:'login',component:LoginComponent},
    {path:'products',loadChildren:()=> import('./products/products.routes')}
];
