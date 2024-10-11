import { Routes } from '@angular/router';
import { ProductComponent } from './Platform/product/product.component';
import { ContactUsComponent } from './Platform/product/ContactUS/contact-us/contact-us.component';
import { PrivacyPolicyComponent } from './Common/privacy-policy/privacy-policy.component';
import { ViewcartComponent } from './Platform/product/product-form/viewcart/viewcart.component';


export const routes: Routes = [
    {
        path:'',
        component: ProductComponent
    },
    {
        path:"contact",
        component:ContactUsComponent
    },
    {
        path:'viewcart',
        component:ViewcartComponent
    }
   
    
];
