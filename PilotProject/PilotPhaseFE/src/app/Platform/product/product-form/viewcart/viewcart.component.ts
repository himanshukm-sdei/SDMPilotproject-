import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';

import { select, StoreModule } from '@ngrx/store';
import { productReducer } from './../../../../store/reducer';
import { constants } from '../../../../../constants/constants';

import { Store } from '@ngrx/store';
import { State } from './../../../../store/reducer';
import { map, Observable } from 'rxjs';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-viewcart',
  standalone: true,
  imports: [ MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatPaginatorModule,
    MatTableModule,
    CommonModule,
    FormsModule ,MatToolbarModule
    // StoreModule.forRoot({ app: appReducer })
  ],
  templateUrl: './viewcart.component.html',
  styleUrl: './viewcart.component.css'
})
export class ViewcartComponent {
  value$!: any;
  userJson$!: Observable<string>;

  // cart$: Observable<any[]>;
  product:any[]=[]
  quantity: number=1
  Price:number=0
  productprice:number=0;
  quantityOptions:any[]=[1,2,3,4,5,6,7,8,9]
  
  constructor(private store: Store<{ product: { cart: any[] } }>) {
    this.value$ = store.select(state => state.product.cart);
    
  }

  ngOnInit() {
    this.product=this.value$.actionsObserver._value.product
    this.productprice=this.value$.actionsObserver._value.product.Price;
  }
  onInput(event: Event) {
    const input = (event.target as HTMLInputElement);
    
    // Get the current value
    let value = input.value;

    // Check if the input is not empty and has more than 2 digits
    if (value.length > 2) {
      value = value.slice(0, 2); // Limit to 2 digits
    }

    // Update the quantity
    this.quantity = Math.max(1, Math.min(99, Number(value) || 1)); // Ensure valid range
    input.value = this.quantity.toString(); // Update the input value
  }

  getSortedProductKeys(): Array<{ key: string; value: any }> {
    return Object.entries(this.product) // Convert object to array of key-value pairs
      .map(([key, value]) => ({ key, value })) // Map to object with key and value
      .sort((a, b) => a.key.localeCompare(a.key)); // Sort by key in descending order
  }
}
