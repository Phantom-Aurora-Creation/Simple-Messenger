package com.romonov.spigotplugin.simplemessenger;

import com.google.gson.Gson;
import org.bukkit.Bukkit;
import org.bukkit.event.EventHandler;
import org.bukkit.event.Listener;
import org.bukkit.event.player.AsyncPlayerChatEvent;
import org.bukkit.plugin.java.JavaPlugin;

public class ChatListener implements Listener
{
    SocketWorker socket = null;

    public ChatListener(JavaPlugin plugin)
    {
        SimpleMessenger.getPlugin(SimpleMessenger.class).getLogger().info("Initializing listener.");
        socket = new SocketWorker("116.31.124.36", 33663);
        Handshake("85662271");

        Thread thread = new Thread(this::OnReceive);
        thread.start();
    }

    private void Handshake(String password)
    {
        String handshake = ProtocolWorker.Build(Enum.Type.handshake, "Romonov", "Romonov", AccessCodeWorker.GetAccessCode(password));
        socket.Send(handshake);
    }

    private void OnReceive()
    {
        while (true)
        {
            String msg = socket.Receive();

            if (msg != "")
            {
                Gson gson = new Gson();
                Message message = gson.fromJson(msg, Message.class);
                Bukkit.getServer().broadcastMessage("[QQ]" + message.Name + ":" + message.Msg);
            }
            else
            {
                continue;
            }
        }
    }

    @EventHandler
    public void onPlayerChat(AsyncPlayerChatEvent e)
    {
        String msg = ProtocolWorker.Build(Enum.Type.msg, e.getPlayer().getUniqueId().toString(), e.getPlayer().getName(), e.getMessage());
        socket.Send(msg);
    }
}
