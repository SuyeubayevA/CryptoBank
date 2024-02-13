import React from "react";
import "./App.css";
import Header from "./components/common/Header";
import { Routes, Route } from "react-router-dom";
import SalesInfoPage from "./components/productInfo/SalesInfoPage";
import ProductPage from "./components/product/ProductsPage";
import WarehousesPage from "./components/warehouse/WarehousesPage";
import ProductTypesPage from "./components/productType/ProductTypesPage";
import DiscountsPage from "./components/discounts/DiscountsPage";
import PageNotFound from "./components/PageNotFound";

const App = () => {
  return (
    <div className="container-fluid">
      <Header />
      <Routes>
        <Route exact="true" path="/" element={<ProductPage />} />
        <Route path="/product-types" element={<ProductTypesPage />} />
        <Route path="/product-info" element={<SalesInfoPage />} />
        <Route path="/warehouse" element={<WarehousesPage />} />
        <Route path="/discount" element={<DiscountsPage />} />
        <Route path="*" element={<PageNotFound />} />
      </Routes>
    </div>
  );
};

export default App;
