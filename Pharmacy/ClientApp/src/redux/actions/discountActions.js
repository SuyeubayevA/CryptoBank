import * as types from "./actionTypes";
import * as discountApi from "../../api/discountApi";

function createDiscountSuccess(discount) {
  return { type: types.CREATE_PRODUCTS_DISCOUNT, discount };
}

export function createDiscount(discount) {
  return function (dispatch) {
    return discountApi
      .postDiscount(discount)
      .then(() => {
        dispatch(createDiscountSuccess(discount));
      })
      .catch((error) => {
        throw error;
      });
  };
}

export function loadDiscountsSuccess(discounts) {
  return { type: types.LOAD_PRODUCTS_DISCOUNT_SUCCESS, discounts };
}

export function loadDiscounts() {
  return function (dispatch) {
    return discountApi
      .getDiscounts()
      .then((discounts) => {
        dispatch(loadDiscountsSuccess(discounts));
      })
      .catch((error) => {
        throw error;
      });
  };
}

function deleteDiscountSuccess(id) {
  return { type: types.DELETE_PRODUCTS_DISCOUNT, id };
}

export function deleteDiscount(id) {
  return function (dispatch) {
    return discountApi
      .deleteDiscount(id)
      .then(() => {
        dispatch(deleteDiscountSuccess(id));
      })
      .catch((error) => {
        throw error;
      });
  };
}
