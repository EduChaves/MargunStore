import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Category } from 'src/app/Models/Category';
import { ProductImage } from 'src/app/Models/ProductImage';
import { CategoryService } from 'src/app/Services/category.service';
import { ProductImagesService } from 'src/app/Services/product-images.service';
import { ProductService } from 'src/app/Services/product.service';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css']
})
export class CreateProductComponent implements OnInit {
  form!: FormGroup;
  errors: string[] = [];
  categories!: Category[];
  images!: ProductImage[];

  constructor(
    private productService: ProductService,
    private categoryService: CategoryService,
    private productImagesService: ProductImagesService) { }

  ngOnInit(): void {
    this.categoryService.GetCategoriesRequest().subscribe(response => 
      response.forEach(value => this.categories.push(value)));

    this.form = new FormGroup({
      name: new FormControl(null, [Validators.required, Validators.minLength(3), Validators.maxLength(20)]),
      description: new FormControl(null, [Validators.required, Validators.minLength(7), Validators.maxLength(50)]),
      length: new FormControl(null, [Validators.required, Validators.minLength(3), Validators.maxLength(20)]),
      value: new FormControl(null, [Validators.required, Validators.minLength(3), Validators.maxLength(20)]),
      quantity: new FormControl(null, [Validators.required, Validators.minLength(3), Validators.maxLength(20)]),
      category: new FormControl(null, Validators.required),
      images: new FormControl(null, Validators.required)
    });
  }

  CreateProduct(){
    const request = this.form.value;
    this.productService.CreateProduct(request).subscribe(response => console.log('Insert'), 
      error => error.forEach((value: string) => this.errors.push(value)));
  }

  CreateProductImages(){
    const request = this.images;
    this.productImagesService.CreateProductImagesRequest(request).subscribe(response => console.log('Insert'),
      error => error.forEach((value: string) => this.errors.push(value)));
  }
}
