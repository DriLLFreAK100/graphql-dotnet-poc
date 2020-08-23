using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Server.Core.BusinessEntity
{
    public class Feedback
    {
        public string Id { get; set; }
        public string Text { get; set; }

        public Feedback(string id, string text)
        {
            Id = id;
            Text = text;
        }
    }
}
