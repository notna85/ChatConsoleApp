using System;
using System.Collections.Generic;
using System.Text;

namespace ChatConsoleApp.Logic
{
    public class UserInfo
    {
        public string Name { get; set; }
        public string Ip { get; set; }

        public UserInfo()
        {
        }
        public UserInfo(string name, string ip)
        {
            Name = name;
            Ip = ip;
        }
    }
}
