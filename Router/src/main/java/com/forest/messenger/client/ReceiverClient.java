package com.forest.messenger.client;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.PrintWriter;
import java.io.Reader;
import java.net.Socket;
import java.util.Scanner;

public class ReceiverClient {
	public static void main(String[] args) {
		try {
			Socket socket = new Socket("localhost",8023);		
			BufferedReader br=new BufferedReader(new InputStreamReader(socket.getInputStream()));
			PrintWriter out=new PrintWriter(socket.getOutputStream());
		
			while(true)
			  {
			   String s=br.readLine();
			   System.out.println(s);
			  }
	    }catch(Exception e){
	    	e.printStackTrace();
	    }
	}
}

