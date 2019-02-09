package com.forest.messenger.server;

import io.netty.bootstrap.ServerBootstrap;
import io.netty.channel.Channel;
import io.netty.channel.ChannelFuture;
import io.netty.channel.ChannelInitializer;
import io.netty.channel.ChannelOption;
import io.netty.channel.EventLoopGroup;
import io.netty.channel.nio.NioEventLoopGroup;
import io.netty.channel.sctp.nio.NioSctpServerChannel;
import io.netty.channel.socket.SocketChannel;
import io.netty.channel.socket.nio.NioServerSocketChannel;

public class MessageServer {
	public void bind(int port) throws Exception{
		EventLoopGroup bossGroup=new NioEventLoopGroup();
		EventLoopGroup workerGroup=new NioEventLoopGroup();
		try {
			ServerBootstrap b =new ServerBootstrap();
			b.group(bossGroup,workerGroup)
			 .channel(NioServerSocketChannel.class)
			 .option(ChannelOption.SO_BACKLOG, 1024)
			 .childHandler(new ChildhannelHandler());
			ChannelFuture f =b.bind(port).sync();
			f.channel().closeFuture().sync();
		}finally {
			bossGroup.shutdownGracefully();
			workerGroup.shutdownGracefully();
		}
	}
   
	private class ChildhannelHandler extends ChannelInitializer<SocketChannel>{

		@Override
		protected void initChannel(SocketChannel ch) throws Exception {
			ch.pipeline().addLast(new MessageServerHandler());
		}
		
	}
	
	public static void main(String[]args) throws Exception{
		int port =8023;
		if(args != null &&args.length>0) {
			try {
				port = Integer.valueOf(args[0]);
			}catch(NumberFormatException e) {
				
			}
		}
		new MessageServer().bind(port);
	}
}
