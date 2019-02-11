package com.romonov.spigotplugin.simplemessenger;

import org.bukkit.plugin.PluginManager;
import org.bukkit.plugin.java.JavaPlugin;

public final class SimpleMessenger extends JavaPlugin
{
    @Override
    public void onEnable()
    {
        // Plugin startup logic
        getLogger().info("Simple messenger enabled!");

        PluginManager pluginManager = getServer().getPluginManager();
        ChatListener chatListener = new ChatListener();
        pluginManager.registerEvents(chatListener, this);
    }

    @Override
    public void onDisable()
    {
        // Plugin shutdown logic
        getLogger().info("Simple messenger disabled!");
    }
}
