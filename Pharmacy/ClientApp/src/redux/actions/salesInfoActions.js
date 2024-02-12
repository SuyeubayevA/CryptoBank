import * as types from "./actionTypes";
import * as salesInfoApi from "../../api/salesInfoApi";

function createSalesInfoSuccess(salesInfo) {
  return { type: types.CREATE_SALES_INFO, salesInfo };
}

export function createSalesInfo(salesInfo) {
  salesInfo.CreatedDate = new Date();
  return function (dispatch) {
    return salesInfoApi
      .postSalesInfo(salesInfo)
      .then(() => {
        dispatch(createSalesInfoSuccess(salesInfo));
      })
      .catch((error) => {
        throw error;
      });
  };
}

export function loadSalesInfosSuccess(salesInfos) {
  return { type: types.LOAD_SALES_INFOS_SUCCESS, salesInfos };
}

export function loadSalesInfos() {
  return function (dispatch) {
    return salesInfoApi
      .getSalesInfos()
      .then((salesInfos) => {
        dispatch(loadSalesInfosSuccess(salesInfos));
      })
      .catch((error) => {
        throw error;
      });
  };
}

function deleteSalesInfoSuccess(productId) {
  return { type: types.DELETE_SALES_INFOS, productId };
}

export function deleteSalesInfo(productId) {
  return function (dispatch) {
    return salesInfoApi
      .deleteSalesInfo(productId)
      .then(() => {
        dispatch(deleteSalesInfoSuccess(productId));
      })
      .catch((error) => {
        throw error;
      });
  };
}
