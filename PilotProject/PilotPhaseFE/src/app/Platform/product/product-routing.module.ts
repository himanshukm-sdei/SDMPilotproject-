import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductComponent } from './product.component';
import { ContactUsComponent } from './ContactUS/contact-us/contact-us.component';

const routes: Routes = [
  {
    path:'',
    component:ProductComponent

  },
   
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductRoutingModule { }
