using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CS_NA_Sem_5
{
    /*public class UDPServer
    {
        //class Server
        //{
            Dictionary<String, IPEndPoint> clients = new Dictionary<string, IPEndPoint>();
            UdpClient udpClient;

            void Register(NetMessage message, IPEndPoint fromep)
            {
                Console.WriteLine("Message Register, name = " + message.NicknameFrom);
                clients.Add(message.NicknameFrom, fromep);


                using (var ctx = new ChatContext())
                {
                    if (ctx.Users.FirstOrDefault(x => x.Fullname == message.NicknameFrom) != null) return;

                    ctx.Add(new User { Fullname = message.NicknameFrom });

                    ctx.SaveChanges();
                }
            }

            void ConfirmMessageReceived(int? id)
            {
                Console.WriteLine("Message confirmation id=" + id);

                using (var ctx = new ChatContext())
                {
                var msg = ctx.Messages.FirstOrDefault(x => x.MessageID == id);
                //var msg = ctx.Messages.FirstOrDefault(x => x.id == id);

                if (msg != null)
                    {
                        msg.IsSend = true;
                        ctx.SaveChanges();
                    }
                }
            }

            void RelyMessage(NetMessage message)
            {
                int? id = null;
                if (clients.TryGetValue(message.NicknameTo, out IPEndPoint ep))
                {
                    using (var ctx = new ChatContext())
                    {
                        var fromUser = ctx.Users.First(x => x.Fullname == message.NicknameFrom);
                        var toUser = ctx.Users.First(x => x.Fullname == message.NicknameTo);
                        var msg = new Message() { UserFrom = fromUser, UserTo = toUser, IsSend = false, Text = message.Text };
                        ctx.Messages.Add(msg);

                        ctx.SaveChanges();

                        id = msg.MessageId;
                    }


                    var forwardMessageJson = new NetMessage()
                    {
                        Id = id,
                        command = Command.message,
                        NicknameTo = message.NicknameTo,
                        NicknameFrom = message.NicknameFrom,
                        Text = message.Text
                    }.SerializeMessageToJson();

                    byte[] forwardBytes = Encoding.ASCII.GetBytes(forwardMessageJson);

                    udpClient.Send(forwardBytes, forwardBytes.Length, ep);
                    Console.WriteLine($"Message Relied, from = {message.NicknameFrom} to = {message.NicknameTo}");
                }
                else
                {
                    Console.WriteLine("Пользователь не найден.");
                }
            }

            void ProcessMessage(NetMessage message, IPEndPoint fromep)
            {
                Console.WriteLine($"Получено сообщение от {message.NicknameFrom} для {message.NicknameTo} с командой {message.command}:");
                Console.WriteLine(message.Text);


                if (message.command == Command.register)
                {
                    Register(message, new IPEndPoint(fromep.Address, fromep.Port));

                }
                if (message.command == Command.confirm)
                {
                    Console.WriteLine("Confirmation receiver");
                    ConfirmMessageReceived(message.Id);
                }
                if (message.command == Command.message)
                {
                    RelyMessage(message);
                }
            }


            public void Work()
            {

                IPEndPoint remoteEndPoint;

                udpClient = new UdpClient(12345);
                remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

                Console.WriteLine("UDP Клиент ожидает сообщений...");

                while (true)
                {
                    byte[] receiveBytes = udpClient.Receive(ref remoteEndPoint);
                    string receivedData = Encoding.ASCII.GetString(receiveBytes);

                    Console.WriteLine(receivedData);

                    try
                    {
                    var message = NetMessage.DeserializeFromJson(receivedData);


                    ProcessMessage(message, remoteEndPoint);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка при обработке сообщения: " + ex.Message);
                    }
                }

            }
        //}
    }*/
}
