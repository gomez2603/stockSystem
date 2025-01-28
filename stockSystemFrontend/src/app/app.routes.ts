import { Routes } from '@angular/router';
import { StockComponent } from './stock/stock.component';
import { LoginComponent } from './login/login/login.component';
import { authGuard } from './guards/auth.guard';
import { LayoutComponent } from './layout/layout.component';
import { SalesComponent } from './sales/sales.component';
import { roleguardGuard } from './guards/roleguard.guard';


export const routes: Routes = [
    {path:'',canActivate:[authGuard],component:LayoutComponent,
        children: [
            { path: '', component: SalesComponent }, // Ruta por defecto
            { path: 'products',
                canActivate: [roleguardGuard(['ADMIN', 'STOCKER'])],
                 loadChildren: () => import('./products/products.routes') }
          ]

    },
    {path:'login',component:LoginComponent},

];
