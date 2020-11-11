using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using ChatConsoleApp.Interfaces;

namespace ChatConsoleApp.Logic
{
    class XmlHandler
    {
        public static byte[] SerializeXml(IMessage msg)
        {
            XmlSerializer ser = new XmlSerializer(msg.GetType(), new XmlRootAttribute("SocketMessage"));
            byte[] bufferStream = new byte[1024];
            MemoryStream s = new MemoryStream(bufferStream);
            ser.Serialize(s, msg);
            return Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(bufferStream).Replace("\0", ""));
        }
    }
}
