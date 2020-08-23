import React from 'react';
import Typography from '@material-ui/core/Typography';
import {
  CartesianGrid,
  Legend,
  Line,
  LineChart,
  Tooltip,
  XAxis,
  YAxis
} from 'recharts';
import { ITransactionSummaryByMonth } from './Dashboard';
import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles({
  title: {
    marginTop: '0.5rem',
    marginBottom: '0.5rem',
    width: '100%'
  }
});

interface ITransactionSummary {
  data: ITransactionSummaryByMonth[];
}

const TransactionSummary = ({
  data,
}: ITransactionSummary): JSX.Element => {
  const classes = useStyles();
  const ref = React.useRef<HTMLDivElement>(null);
  const [width, setWidth] = React.useState(0);

  React.useLayoutEffect(() => {
    if (ref && ref.current)
      setWidth(ref.current.getBoundingClientRect().width);
  }, []);

  return (
    <div ref={ref}>
      <Typography variant="subtitle1" className={classes.title}>
        Summary:
      </Typography>
      <LineChart width={width} height={200} data={data}
        margin={{ top: 5, right: 30, left: 20, bottom: 5 }}>
        <XAxis dataKey="month" />
        <YAxis />
        <CartesianGrid strokeDasharray="3 3" />
        <Tooltip />
        <Legend />
        <Line type="monotone" name="Revenue" dataKey="totalRevenue" stroke="#8884d8" activeDot={{ r: 8 }} />
        <Line type="monotone" name="Profit" dataKey="totalProfit" stroke="#82ca9d" activeDot={{ r: 8 }} />
      </LineChart>
    </div>
  )
};

export default TransactionSummary;