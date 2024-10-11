import { Component, Inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { ProductService } from '../../../Services/ProductService/product.service';

@Component({
  selector: 'app-confirm-dialog',
  standalone: true,
  imports: [MatButtonModule,
    MatDialogModule
  ],
  templateUrl: './confirm-dialog.component.html',
  styleUrl: './confirm-dialog.component.css'
})
export class ConfirmDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<ConfirmDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { title: string; message: string, id: any },
    private _productService: ProductService,
    private _toaster: ToastrService
  ) { }

  onConfirm(): void {
    this.deleteProduct();     
  }

  onCancel(): void {
    this.dialogRef.close(false); // Close the dialog, returning false
  }

  deleteProduct() {
    this._productService.DeleteProductData(this.data.id).subscribe((res) => {
      this._toaster.success("Data deleted succesfully ")
      this.dialogRef.close(true);
    })
  }

}
