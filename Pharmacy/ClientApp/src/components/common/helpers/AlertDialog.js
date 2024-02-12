import * as React from "react";
import Button from "@mui/material/Button";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogContentText from "@mui/material/DialogContentText";
import DialogTitle from "@mui/material/DialogTitle";

export default function AlertDialog() {
  return (
    <Dialog
      open={this.props.open}
      onClose={this.props.handleClose}
      aria-labelledby="alert-dialog-title"
      aria-describedby="alert-dialog-description"
    >
      <DialogTitle id="alert-dialog-title">
        {"Use Google's location service?"}
      </DialogTitle>
      <DialogContent>
        <DialogContentText id="alert-dialog-description">
          {this.props.textAlert}
        </DialogContentText>
      </DialogContent>
      <DialogActions>
        <Button onClick={this.props.handleClose} autoFocus>
          Ok
        </Button>
      </DialogActions>
    </Dialog>
  );
}
