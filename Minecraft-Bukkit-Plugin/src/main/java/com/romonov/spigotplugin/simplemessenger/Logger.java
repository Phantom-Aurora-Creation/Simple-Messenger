package com.romonov.spigotplugin.simplemessenger;

import java.io.File;
import java.io.FileWriter;
import java.io.PrintWriter;
import java.text.SimpleDateFormat;
import java.util.Date;

public class Logger
{
    public static void Write(String msg)
    {
        String time = "";
        Date date = new Date();
        SimpleDateFormat simpleDateFormat = new SimpleDateFormat("[yyyy-MM-dd][hh:mm:ss]");
        time = simpleDateFormat.format(date);

        InternalWrite(time + "msg");
    }

    private static void InternalWrite(String str)
    {
        try
        {
            Date date = new Date();
            SimpleDateFormat simpleDateFormat = new SimpleDateFormat("yyyy-MM-dd");
            String fileName = simpleDateFormat.format(date) + ".log";
            String filePath = System.getProperty("user.dir") + "\\logs\\SimpleMessenger\\" + fileName;
            File file = new File(filePath);

            if (!file.exists()) {
                file.createNewFile();
            }

            FileWriter fileWriter = new FileWriter(file, true);
            PrintWriter printWriter = new PrintWriter(fileWriter);
            printWriter.println(str);
            printWriter.flush();
            printWriter.close();
            fileWriter.close();

        }
        catch (Exception ex)
        {
            ex.printStackTrace();
        }
    }
}
