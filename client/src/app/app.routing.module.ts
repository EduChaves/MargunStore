import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateCategoryComponent } from './Components/Category/create-category/create-category.component';
import { CreateProductComponent } from './Components/Products/create-product/create-product.component';

const routes: Routes = [
  {path: 'create-category', component: CreateCategoryComponent},
  {path: 'create-product', component: CreateProductComponent},
]

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)], 
  exports: [RouterModule]
})

export class AppRoutingModule { }
