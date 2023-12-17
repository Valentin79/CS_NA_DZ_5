using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using CS_NA_Sem_5;

namespace CS_NA_Sem_5.Abstracts
{
    public interface IMessageSourse
    {
        Task SendAsync (NetMessage message, IPEndPoint ep);

        NetMessage Recive(ref IPEndPoint ep);

    }
}
