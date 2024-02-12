import React from "react";
import { NavLink } from "react-router-dom";

const Header = () => {
  const activeStyle = { color: "#F15B2A" };

  return (
    <nav>
      <NavLink to="/" activestyle={activeStyle} exact="true">
        Products
      </NavLink>
      {" | "}
      <NavLink to="product-types" activestyle={activeStyle}>
        Product Types
      </NavLink>
      {" | "}
      <NavLink to="product-info" activestyle={activeStyle}>
        Product Infos
      </NavLink>
      {" | "}
      <NavLink to="warehouse" activestyle={activeStyle}>
        Warehouses
      </NavLink>
      {" | "}
      <NavLink to="discount" activestyle={activeStyle}>
        Discounts
      </NavLink>
    </nav>
  );
};

export default Header;
