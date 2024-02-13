import * as types from "../actions/actionTypes";

export default function salesInfoReducer(state = [], action) {
  switch (action.type) {
    case types.CREATE_SALES_INFO:
      return [...state, { ...action.salesInfo }];
    case types.LOAD_SALES_INFOS_SUCCESS:
      return action.salesInfos;
    case types.DELETE_SALES_INFOS:
      const newState = state.filter((p) => p.productId !== action.productId);
      return newState;
    default:
      return state;
  }
}
