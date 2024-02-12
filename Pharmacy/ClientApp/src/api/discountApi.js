import { handleResponse, handleError } from "./apiUtils";
import * as urls from "../apiUrl";

const baseUrl = urls.API_URL + "productamount/";

export function postDiscount(discountModel) {
  const postRequestOptions = {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(discountModel),
  };

  return fetch(baseUrl, postRequestOptions).then().catch(handleError);
}

export function getDiscounts() {
  return fetch(baseUrl).then(handleResponse).catch(handleError);
}

export function deleteDiscount(id) {
  return fetch(baseUrl + id, { method: "DELETE" })
    .then()
    .catch(handleError);
}
