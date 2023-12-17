using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using CS_NA_Sem_5.Abstracts;

namespace CS_NA_Sem_5.Services
{
    public class Client
    {
        private readonly string _name;
        //string adress;
        //int port;
        private readonly IMessageSourse _messageSourse;
        private IPEndPoint remoteEngPoint;

        public Client(string name, string adress, int port)
        {
            this._name = name;
            //this.adress = adress;
            //this.port = port;
            _messageSourse = new UdpMessageSource();
            remoteEngPoint = new IPEndPoint(IPAddress.Parse(adress), port);
        }

        UdpClient udpClientClient = new UdpClient();


        async Task ClientListener()
        {
            //IPEndPoint remoteEngPoint = new IPEndPoint(IPAddress.Parse(adress), 12345);
            
            while (true)
            {
                var messageRecived = _messageSourse.Recive(ref  remoteEngPoint);
                Console.WriteLine($"Получено сообщение от {messageRecived.NicknameFrom}");
                Console.WriteLine(messageRecived.Text );

                await Confirm(messageRecived, remoteEngPoint);
            }
        }


        async Task ClientSendler()
        {
            Register(remoteEngPoint);

            while (true)
            {
                try
                {
                    Console.WriteLine("Введите имя получателя");
                    var nameTo = Console.ReadLine();
                    Console.WriteLine("Введите сообщение");
                    var messageText = Console.ReadLine();

                    var message = new NetMessage()
                    {
                        command = Command.message,
                        NicknameFrom = _name,
                        NicknameTo = nameTo,
                        Text = messageText,
                    };
                    await _messageSourse.SendAsync(message, remoteEngPoint);
                    Console.WriteLine("Сообщение отправлено");
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
        }


        void Register(IPEndPoint remoteEngPoint)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 0);
            var message = new NetMessage()
            {
                NicknameFrom = _name,
                NicknameTo = null,
                Text = null,
                command = Command.register,
                EndPoint = ep, 
            };
            _messageSourse.SendAsync(message, remoteEngPoint);
        }

        async Task Confirm(NetMessage message,  IPEndPoint remoteEngPoint)
        {
            message.command = Command.confirm;
            await _messageSourse.SendAsync(message, remoteEngPoint );

        }


        public async Task Start()
        {
            await ClientListener();

            await ClientSendler();

        }
    }
}
