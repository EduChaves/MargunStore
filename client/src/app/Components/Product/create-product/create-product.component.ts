import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Category } from 'src/app/Models/Category';
import { Image } from 'src/app/Models/Image';
import { CategoryService } from 'src/app/Services/category.service';
import { ImageService } from 'src/app/Services/image.service';
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
  images!: Image[];

  constructor(
    private productService: ProductService,
    private categoryService: CategoryService,
    private imageService: ImageService) { }

  ngOnInit(): void {
    // this.categoryService.GetCategoriesRequest().subscribe(response => 
    //   response.forEach(value => this.categories.push(value)));

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
    this.imageService.CreateProductImagesRequest(request).subscribe(response => console.log('Insert'),
      error => error.forEach((value: string) => this.errors.push(value)));
  }
}
