using System.Collections.Generic;

// DEPENDENCY INVERSION PRINCIPLE
// High-level modules should not depend on low-level modules
// Both should depend on abstractions
// Abstractions should not depend on details
// Details should depend on abstractions

namespace WRONG_WAY
{
    // Low-level classes
    public class Email
    {
        public string ToAddress { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public void SendEmail()
        {
            //Send email
        }
    }

    public class SMS
    {
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public void SendSMS()
        {
            //Send sms
        }
    }

    // High-level class
    // Dependency on lower-level classes
    // Depending on concrete implementation of both Email and SMS
    public class Notification
    {
        private Email _email;
        private SMS _sms;
        public Notification()
        {
            _email = new Email();
            _sms = new SMS();
        }

        public void Send()
        {
            _email.SendEmail();
            _sms.SendSMS();
        }
    }
}

namespace SOLID_Principle
{
    // Both high-level and low-level classes should depend on abstractions
    public interface IMessage
    {
        void SendMessage();
    }
    
    public class Email : IMessage
    {
        public string ToAddress { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public void SendMessage()
        {
            //Send email
        }
    }

    public class Sms : IMessage
    {
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public void SendMessage()
        {
            //Send sms
        }
    }
    
    // Notification depend on abtraction rather than its concrete implementations
    public class Notification
    {
        private ICollection<IMessage> _messages;

        public Notification(ICollection<IMessage> messages)
        {
            this._messages = messages;
        }
        public void Send()
        {
            foreach(var message in _messages)
            {
                message.SendMessage();
            }
        }
    }
}