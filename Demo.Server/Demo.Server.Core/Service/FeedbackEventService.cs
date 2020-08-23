using Demo.Server.Core.BusinessEntity;
using Demo.Server.Core.Service.Interface;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;

namespace Demo.Server.Core.Service
{
    public class FeedbackEventService : IFeedbackEventService
    {
        private readonly ISubject<FeedbackEvent> _eventStream = new ReplaySubject<FeedbackEvent>(1);

        public FeedbackEventService()
        {
            AllEvents = new ConcurrentStack<FeedbackEvent>();
        }

        public ConcurrentStack<FeedbackEvent> AllEvents { get; }

        public void AddError(Exception exception)
        {
            _eventStream.OnError(exception);
        }

        public FeedbackEvent AddEvent(FeedbackEvent feedbackEvent)
        {
            AllEvents.Push(feedbackEvent);
            _eventStream.OnNext(feedbackEvent);
            return feedbackEvent;
        }

        public IObservable<FeedbackEvent> EventStream()
        {
            return _eventStream.AsObservable();
        }
    }
}
