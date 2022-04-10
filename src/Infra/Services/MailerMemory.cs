using System;
using System.Collections.Generic;
using Domain.Contracts;

namespace Infra.Services
{
    public class MailerMemory : IMailer
    {
        public readonly IList<string> messages;

        public MailerMemory()
        {
            messages = new List<string>();
        }

        public void Send(string to, string message)
        {
            messages.Add(message);
            Console.WriteLine($"Sending email to {to} with message {message}");
        }
    }
}