using Demo.Server.Core.BusinessEntity;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Server.Core.GraphQl.Types
{
    public class FeedbackType: ObjectGraphType<Feedback>
    {
        public FeedbackType()
        {
            Field(x => x.Id).Description("Feedback ID");
            Field(x => x.Text).Description("Feedback Content");
        }
    }
}
