package jg.rpg.utils;

import java.io.IOException;

import org.apache.log4j.Logger;

import io.netty.buffer.ByteBuf;
import io.netty.buffer.Unpooled;
import io.netty.channel.ChannelHandlerContext;
import jg.rpg.common.protocol.MsgProtocol;
import jg.rpg.config.GameConfig;
import jg.rpg.entity.MsgPacker;
import jg.rpg.entity.MsgUnPacker;

public class MsgUtils {

	private static Logger logger = Logger.getLogger(MsgUtils.class);
	
	public static MsgUnPacker DeserializerMsg(ByteBuf buf) throws IOException{
		int len = buf.readableBytes();
		byte[] bs =new byte[len];
		buf.getBytes(0, bs);
		return DeserializerMsg(bs);
	}
	public static MsgUnPacker DeserializerMsg(byte[] buf) throws IOException{
		return new MsgUnPacker(buf);
	}
	public static ByteBuf serializerMsg(MsgPacker msg) throws IOException{
		byte[] msgBytes = msgToBytes(msg);
		byte[] msgLenBytes = defMsgLenEncoding(msgBytes.length);
		int totalSize = msgBytes.length + msgLenBytes.length;
		ByteBuf buff = Unpooled.buffer(totalSize);
		buff.writeBytes(msgLenBytes);
		buff.writeBytes(msgBytes);
		logger.debug("Send MsgLen " + totalSize);
		return buff;
	}
	
	public static byte[] msgToBytes(MsgPacker msg) throws IOException{
		return msg.Serialize();
	}
	public static byte[] defMsgLenEncoding(int num){
		return intToBytes(num, GameConfig.MsgHeadLen);
	}
	
	public static byte[] intToBytes(int num , int buffLen){
		byte[] buff = new byte[buffLen];
		int temp = 0;
		int index = 0;
		while(num > 0){
			temp = num % 256;
			buff[index++] = (byte)temp;
			num = num / 256;
		}
		return buff;
	}
	
	public static void sendMsg(ChannelHandlerContext ctx , MsgPacker packer) throws IOException{
		ByteBuf buff = serializerMsg(packer);
		packer.close();
		if(buff != null){
			ctx.writeAndFlush(buff);
		}else{
			throw new IOException("buff is null!!");
		}
	}
	public static void SendErroInfo(ChannelHandlerContext ctx , String info){
		MsgPacker packer = new MsgPacker();
		try {
			packer.addInt(MsgProtocol.Error)
				.addString(info);
			sendMsg(ctx,packer);
		} catch (IOException e) {
			logger.error("Server is Error");
		}
	
	}
	
	public static MsgPacker getSuccessPacker(){
		MsgPacker packer = new MsgPacker();
		try {
			packer.addInt(MsgProtocol.Success);
		} catch (IOException e) {
			e.printStackTrace();
		}
		return packer;
	}
}
