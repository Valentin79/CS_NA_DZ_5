using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace CS_NA_Sem_5
{
    /*internal class OldUdpServer
    {
        public async Task ServerUDP() 
        {
            UdpClient udpClient = new UdpClient(12345);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0);
            Console.WriteLine("сервер ждет сообщение от клиента");

            CancellationTokenSource cts = new CancellationTokenSource();
            bool canWork = true;

            while(!cts.IsCancellationRequested)
            {
                byte[] buffer = udpClient.Receive(ref iPEndPoint);
                var message = Encoding.UTF8.GetString(buffer);

                byte[] answer = Encoding.UTF8.GetBytes("Сообщение получено");

                int bytes = await udpClient.SendAsync(answer, iPEndPoint);
            }
        }
    }*/
}
