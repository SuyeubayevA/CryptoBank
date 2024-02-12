import * as types from "../actions/actionTypes";

export default function productReducer(state = [], action) {
  switch (action.type) {
    case types.CREATE_PRODUCT:
      return [...state, { ...action.product }];
    case types.UPDATE_PRODUCT:
      return state.map((product) =>
        product.name === action.product.name ? action.product : product
      );
    case types.LOAD_PRODUCTS_SUCCESS:
      return action.products;
    case types.DELETE_PRODUCT:
      const newState = state.filter((p) => p.name !== action.productName);
      return newState;
    default:
      return state;
  }
}
