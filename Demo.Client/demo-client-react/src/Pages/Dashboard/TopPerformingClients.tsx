import Paper from '@material-ui/core/Paper';
import React from 'react';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Typography from '@material-ui/core/Typography';
import { ITopPerformingClient } from './Dashboard';
import { makeStyles } from '@material-ui/core/styles';

interface ITopPerformingClients {
  data: ITopPerformingClient[];
}

const useStyles = makeStyles({
  table: {
    minWidth: 650,
  },
  title: {
    marginTop: '0.5rem',
    marginBottom: '0.5rem',
    width: '100%'
  }
});

const TopPerformingClients = ({
  data
}: ITopPerformingClients): JSX.Element => {
  const classes = useStyles();

  return (
    <div>
      <Typography variant="subtitle1" className={classes.title}>
        Top Performing Clients:
      </Typography>
      <TableContainer component={Paper}>
        <Table className={classes.table}>
          <TableHead>
            <TableRow>
              <TableCell>Client ID</TableCell>
              <TableCell align="right">Client Name</TableCell>
              <TableCell align="right">Revenue</TableCell>
              <TableCell align="right">Service Cost</TableCell>
              <TableCell align="right">Other Operation Cost</TableCell>
              <TableCell align="right">Profit</TableCell>
              <TableCell align="right">Profit Margin</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {data.map((row) => (
              <TableRow key={row.id}>
                <TableCell component="th" scope="row">{row.id}</TableCell>
                <TableCell align="right">{row.clientName}</TableCell>
                <TableCell align="right">{row.totalRevenue}</TableCell>
                <TableCell align="right">{row.totalServiceCost}</TableCell>
                <TableCell align="right">{row.totalOtherOperationCost}</TableCell>
                <TableCell align="right">{row.totalProfit}</TableCell>
                <TableCell align="right">{row.totalProfitMargin}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </div>
  );
};

export default TopPerformingClients;