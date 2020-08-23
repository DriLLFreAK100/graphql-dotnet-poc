import React from 'react';
import MoodIcon from '@material-ui/icons/Mood';
import styles from './Admin.module.scss';
import { gql, useSubscription } from '@apollo/client';

const FEEDBACK_SUBSCRIPTION = gql`
  subscription onFeedbackAdded {
    feedbackEvent {
      feedbackId
      text
      createdDateTime
    }
  }
`;

const Admin = () => {
  const { data } = useSubscription(FEEDBACK_SUBSCRIPTION);
  console.log(data);

  return (
    <div className={styles['admin']}>
      Admin waiting for <strong>&nbsp;real-time&nbsp;</strong>feedback
      &nbsp;<MoodIcon />
    </div>
  );
};

export default Admin;
