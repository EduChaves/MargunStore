import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateProductComponent } from './Components/Product/create-product/create-product.component';
import { DetailProductComponent } from './Components/Product/detail-product/detail-product.component';
import { ListProductComponent } from './Components/Product/list-product/list-product.component';

const routes: Routes = [
  {path: 'product/create-product', component: CreateProductComponent},
  {path: 'product/list-product', component: ListProductComponent},
  {path: 'product/detail-product/:id', component: DetailProductComponent}
]

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
