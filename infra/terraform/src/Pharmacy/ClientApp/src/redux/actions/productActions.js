import * as types from "./actionTypes";
import * as productApi from "../../api/productApi";

function createProductSuccess(product) {
  return { type: types.CREATE_PRODUCT, product };
}

export function createProduct(product) {
  return function (dispatch) {
    return productApi
      .postProduct(product)
      .then(() => {
        dispatch(createProductSuccess(product));
      })
      .catch((error) => {
        throw error;
      });
  };
}

export function updateProduct(product) {
  return function (dispatch) {
    return productApi
      .postProduct(product)
      .then(() => {
        dispatch(createProductSuccess(product));
      })
      .catch((error) => {
        throw error;
      });
  };
}

function deleteProductSuccess(productName) {
  return { type: types.DELETE_PRODUCT, productName };
}

export function deleteProduct(productName) {
  return function (dispatch) {
    return productApi
      .deleteProduct(productName)
      .then(() => {
        dispatch(deleteProductSuccess(productName));
      })
      .catch((error) => {
        throw error;
      });
  };
}

function loadProductSuccess(products) {
  return { type: types.LOAD_PRODUCTS_SUCCESS, products };
}

export function loadProducts() {
  return function (dispatch) {
    return productApi
      .getProducts()
      .then((products) => {
        dispatch(loadProductSuccess(products));
      })
      .catch((error) => {
        throw error;
      });
  };
}
