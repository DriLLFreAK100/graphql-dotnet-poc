using Demo.Server.Core.BusinessEntity;
using Demo.Server.Core.GraphQl.Types;
using Demo.Server.Core.Service.Interface;
using GraphQL.Types;
using System;

namespace Demo.Server.Core.GraphQl.Schema
{
    public class DemoMutation : ObjectGraphType<object>
    {
        public DemoMutation(IFeedbackService feedbackService)
        {
            Name = "Mutation";
            Field<FeedbackType>(
                "addFeedback",
                description: "Submit feedback to the application",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "text" }),
                resolve: context =>
                {
                    var feedbackInput = context.GetArgument<string>("text");
                    return feedbackService.AddFeedback(new Feedback(Guid.NewGuid().ToString(), feedbackInput));
                }
            );
        }
    }
}
