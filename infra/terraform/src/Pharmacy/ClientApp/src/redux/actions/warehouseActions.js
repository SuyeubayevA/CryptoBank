import * as types from "./actionTypes";
import * as warehouseApi from "../../api/warehouseApi";

function createWarehouseSuccess(warehouse) {
  return { type: types.CREATE_WAREHOUSE, warehouse };
}

export function createWarehouse(warehouse) {
  return function (dispatch) {
    return warehouseApi
      .postWarehouse(warehouse)
      .then(() => {
        dispatch(createWarehouseSuccess(warehouse));
      })
      .catch((error) => {
        throw error;
      });
  };
}

function deleteWarehouseSuccess(warehouseName) {
  return { type: types.DELETE_WAREHOUSE, warehouseName };
}

export function deleteWarehouse(warehouseName) {
  return function (dispatch) {
    return warehouseApi
      .deleteWarehouse(warehouseName)
      .then(() => {
        dispatch(deleteWarehouseSuccess(warehouseName));
      })
      .catch((error) => {
        throw error;
      });
  };
}

function loadWarehouseSuccess(warehouses) {
  return { type: types.LOAD_WAREHOUSES_SUCCESS, warehouses };
}

export function loadWarehouses() {
  return function (dispatch) {
    return warehouseApi
      .getWarehouses()
      .then((warehouses) => {
        dispatch(loadWarehouseSuccess(warehouses));
      })
      .catch((error) => {
        throw error;
      });
  };
}
