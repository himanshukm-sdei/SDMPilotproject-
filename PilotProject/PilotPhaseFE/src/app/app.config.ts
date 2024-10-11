import { ApplicationConfig, importProvidersFrom, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { provideHttpClient } from '@angular/common/http';
import { provideToastr } from 'ngx-toastr';
import { provideAnimations } from '@angular/platform-browser/animations';

import { StoreModule } from '@ngrx/store';
import { productReducer } from './store/reducer';

export const appConfig: ApplicationConfig = {
  providers: [
    // StoreModule.forRoot({ app: appReducer }),

    importProvidersFrom(StoreModule.forRoot({ app: productReducer })),
    provideZoneChangeDetection({ eventCoalescing: true }), 
    provideRouter(routes),
    provideHttpClient(), 
    provideAnimationsAsync(),
   // provideAnimations(),
    provideToastr()]
};
