package com.romonov.spigotplugin.simplemessenger;

import org.apache.commons.codec.digest.DigestUtils;
import java.util.Date;

public class AccessCodeWorker
{
    public static String GetAccessCode(String password)
    {
        System.out.println("SMV9AC0D" + Md5(Md5(password) + new Date().getTime()));
        return "SMV9AC0D" + Md5(Md5(password) + new Date().getTime());
    }

    public static String Md5(String text)
    {
        String encodeStr=DigestUtils.md5Hex(text);
        return encodeStr;
    }
}
