import { handleResponse, handleError } from "./apiUtils";
import * as urls from "../apiUrl";

const baseUrl = urls.API_URL + "producttype/";

export function getProductTypes() {
  return fetch(baseUrl).then(handleResponse).catch(handleError);
}

export function postProductType(productType) {
  const postRequestOptions = {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(productType),
  };

  return fetch(baseUrl, postRequestOptions).then().catch(handleError);
}

export function deleteProductType(productTypeId) {
  return fetch(baseUrl + productTypeId, { method: "DELETE" })
    .then()
    .catch(handleError);
}
