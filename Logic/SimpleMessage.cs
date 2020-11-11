using ChatConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ChatConsoleApp.Logic
{
    public class SimpleMessage : IMessage
    {
        //Properties used for our server
        public string NickName { get; set; }
        public string SenderHostName { get; set; }
        public string SenderIpAddress { get; set; }
        public string ReceiverHostName { get; set; }
        public string ReceiverIpAddress { get; set; }
        public string ChatMessage { get; set; }

        //Properties used for Camilla's server
        public UserInfo To { get; set; }
        public UserInfo From { get; set; }
        public MessageBody Mb { get; set; }

        public SimpleMessage()
        {
        }
        //Constructor used for Camilla's server
        public SimpleMessage(string message, string senderAddress, string senderNick, string receiverAddress, string receiverNick)
        {
            From = new UserInfo(senderNick, senderAddress);
            To = new UserInfo(receiverNick, receiverAddress);
            Mb = new MessageBody(message);
        }
        //Constructor used for our server
        public SimpleMessage(string message, string senderAddress, string senderNick, string receiverAddress, string receiverNick, string nick)
        {
            NickName = nick;
            SenderHostName = senderNick;
            SenderIpAddress = senderAddress;
            ReceiverHostName = receiverNick;
            ReceiverIpAddress = receiverAddress;
            ChatMessage = message + "{END}";
        }

        virtual public byte[] GetFormattedMessage()
        {
            //string finalString = From.Name + ":" + From.Ip + ":" + To.Name + ":" + To.Ip + ":" + Mb.Body + "\r\n"; //Format for Camilla's server
            string finalString = "Anton:" + From.Name + ":" + From.Ip + ":" + To.Name + ":" + To.Ip + ":" + Mb.Body; //Format for our server

            return Encoding.UTF8.GetBytes(finalString);
        }
    }
}
