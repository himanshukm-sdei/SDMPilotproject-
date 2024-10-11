import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButton, MatButtonModule } from '@angular/material/button';
import { MatCheckbox } from '@angular/material/checkbox';
import { MatError, MatFormField, MatFormFieldModule, MatLabel } from '@angular/material/form-field';
import { MatIcon, MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatToolbar, MatToolbarModule } from '@angular/material/toolbar';
import { Router } from '@angular/router';
import { PrivacyPolicyComponent } from '../../../../Common/privacy-policy/privacy-policy.component';
import { MatDialog } from '@angular/material/dialog';
import { ProductService } from '../../../../Services/ProductService/product.service';
import { ToastrService } from 'ngx-toastr';
import { ContactService } from '../../../../Services/ContactService/contact.service';

@Component({
  selector: 'app-contact-us',
  standalone: true,
  imports: [
    MatCheckbox,
    MatToolbar,
    MatLabel,
    MatIcon,
    MatFormFieldModule,
    ReactiveFormsModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatInputModule,
    CommonModule
    
  ],
  templateUrl: './contact-us.component.html',
  styleUrl: './contact-us.component.css'
})
export class ContactUsComponent {
  contactForm!: FormGroup;

  constructor(private fb: FormBuilder, private router: Router,private dialog: MatDialog,
    private _serivce:ProductService,
    private _toasterService:ToastrService,
    private _router:Router,
    private _contactservice:ContactService
  ) {
    this.contactForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(2),Validators.maxLength(20)]],
      email: ['', [Validators.required,,Validators.maxLength(50), Validators.email,Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$")]],
      message: ['', [Validators.required, Validators.minLength(10),Validators.maxLength(1000)]],
      consent: [false, Validators.requiredTrue],
      datadelectionconsent:[false,Validators.requiredTrue],
      readChecked:[false,Validators.requiredTrue]

    });
  }

  ngOnInit(): void {}

  addProduct(){
    this.router.navigate(['']);
  }

  openPrivacyPolicy(event:any): void {
    if(event.target.checked){
      this.dialog.open(PrivacyPolicyComponent, {
        width: '750px',
        height:'830px'
    });
    }
   
}

  onSubmit(): void {
    if (this.contactForm.valid) {
      const formData = this.contactForm.value;      

      // Ensure consent is explicitly given
      if (formData.consent) {
       
        // Send data to the server
        this._contactservice.CreateContactData(formData).subscribe((res)=>{
            this._toasterService.success("Data saved successfully");
            this._router.navigate(['']);

        })

        // Clear form fields if necessary
        this.contactForm.reset();
      }
    }  
  }
 
}
