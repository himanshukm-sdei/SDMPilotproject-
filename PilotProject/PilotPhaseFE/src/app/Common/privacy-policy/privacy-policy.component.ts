import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-privacy-policy',
  standalone: true,
  imports: [
    MatButtonModule
  ],
  templateUrl: './privacy-policy.component.html',
  styleUrl: './privacy-policy.component.css'
})
export class PrivacyPolicyComponent {
  constructor(public dialogRef: MatDialogRef<PrivacyPolicyComponent>) {}

  onClose(): void {
      this.dialogRef.close();
  }
}
