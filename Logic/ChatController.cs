using ChatConsoleApp.DAL;
using ChatConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ChatConsoleApp.Logic
{
    class ChatController
    {
        ICommunication comHandler;
        public ChatController(ICommunication com)
        {
            comHandler = com;
        }

        public void PrepareToSend(string messageString, string sender, string senderNick, string receiver, string receiverNick, string type)
        {
            IMessage message = CreateMessage(messageString, sender, senderNick, receiver, receiverNick, type);
            Send(message.GetFormattedMessage());
        }
        public IMessage CreateMessage(string messageString, string sender, string senderNick, string receiver, string receiverNick, string type)
        {
            IMessage message = MessageFactory.CreateMessageObject(messageString, sender, senderNick, receiver, receiverNick, type);
            return message;
        }
        public void Connect(string ip, int port)
        {
            IConnectable connectHandler = (IConnectable)comHandler;
            connectHandler.Connect(ip, port);
        }
        public void Send(byte[] bytesToSend)
        {
            comHandler.Send(bytesToSend);
        }
        public string Update(string type)
        {
            string returnedString = comHandler.Receive() + " "; //An extra space to prevent going out of bounds when removing characters in the method below

            switch (type)
            {
                case "plain":
                    {
                        break;
                    }
                case "xml":
                    {
                        if(returnedString.Length <= 1)
                        {
                            break;
                        }

                        XmlSerializer ser = new XmlSerializer(typeof(XmlMessage), new XmlRootAttribute("SocketMessage"));
                        XmlMessage result;

                        //Remove any characters after the xml string
                        returnedString = returnedString.Remove(returnedString.LastIndexOf(">") + 1); //Here's the reason for an extra space above, in case there isn't anything else after the LastIndexOf character
                        
                        //Remove any characters before the xml string
                        int start = returnedString.IndexOf("<");
                        returnedString = returnedString.Substring(start);

                        using (TextReader reader = new StringReader(returnedString))
                        {
                            result = (XmlMessage)ser.Deserialize(reader);
                        }

                        returnedString = result.SenderHostName + " to " + result.ReceiverHostName + ": " + result.ChatMessage;
                        break;
                    }
            }
            return returnedString;
        }
    }
}
