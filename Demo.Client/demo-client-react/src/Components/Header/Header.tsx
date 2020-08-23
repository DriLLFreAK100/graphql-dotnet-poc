import AppBar from '@material-ui/core/AppBar';
import React from 'react';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import { Link } from 'react-router-dom';
import { makeStyles } from '@material-ui/core/styles';
import { useLocation } from 'react-router-dom';

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
  },
  menuButton: {
    marginRight: theme.spacing(2),
  },
  title: {
    flexGrow: 4,
  },
  navArea: {
    display: 'flex',
    flexGrow: 1,
    justifyContent: 'flex-end'
  },
  navItem: {
    color: 'white !important',
    marginRight: theme.spacing(2),
    '&.active': {
      borderBottom: 'white 1px solid',
      justifyContent: 'center'
    }
  }
}));

export default function ButtonAppBar() {
  const classes = useStyles();
  const location = useLocation();

  const isActive = (expectedPath: string): string => {
    return location.pathname === expectedPath ? 'active' : '';
  };

  return (
    <div className={classes.root}>
      <AppBar position="static">
        <Toolbar>
          <Typography variant="h6" className={classes.title}>
            Demo App
          </Typography>
          <div className={classes.navArea}>
            <Typography variant="subtitle1" className={`${classes.navItem} ${isActive('/')}`}>
              <Link to="/">Dashboard</Link>
            </Typography>
            <Typography variant="subtitle1" className={`${classes.navItem} ${isActive('/feedback')}`}>
              <Link to="/feedback">Feedback</Link>
            </Typography>
            <Typography variant="subtitle1" className={`${classes.navItem} ${isActive('/admin')}`}>
              <Link to="/admin">Admin</Link>
            </Typography>
          </div>
        </Toolbar>
      </AppBar>
    </div>
  );
}