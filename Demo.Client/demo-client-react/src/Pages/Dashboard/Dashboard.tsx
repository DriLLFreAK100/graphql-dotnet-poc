import FormControl from '@material-ui/core/FormControl';
import InputLabel from '@material-ui/core/InputLabel';
import MenuItem from '@material-ui/core/MenuItem';
import React from 'react';
import Select from '@material-ui/core/Select';
import styles from './Dashboard.module.scss';
import TopPerformingClients from './TopPerformingClients';
import TransactionSummary from './TransactionSummary';
import Typography from '@material-ui/core/Typography';
import { createStyles, makeStyles, Theme } from '@material-ui/core/styles';
import { gql, useLazyQuery, useQuery } from '@apollo/client';

export interface IDashboardInitQueryRes {
  availableTransactionYears: number[];
}

export interface IDashboardDataQueryRes {
  transactionSummaryByMonth: ITransactionSummaryByMonth[];
  topPerformingClient: ITopPerformingClient[];
}

export interface ITransactionSummaryByMonth {
  month: string;
  totalRevenue: number;
  totalProfit: number;
}

export interface ITopPerformingClient {
  id: number;
  clientName: string;
  totalRevenue: number;
  totalServiceCost: number;
  totalOtherOperationCost: number;
  totalProfit: number;
  totalProfitMargin: number;
}

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    formControl: {
      margin: theme.spacing(1),
      minWidth: 120,
      maxWidth: 150
    },
    selectEmpty: {
      marginTop: theme.spacing(2),
    },
    noRecords: {
      marginLeft: '0.5rem',
      marginTop: '1rem'
    }
  }),
);

const GET_DASHBOARD_INIT = gql`
  query dashboardInit {
    availableTransactionYears
  }
`;

const GET_DASHBOARD_DATA = gql`
  query dashboardData($year: Int!) {
    transactionSummaryByMonth(year: $year){
      month,
      totalRevenue,
      totalProfit,
    }
    topPerformingClient(count: 4, year: $year){
      id
      clientName
      totalRevenue
      totalServiceCost
      totalOtherOperationCost
      totalProfit
      totalProfitMargin
    }
  }
`;

const Dashboard = (): JSX.Element => {
  const classes = useStyles();
  const [year, setYear] = React.useState<number>(0);
  const { data, loading, error } = useQuery<IDashboardInitQueryRes>(GET_DASHBOARD_INIT);
  const [getData, { data: queryData }] = useLazyQuery<IDashboardDataQueryRes>(GET_DASHBOARD_DATA);

  const handleChange = (event: React.ChangeEvent<{ value: unknown }>) => {
    setYear(event.target.value as number);
    getData({ variables: { year: event.target.value } });
  };

  const renderDataDisplay = (): JSX.Element[] => {
    const elements = [];

    if (queryData) {
      if (queryData.transactionSummaryByMonth && queryData.transactionSummaryByMonth.length > 0) {
        elements.push(<TransactionSummary data={queryData.transactionSummaryByMonth} />);
      }
      if (queryData.topPerformingClient && queryData.topPerformingClient.length > 0) {
        elements.push(<TopPerformingClients data={queryData.topPerformingClient} />);
      }
    }

    return elements;
  };

  const renderNoRecord = () => {
    return (
      <Typography variant="subtitle2" className={classes.noRecords}>
        No Records
      </Typography>
    )
  }

  if (loading) return <p>LOADING...</p>
  if (error) return <p>ERROR</p>;
  if (!data) return <p>No Records</p>;

  return (
    <div className={styles['dashboard']}>
      <FormControl className={classes.formControl}>
        <InputLabel id="demo-simple-select-label">Year</InputLabel>
        <Select
          labelId="dashboard-year-select"
          id="dashboard-year-select-id"
          value={year}
          onChange={handleChange}
        >
          {data.availableTransactionYears.map((year, index) => {
            return <MenuItem key={index} value={year}>{year}</MenuItem>;
          })}
        </Select>
      </FormControl>
      {!queryData && renderNoRecord()}
      {renderDataDisplay()}
    </div>
  );
};

export default Dashboard;