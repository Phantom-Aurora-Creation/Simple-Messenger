package com.romonov.spigotplugin.simplemessenger;

import org.bukkit.configuration.file.YamlConfiguration;
import org.bukkit.plugin.java.JavaPlugin;

import java.io.File;

public class ConfigWorker
{
    public static String ServerIP;
    public static int ServerPort;
    public static String Password;

    private YamlConfiguration config = null;

    public ConfigWorker(JavaPlugin plugin)
    {
        File file = new File(plugin.getDataFolder(), "config.yml");
        config = YamlConfiguration.loadConfiguration(file);

        ServerIP = config.getString("ServerIP");
        ServerPort = config.getInt("ServerPort");
        Password = config.getString("Password");
    }
}
