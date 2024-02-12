import { handleResponse, handleError } from "./apiUtils";
import * as urls from "../apiUrl";

const baseUrl = urls.API_URL + "warehouse/";

export function postWarehouse(warehouse) {
  const postRequestOptions = {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(warehouse),
  };

  return fetch(baseUrl, postRequestOptions).then().catch(handleError);
}

export function getWarehouses() {
  return fetch(baseUrl).then(handleResponse).catch(handleError);
}

export function deleteWarehouse(warehouseName) {
  return fetch(baseUrl + warehouseName, { method: "DELETE" })
    .then()
    .catch(handleError);
}
