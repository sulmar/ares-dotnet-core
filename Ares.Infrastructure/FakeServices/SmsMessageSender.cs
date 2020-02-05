using Ares.Domain.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Ares.Infrastructure.FakeServices
{
    public class SmsMessageSender : IMessageSender
    {
        private readonly ILogger<SmsMessageSender> logger;

        public SmsMessageSender(ILogger<SmsMessageSender> logger)
        {
            this.logger = logger;
        }

        public void Send(string message)
        {
            logger.LogInformation("Send sms");

            Console.WriteLine(message);
        }
    }
}
