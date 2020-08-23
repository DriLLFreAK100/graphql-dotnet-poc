using Demo.Server.Core.BusinessEntity;
using Demo.Server.Core.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Server.Core.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly List<Feedback> _feedbackMocks;

        public FeedbackRepository()
        {
            _feedbackMocks = new List<Feedback>();
        }

        public Feedback Add(Feedback feedback)
        {
            _feedbackMocks.Add(feedback);
            return feedback;
        }
    }
}
