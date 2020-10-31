import Paper from '@material-ui/core/Paper';
import React, { useState } from 'react';
import styles from './Admin.module.scss';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Typography from '@material-ui/core/Typography';
import { gql, OnSubscriptionDataOptions, useSubscription } from '@apollo/client';
import { makeStyles } from '@material-ui/core/styles';
import { useSnackbar } from 'notistack';

interface IFeedbackSubscriptionQueryRes {
  feedbackEvent: IFeedbackEvent;
}

interface IFeedbackEvent {
  feedbackId: string;
  text: string;
  createdDateTime: string;
}

const FEEDBACK_SUBSCRIPTION = gql`
  subscription onFeedbackAdded {
    feedbackEvent {
      feedbackId
      text
      createdDateTime
    }
  }
`;

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

const Admin = (): JSX.Element => {
  const classes = useStyles();
  const { enqueueSnackbar } = useSnackbar();
  useSubscription(FEEDBACK_SUBSCRIPTION, { onSubscriptionData: (data) => handleSubscriptionData(data) });
  const [messages, setMessages] = useState<IFeedbackEvent[]>([]);

  const handleSubscriptionData = (data: OnSubscriptionDataOptions<IFeedbackSubscriptionQueryRes>) => {
    const feedback = data.subscriptionData.data?.feedbackEvent;
    enqueueSnackbar(`${feedback?.createdDateTime} - ${feedback?.text} (${feedback?.feedbackId})`, { variant: "info" });
    setMessages([...messages, ...[feedback as IFeedbackEvent]]);
  };

  return (
    <div className={styles['admin']}>
      <Typography variant="subtitle1" className={classes.title}>
        Admin waiting for <strong>&nbsp;real-time&nbsp;</strong>feedback...
      </Typography>

      <hr />

      <Typography variant="subtitle1" className={classes.title}>
        Feedbacks received:
      </Typography>

      {messages.length > 0 && <TableContainer component={Paper}>
        <Table className={classes.table}>
          <TableHead>
            <TableRow>
              <TableCell>Feedback ID</TableCell>
              <TableCell align="right">Text</TableCell>
              <TableCell align="right">Created Date Time</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {messages.map((row) => (
              <TableRow key={row.feedbackId}>
                <TableCell component="th" scope="row">{row.feedbackId}</TableCell>
                <TableCell align="right">{row.text}</TableCell>
                <TableCell align="right">{row.createdDateTime}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>}
    </div>
  );
};

export default Admin;
