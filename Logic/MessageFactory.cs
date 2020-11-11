using System;
using System.Collections.Generic;
using System.Text;
using ChatConsoleApp.Interfaces;

namespace ChatConsoleApp.Logic
{
    class MessageFactory
    {
        public static IMessage CreateMessageObject(string messageString, string sender, string senderNick, string receiver, string receiverNick, string type)
        {
            IMessage message = new SimpleMessage();
            switch(type)
            {
                case "plain":
                    {
                        message = new SimpleMessage(messageString, sender, senderNick, receiver, receiverNick);
                        break;
                    }
                case "xml":
                    {
                        string nick = "Anton";
                        message = new XmlMessage(messageString, sender, senderNick, receiver, receiverNick, nick);
                        break;
                    }
            }
            return message;
        }
    }
}
