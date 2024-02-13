import React from "react";
import Button from "@mui/material/Button";
import CreateSalesInfoDialog from "./auxilaries/CreateSalesInfoForm";
import { connect } from "react-redux";
import { bindActionCreators } from "@reduxjs/toolkit";
import PropTypes from "prop-types";
import * as salesInfoActions from "../../redux/actions/salesInfoActions";
import BasicTable from "../common/TableMaker";
import * as types from "../../entityTypes";

class SalesInfoPage extends React.Component {
  state = {
    create: {
      shouldBeCreated: false,
    },
    salesInfo: {
      sales: 0,
      productReminder: 0,
    },
  };

  componentDidMount() {
    const { actions, salesInfos } = this.props;

    if (salesInfos.length === 0) {
      actions.loadSalesInfos().catch((error) => {
        alert("Load SalesInfos failed: " + error);
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
    const salesInfo = { ...this.state.salesInfo, [name]: value };
    this.setState({ salesInfo });
  };

  handleSubmit = (event) => {
    event.preventDefault();
    this.props.actions.createSalesInfo(this.state.salesInfo);
    this.handleClose();
  };

  handleDelete = (productId) => {
    const { actions } = this.props;
    actions.deleteSalesInfo(productId);
  };

  render() {
    return (
      <React.Fragment>
        <h2>Sales Info Page</h2>
        <Button onClick={this.handleOpen}>Add new salesInfo</Button>
        <CreateSalesInfoDialog
          open={this.state.create.shouldBeCreated}
          handleClose={this.handleClose}
          handleSubmit={this.handleSubmit}
          handleOnChange={this.handleOnChange}
        />
        <BasicTable
          rows={this.props.salesInfos}
          type={types.PRODUCTINFO}
          deleteItem={this.handleDelete}
        />
      </React.Fragment>
    );
  }
}

SalesInfoPage.propTypes = {
  salesInfos: PropTypes.array.isRequired,
  actions: PropTypes.object.isRequired,
};

function mapStateToProps(state) {
  return {
    salesInfos: state.salesInfos,
  };
}

function mapDispatchToProps(dispatch) {
  return {
    actions: {
      createSalesInfo: bindActionCreators(
        salesInfoActions.createSalesInfo,
        dispatch
      ),
      loadSalesInfos: bindActionCreators(
        salesInfoActions.loadSalesInfos,
        dispatch
      ),
      deleteSalesInfo: bindActionCreators(
        salesInfoActions.deleteSalesInfo,
        dispatch
      ),
    },
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(SalesInfoPage);
