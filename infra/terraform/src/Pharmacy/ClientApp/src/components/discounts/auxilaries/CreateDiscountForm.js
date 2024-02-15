import React from "react";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogContentText from "@mui/material/DialogContentText";
import DialogTitle from "@mui/material/DialogTitle";

function CreateDiscountDialog(props) {
  const { open, handleClose, handleSubmit, handleOnChange } = props;

  return (
    <Dialog open={open} onClose={handleClose}>
      <DialogTitle>Create new Discount for Product</DialogTitle>
      <DialogContent>
        <DialogContentText>
          To subscribe to this website, please enter your email address here. We
          will send updates occasionally.
        </DialogContentText>
        <TextField
          autoFocus
          margin="dense"
          id="amount"
          label="Amount"
          type="number"
          fullWidth
          variant="standard"
          onChange={handleOnChange}
        />
        <TextField
          autoFocus
          margin="dense"
          id="discount"
          label="Discount"
          type="number"
          fullWidth
          variant="standard"
          onChange={handleOnChange}
        />
        <TextField
          autoFocus
          margin="dense"
          id="warehouseId"
          label="WarehouseName"
          type="number"
          fullWidth
          variant="standard"
          onChange={handleOnChange}
        />
        <TextField
          autoFocus
          margin="dense"
          id="productId"
          label="ProductName"
          type="number"
          fullWidth
          variant="standard"
          onChange={handleOnChange}
        />
      </DialogContent>
      <DialogActions>
        <Button onClick={handleClose}>Cancel</Button>
        <Button onClick={handleSubmit}>Create</Button>
      </DialogActions>
    </Dialog>
  );
}

export default CreateDiscountDialog;
