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
    internal class UdpMessageSource : IMessageSourse
    {
        private readonly UdpClient _udpClient;
        public UdpMessageSource()
        {
            _udpClient = new UdpClient(12345);
        }

        public NetMessage Recive(ref IPEndPoint ep)
        {
            byte[] data =  _udpClient.Receive(ref ep);
            string str = Encoding.UTF8.GetString(data);
            return NetMessage.DeserializeFromJson(str) ?? new NetMessage();
        }

        public async Task SendAsync(NetMessage message, IPEndPoint ep)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message.SerialazeMessageToJson());
            await _udpClient.SendAsync(buffer, buffer.Length, ep);
        }
    }
}
