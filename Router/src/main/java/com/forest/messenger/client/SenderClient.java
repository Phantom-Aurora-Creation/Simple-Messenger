package com.forest.messenger.client;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.util.Scanner;

public class SenderClient {
	public static void main(String[] args) {
		try {
			Socket socket = new Socket("localhost",8023);		
			Scanner br=new Scanner(System.in);
			PrintWriter out=new PrintWriter(socket.getOutputStream());
		
			while(true)
			  {
			   String s=br.nextLine();
			   out.println(s);
			   out.flush();
			  }
	    }catch(Exception e){
	    	e.printStackTrace();
	    }
	}
}
