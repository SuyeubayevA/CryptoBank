import * as types from "../actions/actionTypes";

export default function warehouseReducer(state = [], action) {
  switch (action.type) {
    case types.CREATE_WAREHOUSE:
      return [...state, { ...action.warehouse }];
    case types.LOAD_WAREHOUSES_SUCCESS:
      return action.warehouses;
    case types.DELETE_WAREHOUSE:
      const newState = state.filter((p) => p.name !== action.warehouseName);
      return newState;
    default:
      return state;
  }
}
