using Demo.Server.Core.BusinessEntity.Input;
using GraphQL.Types;

namespace Demo.Server.Core.GraphQl.Types
{
    public class FeedbackInputType: InputObjectGraphType<FeedbackInput>
    {
        public FeedbackInputType()
        {
            Name = "FeedbackInput";
            Field<NonNullGraphType<StringGraphType>>("Text", description: "Feedback content to be submitted");
        }
    }
}
