import Button from '@material-ui/core/Button';
import MuiAlert, { AlertProps } from '@material-ui/lab/Alert';
import React from 'react';
import Snackbar from '@material-ui/core/Snackbar';
import styles from './Feedback.module.scss';
import TextareaAutosize from '@material-ui/core/TextareaAutosize';
import Typography from '@material-ui/core/Typography';
import { gql, useMutation } from '@apollo/client';

interface ISubmitFeedbackQueryRes {
  addFeedback: AddFeedback;
}

interface AddFeedback {
  id: string;
}

const SUBMIT_FEEDBACK = gql`
  mutation submitFeedback ($text: String!) {
    addFeedback (text: $text) {
      id
    }
  }
`;

function Alert(props: AlertProps) {
  return <MuiAlert elevation={6} variant="filled" {...props} />;
}

const Feedback = (): JSX.Element => {
  const [submitFeedback] = useMutation(SUBMIT_FEEDBACK, { onCompleted: (data: ISubmitFeedbackQueryRes) => { handleSubmitResponse(data) } });
  const [feedbackText, setFeedbackText] = React.useState('');
  const [open, setOpen] = React.useState(false);
  const [feedbackIdSubmit, setFeedbackIdSubmit] = React.useState('');

  const handleChangeFeedbackText = (e: React.ChangeEvent<HTMLTextAreaElement>) => {
    setFeedbackText(e.target.value);
  };

  const handleClickSubmit = () => {
    submitFeedback({ variables: { text: feedbackText } })
    setFeedbackText('');
  };

  const handleClose = (event?: React.SyntheticEvent, reason?: string) => {
    if (reason === 'clickaway') return;
    setOpen(false);
  };

  const handleSubmitResponse = (res: ISubmitFeedbackQueryRes) => {
    setOpen(true);
    setFeedbackIdSubmit(res.addFeedback.id);
  };

  return (
    <div className={styles['feedback']}>
      <div className={styles['feedback-title']}>
        <Typography variant="subtitle2">
          Please enter your feedback in the form below:
        </Typography>
      </div>
      <TextareaAutosize
        value={feedbackText}
        onChange={e => handleChangeFeedbackText(e)}
        rowsMin={5}
        placeholder="How can we improve this page? Appreciate your feedback." />
      <div className={styles['feedback-submitContainer']}>
        <Button variant="contained" color="secondary" className={styles['feedback-submitContainer-btn']} onClick={handleClickSubmit}>
          Submit
        </Button>
      </div>
      <Snackbar open={open} autoHideDuration={3000} onClose={handleClose}>
        <Alert onClose={handleClose} severity="success">
          {`Feedback received! (Id: ${feedbackIdSubmit})`}
        </Alert>
      </Snackbar>
    </div>
  );
};

export default Feedback;