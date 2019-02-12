package com.romonov.spongeplugin.simplemessenger;

import java.io.PrintWriter;
import java.net.Socket;

public class SocketWorker
{
    private Socket socket = null;
    PrintWriter printWriter = null;

    public SocketWorker(String ip, int port)
    {
        try
        {
            socket = new Socket(ip, port);
            printWriter = new PrintWriter(socket.getOutputStream());
            SimpleMessenger.logger.info("Socket started!");
        }
        catch (Exception ex)
        {
            ex.printStackTrace();
        }
    }

    public void Send(String str)
    {
        printWriter.write(str);
        printWriter.flush();
    }

    public String Receive()
    {
        try
        {
            byte[] t = new byte[1024 * 1024];
            socket.getInputStream().read(t);
            String msg = new String(t);
            msg.trim();
            return msg;
        }
        catch (Exception ex)
        {
            return "";
        }
    }

    public void Close()
    {
        printWriter.close();
        try
        {
            socket.close();
        }
        catch (Exception ex)
        {
            ex.printStackTrace();
        }
    }
}
