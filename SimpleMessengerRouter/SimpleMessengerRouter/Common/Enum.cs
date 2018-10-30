using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessengerRouter.Common
{
    class Enum
    {
        public enum ClientType
        {
            QQ, 
            Bukkit, 
            Sponge, 
            Client, 
            Bungee, 
            Console, 
            Other
        }

        public enum MsgType
        {
            msg, 
            img, 
            handshake, 
            control, 
            error
        }
    }
}
