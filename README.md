# GraphQL Dotnet Proof-of-Concept (PoC)
A proof of concept on using GraphQL in .NET Core. This repository consists of a Frontend (Reactjs) and a Backend (.NET Core with GraphQL.NET)

The project showcases how Query, Mutation and Subscription can be carried out in GraphQL. 

## Frontend
It is a Reactjs project using the [Apollo Client](https://www.apollographql.com/docs/react/) package.

To quickly start up and work with the project, 
1. Navigate into /Demo.Client/demo-client-react
2. Run NPM command "npm install", followed by "npm run start"

## Backend
It is a .NET Core WebAPI project running on .NET Core 2.2, using [GraphQL.NET](https://graphql-dotnet.github.io/) package for setting up the GraphQL Server.

To quickly start up and work with the project, 
1. Navigate into /Demo.Server
2. Open up the solution file (.sln) using Visual Studio
3. Hit the Debug button in Visual Studio IDE, or simply press F5

### Notes
* For Subscription to work, you need to have a machine/server that supports WebSocket to host the Backend portion (GraphQL.NET)
  * E.g. Windows 8 and above is required for local Windows machine.
  
