import { Component, ViewChild } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatToolbarModule} from "@angular/material/toolbar";
import { Router } from '@angular/router';
import { ProductService } from '../../Services/ProductService/product.service';
import { CommonModule } from '@angular/common';
import { ProductFormComponent } from './product-form/product-form.component';
import { ToastrService } from 'ngx-toastr';
import { ConfirmDialogComponent } from '../../Common/privacy-policy/confirm-dialog/confirm-dialog.component';

import { StoreModule } from '@ngrx/store';
import { productReducer } from './../../store/reducer';

import { Store } from '@ngrx/store';
import { addToCart } from './../../store/actions';
import { State } from './../../store/reducer';
import { constants } from '../../../constants/constants';
import { Product } from '../../Models/product.model';

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatPaginatorModule,
    MatTableModule,
    CommonModule,
    // StoreModule.forRoot({ app: appReducer })
  ],
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent {
  dataSource = new MatTableDataSource<any>();
  displayedColumns: string[] = ['name', 'description', 'category', 'price', 'action'];
 ProductData:any
 products: any[]=[] 

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private dialog: MatDialog,
    private router: Router,
    private snack: MatSnackBar,
   private _productService:ProductService,
   private _toaster:ToastrService,
   private store: Store<{ app: State }>
   
  ) {}

  ngOnInit() {
    this.getProductData();
  }

   dummyData:any[]=[]

  addProduct() {
    const dialogRef=this.dialog.open(ProductFormComponent, {
      width: '50%',
      // height:'76%'
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
       this.getProductData();
      }
    });
  }

  goToContact(): void {
    this.router.navigate(['contact']);
  }
  

  getProductData() {
    this.dataSource.data = this.dummyData;
    this._productService.getProductData().subscribe((response)=>{      
      this.dataSource=response

    })
    // this.productservice.getProductData().subscribe(
    //   (res: any) => {
    //     // Check if res has getAllProductDetails property, otherwise use res directly
    //     if (res && res.getAllProductDetails) {
    //       this.dataSource.data = res.getAllProductDetails;
    //     } else {
    //       this.dataSource.data = res; // or use a specific property as needed
    //     }
  
    //     // Assign paginator and sort to dataSource
    //     this.dataSource.paginator = this.paginator;
    //     this.dataSource.sort = this.sort;
      
    //   },
    //   error => {
    //     console.error('Error fetching product data:', error); // Log for debugging
    //     this.snack.open('Failed to fetch products', 'Close', { duration: 2000 });
    //   }
    // );
  }
  

  gotoAddUser(id: any) {
    // Navigating to an edit dialog for a specific product
    const selectedProduct = this.dataSource.data.find((x: any) => x.Id === id);
    // this.dialog.open(FormComponent, {
    //   width: '50%',
    //   data: { datakey: selectedProduct }
    // });
  }

  viewProduct(id: any) {
    this.router.navigate(['viewuser'], { queryParams: { productId: id } });
  }
  editProduct(element: any) {
    

    const dialogRef=this.dialog.open(ProductFormComponent, {
     width: '50%',
    // height:'76%',

    data:{
      datakey :element
    }
    })
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
       this.getProductData();
      }
    });
  }

  deleteProduct(id: any) { 
      this.ConfirmDialog(id);
  }
  cartProduct(item: any) { 
      let product={
        Name:item.name,
        Price: parseFloat(item.price).toFixed(2),
        Category:item.category,
        Description:item.description
      }
      this.store.dispatch(addToCart({ product }));
      this.snack.open('Added to cart', '', {
        duration: 1000, // Duration in milliseconds
      });      
  }
  ConfirmDialog(id:any) {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      width: '300px',
      data: { 
        title: 'Confirm Delete', 
        message: 'Are you sure you want to delete this product?',
        id:id         
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        // Perform delete action
        this.getProductData()
      }  
    });
  }
  viewCart(){
    this.router.navigate(['viewcart'])
  }
}
