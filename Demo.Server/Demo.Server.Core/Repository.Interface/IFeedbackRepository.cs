using Demo.Server.Core.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Server.Core.Repository.Interface
{
    public interface IFeedbackRepository
    {
        Feedback Add(Feedback feedback);
    }
}
