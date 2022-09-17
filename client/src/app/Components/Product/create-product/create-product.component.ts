import { toTypeScript } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Category } from 'src/app/Models/Category';
import { Image } from 'src/app/Models/Image';
import { Product } from 'src/app/Models/Product';
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
  categories: Category[] = [];
  imageData: string = "";
  listImage: Image[] = [];

  constructor(
    private productService: ProductService,
    private categoryService: CategoryService,
    private snackBar: MatSnackBar,
    private router: Router) { }

  ngOnInit(): void {
    this.categoryService.GetCategoriesRequest().subscribe(response => 
      response.forEach(value => this.categories.push(value)));

    this.form = new FormGroup({
      name: new FormControl(null, [Validators.required, Validators.minLength(3), Validators.maxLength(20)]),
      description: new FormControl(null, [Validators.required, Validators.minLength(5), Validators.maxLength(30)]),
      length: new FormControl(null, [Validators.required, Validators.minLength(1), Validators.maxLength(10)]),
      value: new FormControl(null, [Validators.required, Validators.minLength(3), Validators.maxLength(20)]),
      quantity: new FormControl(null, [Validators.required]),
      category: new FormControl(null, Validators.required),
      images: new FormControl(null, Validators.required)
    });
  }

  get Controls(){
    return this.form.controls;
  }

  SubmitForm(){
    var request = this.form.value as Product;
    request.images = this.listImage;
    request.categoryId = request.category.id;
    this.productService.CreateProduct(request).subscribe(response => {
      this.router.navigate(['product/list-product']);
      this.snackBar.open("Produto cardastrado com sucesso", "", {
        duration: 2000,
        verticalPosition: "top",
        horizontalPosition: "end"
      });
    }, 
      error => error.forEach((value: string) => this.errors.push(value)));
  }

  SelectImage(image: any){
    const reader = new FileReader();
    reader.onload = ((value: any) => {
      document.getElementById("image")?.removeAttribute("hidden");
      document.getElementById("image")?.setAttribute("src", value.target?.result)
     this.imageData = value.target?.result;
     var image = new Image;
     image.image = this.imageData
      this.listImage.push(image);
    });
    
    reader.readAsDataURL(image.target.files[0] as File);
  }
}
