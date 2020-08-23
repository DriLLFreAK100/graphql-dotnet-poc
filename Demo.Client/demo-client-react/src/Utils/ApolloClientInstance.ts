import {
  ApolloClient,
  InMemoryCache,
  HttpLink,
  split,
} from '@apollo/client';
import { getMainDefinition } from '@apollo/client/utilities'
import { WebSocketLink } from '@apollo/client/link/ws';
import { OperationDefinitionNode } from 'graphql';


const httpLink = new HttpLink({
  uri: "https://localhost:44391/graphql",
});

// Create a WebSocket link:
const wsLink = new WebSocketLink({
  uri: "wss://localhost:44391/graphql",
  options: {
    reconnect: true
  }
});

const link = split(
  // split based on operation type
  ({ query }) => {
    const definition = getMainDefinition(query);
    return definition.kind === 'OperationDefinition' && (definition as OperationDefinitionNode).operation === 'subscription';
  },
  wsLink,
  httpLink,
);

// Instantiate client
const ApolloClientInstance = new ApolloClient({
  link,
  cache: new InMemoryCache()
})

export default ApolloClientInstance;