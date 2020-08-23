using Demo.Server.Core.BusinessEntity;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Server.Core.GraphQl.Types
{
    public class FeedbackEventType: ObjectGraphType<FeedbackEvent>
    {
        public FeedbackEventType()
        {
            Field(x => x.Id).Description("Event ID");
            Field(x => x.FeedbackId).Description("Feedback ID");
            Field(x => x.Text).Description("Feedback Text Content");
            Field(x => x.CreatedDateTime).Description("Event created datetime");
        }
    }
}
