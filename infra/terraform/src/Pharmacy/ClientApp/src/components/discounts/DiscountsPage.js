import React from "react";
import Button from "@mui/material/Button";
import CreateDiscountDialog from "./auxilaries/CreateDiscountForm";
import { connect } from "react-redux";
import { bindActionCreators } from "@reduxjs/toolkit";
import PropTypes from "prop-types";
import * as discountActions from "../../redux/actions/discountActions";
import BasicTable from "../common/TableMaker";
import * as types from "../../entityTypes";

class DiscountPage extends React.Component {
  state = {
    create: {
      shouldBeCreated: false,
    },
    discount: {
      amount: 0,
      discount: 0,
      warehouseId: "",
      productId: "",
    },
  };

  componentDidMount() {
    const { actions, discounts } = this.props;

    if (discounts.length === 0) {
      actions.loadDiscounts().catch((error) => {
        alert("Load Discounts for Products failed: " + error);
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
    const discount = { ...this.state.discount, [name]: value };
    this.setState({ discount });
  };

  handleSubmit = (event) => {
    event.preventDefault();
    this.props.actions.createDiscount(this.state.discount);
    this.handleClose();
  };

  handleDelete = (id) => {
    const { actions } = this.props;
    actions.deleteDiscount(id);
  };

  render() {
    return (
      <React.Fragment>
        <h2>Products Discount Page</h2>
        <Button onClick={this.handleOpen}>Add new discount for product</Button>
        <CreateDiscountDialog
          open={this.state.create.shouldBeCreated}
          handleClose={this.handleClose}
          handleSubmit={this.handleSubmit}
          handleOnChange={this.handleOnChange}
        />
        <BasicTable
          rows={this.props.discounts}
          type={types.PRODUCTDISCOUNT}
          deleteItem={this.handleDelete}
        />
      </React.Fragment>
    );
  }
}

DiscountPage.propTypes = {
  discounts: PropTypes.array.isRequired,
  actions: PropTypes.object.isRequired,
};

function mapStateToProps(state) {
  return {
    discounts: state.discounts,
  };
}

function mapDispatchToProps(dispatch) {
  return {
    actions: {
      createDiscount: bindActionCreators(
        discountActions.createDiscount,
        dispatch
      ),
      loadDiscounts: bindActionCreators(
        discountActions.loadDiscounts,
        dispatch
      ),
      deleteDiscount: bindActionCreators(
        discountActions.deleteDiscount,
        dispatch
      ),
    },
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(DiscountPage);
