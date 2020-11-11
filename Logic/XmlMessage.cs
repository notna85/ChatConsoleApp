using ChatConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ChatConsoleApp.Logic
{
    public class XmlMessage : SimpleMessage
    {
        public XmlMessage()
        {
        }
        //Constructor used for Camilla's server
        public XmlMessage(string message, string senderAddress, string senderNick, string receiverAddress, string receiverNick) : base(message, senderAddress, senderNick, receiverAddress, receiverNick)
        {
        }
        //Constructor used for our server
        public XmlMessage(string message, string senderAddress, string senderNick, string receiverAddress, string receiverNick, string nick) : base(message, senderAddress, senderNick, receiverAddress, receiverNick, nick)
        {
        }

        public override byte[] GetFormattedMessage()
        {
            return XmlHandler.SerializeXml(this);
        }
    }
}
