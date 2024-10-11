import { createAction, props } from '@ngrx/store'; 

export const addToCart = createAction(
  '[Product] Add to Cart',
  props<{ product: any }>()
);