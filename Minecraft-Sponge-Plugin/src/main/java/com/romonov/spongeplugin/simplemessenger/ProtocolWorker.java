package com.romonov.spongeplugin.simplemessenger;

import com.google.gson.Gson;

import java.text.SimpleDateFormat;
import java.util.Date;

public class ProtocolWorker {
    public static String Build(Enum.Type type, String uid, String name, String msg)
    {
        String time = "";
        Date date = new Date();
        SimpleDateFormat simpleDateFormat = new SimpleDateFormat("yyyyMMddhhmm");
        time = simpleDateFormat.format(date);

        Message message = new Message();
        message.Ver = 9;
        message.Type = type;
        message.Time = time;
        message.ID = 1;
        message.Parts = 1;
        message.AllParts = 1;
        message.From = Enum.From.Bukkit;
        message.Uid = uid;
        message.Name = name;
        message.Msg = msg;

        Gson gson = new Gson();
        return gson.toJson(message);
    }
}
