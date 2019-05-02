package moe.qian.forgemod.simplemessengerserversideonly;

import moe.qian.forgemod.simplemessengerserversideonly.Proxy.ProxyCommon;
import net.minecraftforge.fml.common.Mod;
import net.minecraftforge.fml.common.SidedProxy;
import net.minecraftforge.fml.common.event.FMLInitializationEvent;
import net.minecraftforge.fml.common.event.FMLPostInitializationEvent;
import net.minecraftforge.fml.common.event.FMLPreInitializationEvent;
import org.apache.logging.log4j.Logger;

@Mod(
        modid = SimpleMessenger.MODID,
        name = SimpleMessenger.NAME,
        version = SimpleMessenger.VERSION,
        acceptableRemoteVersions = "*",
        acceptedMinecraftVersions = "1.12.2"
)
public class SimpleMessenger {
    public static final String MODID = "";
    public static final String NAME = "Simple Messenger Server-Side Only";
    public static final String VERSION = "1.0.0";

    private static Logger logger;
    private static SocketWorker socketWorker = null;

    public static Logger getLogger() {
        return logger;
    }

    public static SocketWorker getSocketWorker() {
        return socketWorker;
    }

    public static void setSocketWorker(SocketWorker socket) {
        socketWorker = socket;
    }

    @SidedProxy(
            clientSide = "moe.qian.forgemod.simplemessengerserversideonly.Proxy.CommonProxy",
            serverSide = "moe.qian.forgemod.simplemessengerserversideonly.Proxy.ServerProxy"
    )
    public static ProxyCommon proxy;

    @Mod.EventHandler
    public void preInit(FMLPreInitializationEvent event)
    {
        proxy.preInit(event);
    }

    @Mod.EventHandler
    public void init(FMLInitializationEvent event)
    {
        proxy.init(event);
    }

    @Mod.EventHandler
    public void postInit(FMLPostInitializationEvent event)
    {
        proxy.postInit(event);
    }

}
