package com.romonov.spongeplugin.simplemessenger;

import org.apache.commons.codec.digest.DigestUtils;

import java.text.SimpleDateFormat;
import java.util.Date;

public class AccessCodeWorker
{
    public static String GetAccessCode(String password)
    {
        Date date = new Date();
        SimpleDateFormat simpleDateFormat = new SimpleDateFormat("yyyyMMddhhmm");
        return "SMV9AC0D" + Md5(Md5(password) + simpleDateFormat.format(date));
    }

    public static String Md5(String text)
    {
        String encodeStr= DigestUtils.md5Hex(text);
        return encodeStr;
    }
}
