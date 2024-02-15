import { combineReducers } from "@reduxjs/toolkit";
import products from "./productReducers";
import productTypes from "./productTypeReducers";
import warehouses from "./warehouseReducers";
import salesInfos from "./salesInfoReducers";
import discounts from "./discountReducers";

const rootReducer = combineReducers({
  products,
  productTypes,
  warehouses,
  salesInfos,
  discounts,
});

export default rootReducer;
