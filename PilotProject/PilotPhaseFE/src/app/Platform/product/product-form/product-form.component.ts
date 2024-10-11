import { CommonModule } from '@angular/common';
import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ProductService } from '../../../Services/ProductService/product.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';


@Component({
  selector: 'app-product-form',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    CommonModule,
    ReactiveFormsModule,
    MatInputModule,
    MatButtonModule,
    MatCheckboxModule,
    MatFormFieldModule,

  ],
  templateUrl: './product-form.component.html',
  // providers:[HttpClient ],
  styleUrl: './product-form.component.css'
})
export class ProductFormComponent {
  productForm: FormGroup;

  constructor(private fb: FormBuilder, private dialog: MatDialogRef<ProductFormComponent>,
    @Inject(MAT_DIALOG_DATA) public _data: any,
    private _productService: ProductService,
    private _toaster: ToastrService,
    private router: Router) {
    this.productForm = this.fb.group({
      id: [],
      name: ['', [Validators.required, Validators.maxLength(15)]],
      description: ['', [Validators.required, Validators.maxLength(500)]],
      category: ['', [Validators.required, Validators.maxLength(50)]],
      price: [0, [Validators.required, Validators.min(0), Validators.max(10000)]],
      isActive: [true],
    });
    if (this._data != null) {
      this.productForm.patchValue(this._data.datakey)
    }

  }

  ngOnInit(): void { }

  onSubmit(): void {
    if (this.productForm.valid) {
      // let product={    this.productForm.value      
      // }
      if (this._data == null) {
        this._productService.createProductData(this.productForm.value).subscribe((res) => {
          this._toaster.success("Data saved successfully")
          this.dialog.close(true)
        })
      }
      else {
        this._productService.UpdateProductData(this.productForm.value).subscribe((res) => {
          this._toaster.success("Data updated successfully")
          this.dialog.close(true)
        })
      }
    }
  }
  onCancel() {
    this.dialog.close(false);
  }
}
