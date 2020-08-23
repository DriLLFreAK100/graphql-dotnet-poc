using Demo.Server.Core.BusinessEntity;
using Demo.Server.Core.Repository.Interface;
using Demo.Server.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Server.Core.Service
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _repo;
        private readonly IFeedbackEventService _eventService;

        public FeedbackService(IFeedbackRepository repo, IFeedbackEventService feedbackEventService)
        {
            _repo = repo;
            _eventService = feedbackEventService;
        }

        public Feedback AddFeedback(Feedback feedback)
        {
            var feedbackAdded = _repo.Add(feedback);
            _eventService.AddEvent(new FeedbackEvent(Guid.NewGuid().ToString(), feedbackAdded.Id, feedback.Text, DateTime.Now));
            return feedbackAdded;
        }
    }
}
