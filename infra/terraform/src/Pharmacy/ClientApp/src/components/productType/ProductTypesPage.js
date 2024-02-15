import React from "react";
import Button from "@mui/material/Button";
import CreateProductTypeDialog from "./auxilaries/CreateProductTypeForm";
import { connect } from "react-redux";
import { bindActionCreators } from "@reduxjs/toolkit";
import PropTypes from "prop-types";
import * as productTypeActions from "../../redux/actions/productTypeActions";
import BasicTable from "../common/TableMaker";
import * as types from "../../entityTypes";

class ProductTypePage extends React.Component {
  state = {
    create: {
      shouldBeCreated: false,
    },
    productType: {
      name: "",
      properties: "",
    },
  };

  componentDidMount() {
    const { actions, productTypes } = this.props;

    if (productTypes.length === 0) {
      actions.loadProductTypes().catch((error) => {
        alert("Load product types failed: " + error);
      });
    }
  }

  handleOpen = () => {
    const create = { ...this.state.create, shouldBeCreated: true };
    this.setState({ create });
  };

  handleClose = () => {
    const create = { ...this.state.create, shouldBeCreated: false };
    this.setState({ create });
  };

  handleOnChange = (event) => {
    const name = event.target.id;
    const value = event.target.value;
    const productType = { ...this.state.productType, [name]: value };
    this.setState({ productType });
  };

  handleSubmit = (event) => {
    event.preventDefault();
    this.props.actions.createProductType(this.state.productType);
    this.handleClose();
  };

  handleDelete = (productTypId) => {
    const { actions } = this.props;
    actions.deleteProductType(productTypId);
  };

  render() {
    return (
      <React.Fragment>
        <h2>Product Type Page</h2>
        <Button onClick={this.handleOpen}>Add new product type</Button>
        <CreateProductTypeDialog
          open={this.state.create.shouldBeCreated}
          handleClose={this.handleClose}
          handleSubmit={this.handleSubmit}
          handleOnChange={this.handleOnChange}
        />
        <BasicTable
          rows={this.props.productTypes}
          type={types.PRODUCTTYPES}
          deleteItem={this.handleDelete}
        />
      </React.Fragment>
    );
  }
}

ProductTypePage.propTypes = {
  productTypes: PropTypes.array.isRequired,
  actions: PropTypes.object.isRequired,
};

function mapStateToProps(state) {
  return {
    productTypes: state.productTypes,
  };
}

function mapDispatchToProps(dispatch) {
  return {
    actions: {
      createProductType: bindActionCreators(
        productTypeActions.createProductType,
        dispatch
      ),
      loadProductTypes: bindActionCreators(
        productTypeActions.loadProductTypes,
        dispatch
      ),
      deleteProductType: bindActionCreators(
        productTypeActions.deleteProductType,
        dispatch
      ),
    },
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(ProductTypePage);
