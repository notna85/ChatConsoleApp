using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ChatConsoleApp.Logic
{
    public class MessageBody
    {
        public string Body { get; set; }

        public MessageBody()
        {
        }
        public MessageBody(string message)
        {
            Body = message;
        }
    }
}
