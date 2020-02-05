using System;
using System.Collections.Generic;
using System.Text;

namespace Ares.Domain.Services
{
    public interface IMessageSender
    {
        void Send(string message);
    }
}
