import { handleResponse, handleError } from "./apiUtils";
import * as urls from "../apiUrl";

const baseUrl = urls.API_URL + "salesinfo/";

export function postSalesInfo(salesInfoModel) {
  salesInfoModel.createdDate = new Date();
  const postRequestOptions = {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(salesInfoModel),
  };

  return fetch(baseUrl, postRequestOptions).then().catch(handleError);
}

export function getSalesInfos() {
  return fetch(baseUrl).then(handleResponse).catch(handleError);
}

export function deleteSalesInfo(productId) {
  return fetch(baseUrl + productId, { method: "DELETE" })
    .then()
    .catch(handleError);
}
