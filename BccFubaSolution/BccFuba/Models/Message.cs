﻿namespace BccFuba.Models;
public class Message
{
    public List<MailboxAddress> To { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }

    public IFormFileCollection? Attachments { get; set; }

    public Message(IEnumerable<string> to, string subject, string content, 
        IFormFileCollection? attachments = null)
    {
        To = new List<MailboxAddress>();

        To.AddRange(to.Select(email => new MailboxAddress(email, email)));
        Subject = subject;
        Content = content;
        Attachments = attachments;
    }
}