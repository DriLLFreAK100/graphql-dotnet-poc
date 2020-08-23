using GraphQL;

namespace Demo.Server.Core.GraphQl.Schema
{
    public class DemoSchema: GraphQL.Types.Schema
    {
        public DemoSchema(DemoQuery query, DemoMutation mutation, DemoSubscription subscription, IDependencyResolver resolver)
        {
            Query = query;
            Mutation = mutation;
            Subscription = subscription;
            DependencyResolver = resolver;
        }
    }
}
