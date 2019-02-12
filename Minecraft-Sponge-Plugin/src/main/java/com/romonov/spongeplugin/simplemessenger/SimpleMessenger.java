package com.romonov.spongeplugin.simplemessenger;

import com.google.inject.Inject;
import org.slf4j.Logger;
import org.spongepowered.api.event.Listener;
import org.spongepowered.api.event.game.state.GameStartedServerEvent;
import org.spongepowered.api.event.message.MessageChannelEvent;
import org.spongepowered.api.plugin.Plugin;

@Plugin(
        id = "simple-messenger",
        name = "Simple-Messenger",
        description = "Exchanger of QQ Group and Minecraft Server messages.",
        authors = {
                "Romonov"
        }
)
public class SimpleMessenger
{

    @Inject
    public static Logger logger;

    @Listener
    public void onServerStart(GameStartedServerEvent event)
    {
        logger.info("Simple messenger enabled!");
    }
}
