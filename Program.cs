using ChatConsoleApp.DAL;
using ChatConsoleApp.Interfaces;
using ChatConsoleApp.Logic;
using System;

namespace ChatConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ChatController ch = new ChatController(new SocketHandler());

            string type = "xml";
            string messageToSend = "Hehu";
            string sender = "172.16.2.51";
            string senderNick = "Lingon";
            string receiver = "172.16.2.51";
            string receiverNick = "Lingon2";
            string serverIp = "172.16.2.30";
            int port = 0;

            Console.WriteLine("Connecting to server...");

            switch(type)
            {
                case "plain":
                    {
                        port = 50001;
                        break;
                    }
                case "xml":
                    {
                        port = 50002;
                        break;
                    }
                case "symmetry":
                    {
                        port = 50003;
                        break;
                    }
            }
            ch.Connect(serverIp, port);
            
            Console.WriteLine("Connected!");

            while(messageToSend != "exit")
            {
                Console.WriteLine(ch.Update(type));
                Console.Write("\n\nWrite your message: ");
                messageToSend = Console.ReadLine();
                if(messageToSend != "")
                {
                    ch.PrepareToSend(messageToSend, sender, senderNick, receiver, receiverNick, type);
                }
            }

            Console.ReadKey();
        }
    }
}
