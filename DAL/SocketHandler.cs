using ChatConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ChatConsoleApp.DAL
{
    class SocketHandler : IConnectable, ICommunication
    {
        private Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private byte[] bytesToReceive = new byte[1024];

        public void Connect(string ip, int port)
        {
            while(socket.Connected == false)
            {
                try
                {
                    socket.Connect(ip, port);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Failed to Connect.");
                }
                Thread.Sleep(500);
            }
        }

        public string Receive()
        {
            string stringToReturn = "";
            if(socket.Available > 0)
            {
                socket.Receive(bytesToReceive);
                stringToReturn = Encoding.UTF8.GetString(bytesToReceive);
            }
            return stringToReturn;
        }

        public void Send(byte[] bytesToSend)
        {
            if(socket.Connected)
            {
                socket.Send(bytesToSend);
                Thread.Sleep(500);
            }
            else
            {
                Console.WriteLine("Connection lost...");
                Console.ReadKey();
            }
        }
    }
}
