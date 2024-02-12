import * as types from "../actions/actionTypes";

export default function productTypeReducer(state = [], action) {
  switch (action.type) {
    case types.CREATE_PRODUCT_TYPE:
      return [...state, { ...action.productType }];
    case types.LOAD_PRODUCT_TYPES_SUCCESS:
      return action.productTypes;
    case types.DELETE_PRODUCT_TYPE:
      const newState = state.filter((p) => p.id !== action.productTypeId);
      return newState;
    default:
      return state;
  }
}
