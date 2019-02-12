package com.romonov.spongeplugin.simplemessenger;

import org.spongepowered.api.config.DefaultConfig;

public class ConfigWorker
{
    @DefaultConfig(sharedRoot = true)
    public static String ServerIP;

    @DefaultConfig(sharedRoot = true)
    public static int ServerPort;

    @DefaultConfig(sharedRoot = true)
    public static String Password;
}
