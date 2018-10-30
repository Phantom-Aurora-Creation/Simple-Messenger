namespace SimpleMessengerRouter.Common
{
    class Struct
    {
        public struct Message
        {
            int Ver;
            Enum.MsgType Type;
            string Time;
            int ID;
            int Parts;
            int AllParts;
            Enum.ClientType From;
            string Uid;
            string Name;
            string Msg;
        }
    }
}
