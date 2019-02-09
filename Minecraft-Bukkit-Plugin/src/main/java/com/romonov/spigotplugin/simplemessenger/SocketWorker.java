package com.romonov.spigotplugin.simplemessenger;

import java.net.Socket;

public class SocketWorker
{
    private Socket socket = null;

    public SocketWorker(String ip, short port)
    {
        try
        {
            socket = new Socket(ip, port);
            SimpleMessenger.getPlugin(SimpleMessenger.class).getLogger().info("Socket started!");
        }
        catch (Exception ex)
        {

        }
    }
}
