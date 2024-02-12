import React from "react";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogContentText from "@mui/material/DialogContentText";
import DialogTitle from "@mui/material/DialogTitle";

function CreateSalesInfoDialog(props) {
  const { open, handleClose, handleSubmit, handleOnChange } = props;
  // const [state, setState] = useState({
  //   sales: 0,
  //   productReminder: 0,
  // });

  return (
    <Dialog open={open} onClose={handleClose}>
      <DialogTitle>Create new Sales Info</DialogTitle>
      <DialogContent>
        <DialogContentText>
          To subscribe to this website, please enter your email address here. We
          will send updates occasionally.
        </DialogContentText>
        <TextField
          autoFocus
          margin="dense"
          id="sales"
          label="Sales"
          type="text"
          fullWidth
          variant="standard"
          onChange={handleOnChange}
        />
        <TextField
          autoFocus
          margin="dense"
          id="productReminder"
          label="Product Reminder"
          type="text"
          fullWidth
          variant="standard"
          onChange={handleOnChange}
        />
        <TextField
          autoFocus
          margin="dense"
          id="productId"
          label="Product"
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

export default CreateSalesInfoDialog;
