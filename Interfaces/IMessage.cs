using System;
using System.Collections.Generic;
using System.Text;

namespace ChatConsoleApp.Interfaces
{
    public interface IMessage
    {
        byte[] GetFormattedMessage();
    }
}
