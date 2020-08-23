import Admin from './Pages/Admin';
import ApolloClientInstance from './Utils/ApolloClientInstance';
import Dashboard from './Pages/Dashboard';
import Feedback from './Pages/Feedback';
import Header from './Components/Header';
import React from 'react';
import ReactDOM from 'react-dom';
import { ApolloProvider } from '@apollo/client';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import './index.scss';

ReactDOM.render(
  <ApolloProvider client={ApolloClientInstance}>
    <Router>
      <Header />
      <div className="pageContainer">
        <Switch>
          <Route exact path="/">
            <Dashboard />
          </Route>
          <Route path="/feedback">
            <Feedback />
          </Route>
          <Route path="/admin">
            <Admin />
          </Route>
        </Switch>
      </div>
    </Router>
  </ApolloProvider>,
  document.getElementById('root')
);
