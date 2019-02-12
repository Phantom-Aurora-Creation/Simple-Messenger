package com.romonov.spongeplugin.simplemessenger;

import com.google.gson.Gson;

public class MessageHandler
{
    public static void Handle(String msg)
    {
        Gson gson = new Gson();
        Message message = gson.fromJson(msg.trim(), Message.class);
        switch (message.Type)
        {
            case msg:
                if (message.From == Enum.From.QQ)
                {

                }
                break;
            case img:

                break;
            case control:
            case error:
            default:
                break;
        }
    }
}
