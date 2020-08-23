using Demo.Server.Core.BusinessEntity;
using Demo.Server.Core.GraphQl.Types;
using Demo.Server.Core.Service.Interface;
using GraphQL.Resolvers;
using GraphQL.Subscription;
using GraphQL.Types;
using System;

namespace Demo.Server.Core.GraphQl.Schema
{
    public class DemoSubscription: ObjectGraphType<object>
    {
        private readonly IFeedbackEventService _feedbackEventService;
        public DemoSubscription(IFeedbackEventService feedbackEventService)
        {
            _feedbackEventService = feedbackEventService;

            Name = "Subscription";
            AddField(new EventStreamFieldType
            {
                Name = "feedbackEvent",
                Type = typeof(FeedbackEventType),
                Resolver = new FuncFieldResolver<FeedbackEvent>(ResolveEvent),
                Subscriber = new EventStreamResolver<FeedbackEvent>(Subscribe)
            });
        }

        private FeedbackEvent ResolveEvent(ResolveFieldContext context)
        {
            return context.Source as FeedbackEvent;
        }

        private IObservable<FeedbackEvent> Subscribe(ResolveEventStreamContext context)
        {
            return _feedbackEventService.EventStream();
        }
    }
}
