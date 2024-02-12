import * as types from "../actions/actionTypes";

export default function discountReducer(state = [], action) {
  switch (action.type) {
    case types.CREATE_PRODUCTS_DISCOUNT:
      return [...state, { ...action.discount }];
    case types.LOAD_PRODUCTS_DISCOUNT_SUCCESS:
      return action.discounts;
    case types.DELETE_PRODUCTS_DISCOUNT:
      const newState = state.filter((p) => p.id !== action.id);
      return newState;
    default:
      return state;
  }
}
