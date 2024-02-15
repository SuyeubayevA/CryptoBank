import * as types from "./actionTypes";
import * as productTypeApi from "../../api/productTypeApi";

export function createProductTypeSuccess(productType) {
  return { type: types.CREATE_PRODUCT_TYPE, productType };
}

export function createProductType(productType) {
  return function (dispatch) {
    return productTypeApi
      .postProductType(productType)
      .then(() => {
        dispatch(createProductTypeSuccess(productType));
      })
      .catch((error) => {
        throw error;
      });
  };
}

function loadProductTypesSuccess(productTypes) {
  return { type: types.LOAD_PRODUCT_TYPES_SUCCESS, productTypes };
}

export function loadProductTypes() {
  return function (dispatch) {
    return productTypeApi
      .getProductTypes()
      .then((productTypes) => {
        dispatch(loadProductTypesSuccess(productTypes));
      })
      .catch((error) => {
        throw error;
      });
  };
}

function deleteProductTypeSuccess(productTypeId) {
  return { type: types.DELETE_PRODUCT_TYPE, productTypeId };
}

export function deleteProductType(productTypeId) {
  return function (dispatch) {
    return productTypeApi
      .deleteProductType(productTypeId)
      .then(() => {
        dispatch(deleteProductTypeSuccess(productTypeId));
      })
      .catch((error) => {
        throw error;
      });
  };
}
