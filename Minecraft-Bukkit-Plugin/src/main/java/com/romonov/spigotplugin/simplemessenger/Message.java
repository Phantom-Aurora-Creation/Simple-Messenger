package com.romonov.spigotplugin.simplemessenger;

public class Message
{
    private int Ver;
    private String Type;
    private String Time;
    private int ID;
    private int Parts;
    private int AllParts;
    private String From;
    private String Uid;
    private String Name;
    private String Msg;

    public int getAllParts() {
        return AllParts;
    }

    public int getID() {
        return ID;
    }

    public int getParts() {
        return Parts;
    }

    public int getVer() {
        return Ver;
    }

    public String getTime() {
        return Time;
    }

    public String getFrom() {
        return From;
    }

    public String getType() {
        return Type;
    }

    public String getUid() {
        return Uid;
    }

    public String getMsg() {
        return Msg;
    }

    public String getName() {
        return Name;
    }

    public void setID(int ID) {
        this.ID = ID;
    }

    public void setAllParts(int allParts) {
        AllParts = allParts;
    }

    public void setParts(int parts) {
        Parts = parts;
    }

    public void setFrom(String from) {
        From = from;
    }

    public void setTime(String time) {
        Time = time;
    }

    public void setType(String type) {
        Type = type;
    }

    public void setUid(String uid) {
        Uid = uid;
    }

    public void setVer(int ver) {
        Ver = ver;
    }

    public void setMsg(String msg) {
        Msg = msg;
    }

    public void setName(String name) {
        Name = name;
    }
}
