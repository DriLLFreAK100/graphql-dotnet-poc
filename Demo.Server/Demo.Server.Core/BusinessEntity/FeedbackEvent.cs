using System;

namespace Demo.Server.Core.BusinessEntity
{
    public class FeedbackEvent
    {
        public string Id { get; set; }
        public string FeedbackId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public FeedbackEvent(string id, string feedbackId, string text, DateTime createdDateTime)
        {
            Id = id;
            FeedbackId = feedbackId;
            Text = text;
            CreatedDateTime = createdDateTime;
        }
    }
}
