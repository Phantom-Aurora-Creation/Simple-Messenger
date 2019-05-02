package moe.qian.forgemod.simplemessengerserversideonly.Proxy;

import moe.qian.forgemod.simplemessengerserversideonly.SimpleMessenger;
import moe.qian.forgemod.simplemessengerserversideonly.SocketWorker;
import net.minecraftforge.fml.common.event.FMLInitializationEvent;
import net.minecraftforge.fml.common.event.FMLPostInitializationEvent;
import net.minecraftforge.fml.common.event.FMLPreInitializationEvent;

public class ProxyServer extends ProxyCommon {
    @Override
    public void preInit(FMLPreInitializationEvent event)
    {
        super.preInit(event);
        SimpleMessenger.setSocketWorker(new SocketWorker("", 33663));
    }

    @Override
    public void init(FMLInitializationEvent event)
    {
        super.init(event);
    }

    @Override
    public void postInit(FMLPostInitializationEvent event)
    {
        super.postInit(event);
    }
}
