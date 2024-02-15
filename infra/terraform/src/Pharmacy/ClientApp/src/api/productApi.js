import { handleResponse, handleError } from "./apiUtils";
import * as urls from "../apiUrl";

const baseUrl = urls.API_URL + "product/";

export function postProduct(product) {
  const postRequestOptions = {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(product),
  };

  return fetch(baseUrl, postRequestOptions).then().catch(handleError);
}

export function getProducts() {
  return fetch(baseUrl).then(handleResponse).catch(handleError);
}

export function deleteProduct(productName) {
  return fetch(baseUrl + productName, { method: "DELETE" })
    .then()
    .catch(handleError);
}
