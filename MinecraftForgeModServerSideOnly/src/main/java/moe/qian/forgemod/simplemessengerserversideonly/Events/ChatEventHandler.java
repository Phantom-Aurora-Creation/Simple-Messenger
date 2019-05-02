package moe.qian.forgemod.simplemessengerserversideonly.Events;

import moe.qian.forgemod.simplemessengerserversideonly.Enum;
import moe.qian.forgemod.simplemessengerserversideonly.MessageHandler;
import moe.qian.forgemod.simplemessengerserversideonly.ProtocolWorker;
import moe.qian.forgemod.simplemessengerserversideonly.SimpleMessenger;
import net.minecraftforge.common.MinecraftForge;
import net.minecraftforge.event.ServerChatEvent;
import net.minecraftforge.fml.common.eventhandler.SubscribeEvent;

public class ChatEventHandler {
    public ChatEventHandler() {
        MinecraftForge.EVENT_BUS.register(this);

        Thread thread = new Thread(this::OnReceive);
        thread.start();
    }

    @SubscribeEvent
    public void onPlayerChat(ServerChatEvent event) {
        String msg = ProtocolWorker.Build(Enum.Type.msg, event.getPlayer().getUniqueID().toString(), event.getUsername(), event.getMessage());
        SimpleMessenger.getSocketWorker().Send(msg);
    }

    private void OnReceive()
    {
        while (true)
        {
            String msg = SimpleMessenger.getSocketWorker().Receive();

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
}
