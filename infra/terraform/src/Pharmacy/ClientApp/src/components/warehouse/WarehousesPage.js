import React from "react";
import Button from "@mui/material/Button";
import CreateWarehouseDialog from "./auxilaries/CreateWarehouseForm";
import { connect } from "react-redux";
import { bindActionCreators } from "@reduxjs/toolkit";
import PropTypes from "prop-types";
import * as warehouseActions from "../../redux/actions/warehouseActions";
import BasicTable from "../common/TableMaker";
import * as types from "../../entityTypes";

class WarehousePage extends React.Component {
  state = {
    create: {
      shouldBeCreated: false,
    },
    warehouse: {
      name: "",
      address: "",
    },
  };

  componentDidMount() {
    const { actions, warehouses } = this.props;

    if (warehouses.length === 0) {
      actions.loadWarehouses().catch((error) => {
        alert("Load Warehouses failed: " + error);
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
    const warehouse = { ...this.state.warehouse, [name]: value };
    this.setState({ warehouse });
  };

  handleSubmit = (event) => {
    event.preventDefault();
    this.props.actions.createWarehouse(this.state.warehouse);
    this.handleClose();
  };

  handleDelete = (warehouseName) => {
    const { actions } = this.props;
    actions.deleteWarehouse(warehouseName);
  };

  render() {
    return (
      <React.Fragment>
        <h2>Product Type Page</h2>
        <Button onClick={this.handleOpen}>Add new warehouse</Button>
        <CreateWarehouseDialog
          open={this.state.create.shouldBeCreated}
          handleClose={this.handleClose}
          handleSubmit={this.handleSubmit}
          handleOnChange={this.handleOnChange}
        />
        <BasicTable
          rows={this.props.warehouses}
          type={types.WAREHOUSES}
          deleteItem={this.handleDelete}
        />
      </React.Fragment>
    );
  }
}

WarehousePage.propTypes = {
  warehouses: PropTypes.array.isRequired,
  actions: PropTypes.object.isRequired,
};

function mapStateToProps(state) {
  return {
    warehouses: state.warehouses,
  };
}

function mapDispatchToProps(dispatch) {
  return {
    actions: {
      createWarehouse: bindActionCreators(
        warehouseActions.createWarehouse,
        dispatch
      ),
      loadWarehouses: bindActionCreators(
        warehouseActions.loadWarehouses,
        dispatch
      ),
      deleteWarehouse: bindActionCreators(
        warehouseActions.deleteWarehouse,
        dispatch
      ),
    },
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(WarehousePage);
