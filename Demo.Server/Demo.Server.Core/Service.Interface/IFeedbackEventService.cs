using Demo.Server.Core.BusinessEntity;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Demo.Server.Core.Service.Interface
{
    public interface IFeedbackEventService
    {
        ConcurrentStack<FeedbackEvent> AllEvents { get; }
        void AddError(Exception exception);
        FeedbackEvent AddEvent(FeedbackEvent feedbackEvent);
        IObservable<FeedbackEvent> EventStream();
    }
}
