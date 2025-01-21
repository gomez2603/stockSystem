import { Routes } from '@angular/router';
import { StockComponent } from './stock/stock.component';
import { LoginComponent } from './login/login/login.component';
import { authGuard } from './guards/auth.guard';
import { LayoutComponent } from './layout/layout.component';


export const routes: Routes = [
    {path:'',canActivate:[authGuard],component:LayoutComponent,
        children: [
            { path: '', component: StockComponent }, // Ruta por defecto
            { path: 'products', loadChildren: () => import('./products/products.routes') }
          ]

    },
    {path:'login',component:LoginComponent},

];
