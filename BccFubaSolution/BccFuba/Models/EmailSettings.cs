﻿namespace BccFuba.Models
{
    public class EmailSettings
    {
        public string AdminToEmail { get; set; }
        public string FromName { get; set; }
        public string FromEmail { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool EnableSsl { get; set; }
    }
}
