import React from "react";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogContentText from "@mui/material/DialogContentText";
import DialogTitle from "@mui/material/DialogTitle";
import * as productTypeActions from "../../redux/actions/productTypeActions";
import { connect } from "react-redux";
import { bindActionCreators } from "@reduxjs/toolkit";

function CreateProductDialog(props) {
  const {
    open,
    create,
    // update,
    handleClose,
    handleSubmit,
    handleOnChange,
    product,
  } = props;

  return (
    <Dialog open={open} onClose={handleClose}>
      <DialogTitle>
        {create ? "Create new Product" : "Update new Product"}
      </DialogTitle>
      <DialogContent>
        <DialogContentText>
          To subscribe to this website, please enter your email address here. We
          will send updates occasionally.
        </DialogContentText>
        <TextField
          autoFocus
          margin="dense"
          id="name"
          label="Name"
          type="text"
          fullWidth
          variant="standard"
          onChange={handleOnChange}
          value={product.name}
        />
        <TextField
          autoFocus
          margin="dense"
          id="description"
          label="Description"
          type="text"
          fullWidth
          variant="standard"
          onChange={handleOnChange}
          value={product.description}
        />
        <TextField
          autoFocus
          margin="dense"
          id="price"
          label="Price"
          type="number"
          step={"0.01"}
          fullWidth
          variant="standard"
          onChange={handleOnChange}
          value={product.price}
        />
        <TextField
          autoFocus
          margin="dense"
          id="productTypeId"
          label="Product Type"
          type="number"
          fullWidth
          variant="standard"
          onChange={handleOnChange}
          value={product.productTypeId}
        />
      </DialogContent>
      <DialogActions>
        <Button onClick={handleClose}>Cancel</Button>
        <Button onClick={handleSubmit}>{create ? "Create" : "Update"}</Button>
      </DialogActions>
    </Dialog>
  );
}

export default CreateProductDialog;
