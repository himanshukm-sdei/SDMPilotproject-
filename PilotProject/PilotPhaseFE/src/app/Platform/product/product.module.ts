import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductRoutingModule } from './product-routing.module';
import { ProductComponent } from './product.component';
import { AppMaterialModule } from '../../app.material.module';





@NgModule({
  declarations: [
    // ProductComponent
  ],
  imports: [
    CommonModule,
    ProductRoutingModule,
    AppMaterialModule,

  ]
})
export class ProductModule { }
