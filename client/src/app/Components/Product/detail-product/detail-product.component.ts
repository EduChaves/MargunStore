import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/app/Models/Product';
import { ProductService } from 'src/app/Services/product.service';

@Component({
  selector: 'app-detail-product',
  templateUrl: './detail-product.component.html',
  styleUrls: ['./detail-product.component.css']
})
export class DetailProductComponent implements OnInit {
  product!: Product;
  image: string = "";
  errors: string[] = [];
  
  constructor(private productService: ProductService,
              private route: ActivatedRoute) { }
  
  ngOnInit(): void {
    var productId = this.route.snapshot.params.id as number;
    this.productService.GetProducts(productId).subscribe(result => {
      result.forEach(value => {
        this.product = value;
        this.image = this.product.images[0].image;
      });
    });
  }
}
