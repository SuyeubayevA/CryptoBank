import * as React from "react";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import IconButton from "@mui/material/IconButton";
import DeleteIcon from "@mui/icons-material/Delete";
import Paper from "@mui/material/Paper";
import PropTypes from "prop-types";

const DiscountTable = ({ rows, deleteItem }) => (
  <TableContainer component={Paper}>
    <Table sx={{ minWidth: 650 }} aria-label="simple table">
      <TableHead>
        <TableRow>
          <TableCell>Amount of Product</TableCell>
          <TableCell align="right">Discount(%)</TableCell>
          <TableCell align="right">Warehouse Name</TableCell>
          <TableCell align="right">Product Name</TableCell>
          <TableCell align="right"></TableCell>
        </TableRow>
      </TableHead>
      <TableBody>
        {rows.map((row) => (
          <TableRow
            key={row.id}
            sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
          >
            <TableCell component="th" scope="row">
              {row.amount}
            </TableCell>
            <TableCell align="right">{row.discount}</TableCell>
            <TableCell align="right">{row.warehouseName}</TableCell>
            <TableCell align="right">{row.productName}</TableCell>
            <TableCell align="right">
              <IconButton
                aria-label="delete"
                onClick={() => {
                  deleteItem(row.id);
                }}
              >
                <DeleteIcon />
              </IconButton>
            </TableCell>
          </TableRow>
        ))}
      </TableBody>
    </Table>
  </TableContainer>
);

DiscountTable.propTypes = {
  rows: PropTypes.array.isRequired,
};

export default DiscountTable;
