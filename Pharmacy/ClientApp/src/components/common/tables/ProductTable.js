import * as React from "react";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import IconButton from "@mui/material/IconButton";
import DeleteIcon from "@mui/icons-material/Delete";
import EditIcon from "@mui/icons-material/Edit";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import PropTypes from "prop-types";

const ProductTable = ({ rows, deleteItem, update }) => (
  <TableContainer component={Paper}>
    <Table sx={{ minWidth: 650 }} aria-label="simple table">
      <TableHead>
        <TableRow>
          <TableCell>Product Name</TableCell>
          <TableCell align="right">Description</TableCell>
          <TableCell align="right">Price</TableCell>
          <TableCell align="right">Product type (ID)</TableCell>
          <TableCell align="right"></TableCell>
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
              {row.name}
            </TableCell>
            <TableCell align="right">{row.description}</TableCell>
            <TableCell align="right">{row.price}</TableCell>
            <TableCell align="right">{row.productTypeId}</TableCell>
            <TableCell align="right">
              <IconButton
                aria-label="delete"
                onClick={() => {
                  deleteItem(row.name);
                }}
              >
                <DeleteIcon />
              </IconButton>
            </TableCell>
            <TableCell align="right">
              <IconButton
                aria-label="edit"
                onClick={() => {
                  update(row);
                }}
              >
                <EditIcon />
              </IconButton>
            </TableCell>
          </TableRow>
        ))}
      </TableBody>
    </Table>
  </TableContainer>
);

ProductTable.propTypes = {
  rows: PropTypes.array.isRequired,
};

export default ProductTable;
