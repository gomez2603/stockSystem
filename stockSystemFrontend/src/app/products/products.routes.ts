import { Routes } from "@angular/router";

export const routes: Routes = [
    {path:'',loadComponent: () => import('./product-table/product-table.component')},
   
];
export default routes
