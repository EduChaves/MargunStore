import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Category } from 'src/app/Models/Category';
import { CategoryService } from 'src/app/Services/category.service';

@Component({
  selector: 'app-create-category',
  templateUrl: './create-category.component.html',
  styleUrls: ['./create-category.component.css']
})
export class CreateCategoryComponent implements OnInit {
  form: any;
  errors: string[] = [];

  constructor(private categoryService: CategoryService) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl(null, [Validators.required, Validators.minLength(3), Validators.maxLength(20)])
    });
  }

  CreateCategory(){
    const request = this.form.value;
    this.categoryService.CreateCategoryRequest(request).subscribe(response => console.log('Insert'), 
      error => error.forEach((value: string) => this.errors.push(value)));
  }

}
