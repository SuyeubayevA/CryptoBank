import { configureStore } from "@reduxjs/toolkit";
import rootReducer from "./reducers";
import thunk from "redux-thunk";

export const store = (initialState) =>
  configureStore({
    reducer: rootReducer,
    middleware: [thunk],
    initialState,
  });
