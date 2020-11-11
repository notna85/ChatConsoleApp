using System;
using System.Collections.Generic;
using System.Text;

namespace ChatConsoleApp.Interfaces
{
    interface IConnectable
    {
        void Connect(string ip, int port);
    }
}
