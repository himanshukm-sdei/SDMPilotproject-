import { createReducer, on } from '@ngrx/store';
import { addToCart } from './actions';
import { Product } from '../Models/product.model';

export interface State {
  cart: any[];
}

export const initialState: State = {
  cart: []
};

export const productReducer = createReducer(
  initialState,
  on(addToCart, (state, { product }) => ({
    ...state,
    cart: [...state.cart, product],
  }))
);
