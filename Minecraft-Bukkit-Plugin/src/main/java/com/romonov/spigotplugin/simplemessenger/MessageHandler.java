package com.romonov.spigotplugin.simplemessenger;

import com.google.gson.Gson;
import net.md_5.bungee.api.chat.BaseComponent;
import net.md_5.bungee.api.chat.ComponentBuilder;
import net.md_5.bungee.api.chat.HoverEvent;
import net.md_5.bungee.api.chat.TextComponent;
import org.bukkit.Bukkit;
import org.bukkit.entity.Player;


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
                    if (IsSpigot())
                    {
                        TextComponent messageFrom = new TextComponent("[" + message.From+ "]");
                        messageFrom.setHoverEvent(new HoverEvent(HoverEvent.Action.SHOW_TEXT, new ComponentBuilder("QQ群: " + message.Uid.split("/")[1]).create()));
                        TextComponent messageName = new TextComponent(message.Name);
                        messageName.setHoverEvent(new HoverEvent(HoverEvent.Action.SHOW_TEXT, new ComponentBuilder("QQ: " + message.Uid.split("/")[0]).create()));
                        TextComponent messageMsg = new TextComponent(": " + message.Msg);

                        BaseComponent[] components = new BaseComponent[] {messageFrom, messageName, messageMsg};
                        for (Player player : Bukkit.getServer().getOnlinePlayers()) {
                            player.spigot().sendMessage(components);
                        }
                        System.out.println("[" + message.From+ "]" + message.Name + ": " + message.Msg);
                    }
                    else
                    {
                        Bukkit.getServer().broadcastMessage("[" + message.From+ "]" + message.Name + ": " + message.Msg);
                    }
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

    public static boolean IsSpigot()
    {
        try
        {
            Class.forName("org.bukkit.entity.Player$Spigot"); //Some Spigot class
            return true;
        }
        catch (Throwable tr)
        {
            return false;
        }
    }
}
