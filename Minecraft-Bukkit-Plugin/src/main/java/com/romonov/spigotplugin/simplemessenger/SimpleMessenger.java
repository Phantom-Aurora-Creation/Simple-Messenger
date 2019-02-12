package com.romonov.spigotplugin.simplemessenger;

import org.bukkit.plugin.PluginManager;
import org.bukkit.plugin.java.JavaPlugin;

public final class SimpleMessenger extends JavaPlugin
{

    private ChatListener chatListener = null;

    @Override
    public void onEnable()
    {
        // Plugin startup logic
        getLogger().info("Simple messenger enabled!");

        saveDefaultConfig();
        ConfigWorker configWorker = new ConfigWorker(this);

        PluginManager pluginManager = getServer().getPluginManager();
        chatListener = new ChatListener();
        pluginManager.registerEvents(chatListener, this);
    }

    @Override
    public void onDisable()
    {
        // Plugin shutdown logic
        saveConfig();
        chatListener.socket.Close();
        getLogger().info("Simple messenger disabled!");
    }
}
