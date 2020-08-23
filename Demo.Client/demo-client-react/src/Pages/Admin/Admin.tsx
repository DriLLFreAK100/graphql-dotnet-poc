import React from 'react';
import MoodIcon from '@material-ui/icons/Mood';
import styles from './Admin.module.scss';
import { gql, useSubscription, OnSubscriptionDataOptions } from '@apollo/client';
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

const Admin = (): JSX.Element => {
  useSubscription(FEEDBACK_SUBSCRIPTION, { onSubscriptionData: (data) => handleSubscriptionData(data) });
  const { enqueueSnackbar } = useSnackbar();

  const handleSubscriptionData = (data: OnSubscriptionDataOptions<IFeedbackSubscriptionQueryRes>) => {
    const feedback = data.subscriptionData.data?.feedbackEvent;
    enqueueSnackbar(`${feedback?.createdDateTime} - ${feedback?.text} (${feedback?.feedbackId})`, { variant: "info" })
  };

  return (
    <div className={styles['admin']}>
      Admin waiting for <strong>&nbsp;real-time&nbsp;</strong>feedback
      &nbsp;<MoodIcon />
    </div>
  );
};

export default Admin;
