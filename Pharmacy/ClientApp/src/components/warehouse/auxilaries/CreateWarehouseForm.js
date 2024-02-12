import React from "react";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogContentText from "@mui/material/DialogContentText";
import DialogTitle from "@mui/material/DialogTitle";

function CreateWarehouseDialog(props) {
  const { open, handleClose, handleSubmit, handleOnChange } = props;

  return (
    <Dialog open={open} onClose={handleClose}>
      <DialogTitle>Create new Warehouse</DialogTitle>
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
        />
        <TextField
          autoFocus
          margin="dense"
          id="address"
          label="Address"
          type="text"
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

export default CreateWarehouseDialog;
