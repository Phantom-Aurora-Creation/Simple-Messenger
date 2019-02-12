package com.romonov.spigotplugin.simplemessenger;

import org.bukkit.Bukkit;
import org.bukkit.event.EventHandler;
import org.bukkit.event.Listener;
import org.bukkit.event.player.AsyncPlayerChatEvent;

public class ChatListener implements Listener
{
    SocketWorker socket = null;

    public ChatListener()
    {
        SimpleMessenger.getPlugin(SimpleMessenger.class).getLogger().info("Initializing listener.");
        socket = new SocketWorker(ConfigWorker.ServerIP, ConfigWorker.ServerPort);
        Handshake(ConfigWorker.Password);

        Thread thread = new Thread(this::OnReceive);
        thread.start();
    }

    private void Handshake(String password)
    {
        String handshake = ProtocolWorker.Build(Enum.Type.handshake, Bukkit.getServer().getServerId(), Bukkit.getServer().getName(), AccessCodeWorker.GetAccessCode(password));
        socket.Send(handshake);
    }

    private void OnReceive()
    {
        while (true)
        {
            String msg = socket.Receive();

            if (msg != "")
            {
                MessageHandler.Handle(msg);
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
