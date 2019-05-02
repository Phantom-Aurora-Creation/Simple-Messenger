package moe.qian.forgemod.simplemessengerserversideonly;

public class Enum {
    public static enum Type
    {
        msg,
        img,
        handshake,
        control,
        error
    }

    public static enum From
    {
        QQ,
        Bukkit,
        Sponge,
        Client,
        Bungee,
        Console,
        Other
    }
}
