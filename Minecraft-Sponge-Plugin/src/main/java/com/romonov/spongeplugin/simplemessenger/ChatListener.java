package com.romonov.spongeplugin.simplemessenger;

import org.spongepowered.api.event.Listener;
import org.spongepowered.api.event.message.MessageChannelEvent;

public class ChatListener
{
    SocketWorker socket = null;

    public ChatListener()
    {
        SimpleMessenger.logger.info("Initializing listener.");
        socket = new SocketWorker(ConfigWorker.ServerIP, ConfigWorker.ServerPort);
        Handshake(ConfigWorker.Password);

        Thread thread = new Thread(this::OnReceive);
        thread.start();
    }

    private void Handshake(String password)
    {
        String handshake = ProtocolWorker.Build(Enum.Type.handshake, "", "", AccessCodeWorker.GetAccessCode(password));
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

    @Listener
    public void onPlayerChat(MessageChannelEvent.Chat event)
    {
        event.getMessage();
    }
}
