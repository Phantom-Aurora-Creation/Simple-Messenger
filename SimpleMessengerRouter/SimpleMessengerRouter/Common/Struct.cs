namespace SimpleMessengerRouter.Common
{
    class Struct
    {
        public struct Message
        {
            int Ver;
            MyEnum.MsgType Type;
            string Time;
            int ID;
            int Parts;
            int AllParts;
            MyEnum.ClientType From;
            string Uid;
            string Name;
            string Msg;
        }
    }
}
