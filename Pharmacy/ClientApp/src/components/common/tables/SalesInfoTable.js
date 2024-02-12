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

const SalesInfoTable = ({ rows, deleteItem }) => (
  <TableContainer component={Paper}>
    <Table sx={{ minWidth: 650 }} aria-label="simple table">
      <TableHead>
        <TableRow>
          <TableCell>Sold</TableCell>
          <TableCell align="right">Reminded products</TableCell>
          <TableCell align="right">Product</TableCell>
          <TableCell align="right"></TableCell>
        </TableRow>
      </TableHead>
      <TableBody>
        {rows.map((row) => (
          <TableRow
            key={row.sales}
            sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
          >
            <TableCell component="th" scope="row">
              {row.sales}
            </TableCell>
            <TableCell align="right">{row.productReminder}</TableCell>
            <TableCell align="right">{row.productId}</TableCell>
            <TableCell align="right">
              <IconButton
                aria-label="delete"
                onClick={() => {
                  deleteItem(row.productId);
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

SalesInfoTable.propTypes = {
  rows: PropTypes.array.isRequired,
};

export default SalesInfoTable;
