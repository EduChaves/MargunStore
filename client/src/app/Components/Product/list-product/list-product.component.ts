import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/Models/Product';
import { ProductService } from 'src/app/Services/product.service';

@Component({
  selector: 'app-list-product',
  templateUrl: './list-product.component.html',
  styleUrls: ['./list-product.component.css']
})
export class ListProductComponent implements OnInit {
  listProducts : Product[] = [];
  errors: string[] = [];

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.productService.GetProducts(null).subscribe(result => {
      console.log(result);
      result.forEach(value => this.listProducts.push(value))
    });
  }
}
