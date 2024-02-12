import React from "react";
import Button from "@mui/material/Button";
import Tooltip from "@mui/material/Tooltip";
import CreateProductDialog from "./auxilaries/CreateProductForm";
import { connect } from "react-redux";
import { bindActionCreators } from "@reduxjs/toolkit";
import PropTypes from "prop-types";
import * as productActions from "../../redux/actions/productActions";
import * as productTypeActions from "../../redux/actions/productTypeActions";
import BasicTable from "../common/TableMaker";
import * as types from "../../entityTypes";

class ProductPage extends React.Component {
  state = {
    openForm: { open: false },
    create: {
      shouldBeCreated: false,
    },
    // update: {
    //   shouldBeUpdated: false,
    // },
    product: {
      name: "",
      description: "",
      price: 0,
      productTypeId: 0,
      salesInfoId: 0,
    },
  };

  componentDidMount() {
    const { actions, products, productTypes } = this.props;

    if (products.length === 0) {
      actions.loadProducts().catch((error) => {
        alert("Load products failed: " + error);
      });
    }
    if (productTypes.length === 0) {
      actions.loadProductTypes.catch((error) => {
        alert("Load product types failed: " + error);
      });
    }
  }

  handleOpen = (createform = false) => {
    const create = { ...this.state.create, shouldBeCreated: createform };
    this.setState({ create });
    // const update = { ...this.state.update, shouldBeUpdated: !createform };
    // this.setState({ update });
    const openForm = { ...this.state.openForm, open: true };
    this.setState({ openForm });
  };

  handleClose = () => {
    const create = { ...this.state.create, shouldBeCreated: false };
    this.setState({ create });
    // const update = { ...this.state.update, shouldBeUpdated: false };
    // this.setState({ update });
    const product = {
      ...this.state.product,
      ...{
        id: 0,
        name: "",
        description: "",
        price: 0,
        productTypeId: 0,
        salesInfoId: 0,
      },
    };
    this.setState({ product });
    const openForm = { ...this.state.openForm, open: false };
    this.setState({ openForm });
  };

  doUpdate = (oldProduct) => {
    // const update = { ...this.state.update, shouldBeUpdated: true };
    // this.setState({ update });
    const product = { ...this.state.product, ...oldProduct };
    this.setState({ product });
    this.handleOpen();
  };

  handleOnChange = (event) => {
    const name = event.target.id;
    const value = event.target.value;
    const product = { ...this.state.product, [name]: value };
    this.setState({ product });
  };

  handleSubmit = (event) => {
    event.preventDefault();
    if (!this.state.create.shouldBeCreated) {
      this.props.actions.updateProduct(this.state.product);
    } else {
      this.props.actions.createProduct(this.state.product);
    }
    this.handleClose();
  };

  handleDelete = (productName) => {
    const { actions } = this.props;
    actions.deleteProduct(productName);
  };

  render() {
    return (
      <React.Fragment>
        <h2>Product Page</h2>
        {this.props.productTypes.length < 0 ? (
          <Tooltip title="Should be even one Product Type exist">
            <Button disabled>Add new product</Button>
          </Tooltip>
        ) : (
          <Button onClick={() => this.handleOpen(true)}>Add new product</Button>
        )}

        <CreateProductDialog
          open={this.state.openForm.open}
          create={this.state.create.shouldBeCreated}
          // update={this.state.create.shouldBeUpdated}
          handleClose={this.handleClose}
          handleSubmit={this.handleSubmit}
          handleOnChange={this.handleOnChange}
          product={this.state.product}
        />

        <BasicTable
          rows={this.props.products}
          type={types.PRODUCTS}
          deleteItem={this.handleDelete}
          update={this.doUpdate}
        />
      </React.Fragment>
    );
  }
}

ProductPage.propTypes = {
  products: PropTypes.array.isRequired,
  productTypes: PropTypes.array.isRequired,
  actions: PropTypes.object.isRequired,
};

function mapStateToProps(state) {
  return {
    products: state.products,
    productTypes: state.productTypes,
  };
}

function mapDispatchToProps(dispatch) {
  return {
    actions: {
      createProduct: bindActionCreators(productActions.createProduct, dispatch),
      updateProduct: bindActionCreators(productActions.updateProduct, dispatch),
      loadProducts: bindActionCreators(productActions.loadProducts, dispatch),
      deleteProduct: bindActionCreators(productActions.deleteProduct, dispatch),
      loadProductTypes: bindActionCreators(
        productTypeActions.loadProductTypes,
        dispatch
      ),
    },
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(ProductPage);
