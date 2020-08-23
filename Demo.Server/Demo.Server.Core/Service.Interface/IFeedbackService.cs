using Demo.Server.Core.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Server.Core.Service.Interface
{
    public interface IFeedbackService
    {
        Feedback AddFeedback(Feedback feedback);
    }
}
