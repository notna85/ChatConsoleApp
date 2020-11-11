using System;
using System.Collections.Generic;
using System.Text;

namespace ChatConsoleApp.Interfaces
{
    interface ICommunication
    {
        void Send(byte[] bytes);
        string Receive();
    }
}
