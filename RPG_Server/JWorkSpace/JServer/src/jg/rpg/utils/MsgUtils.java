package jg.rpg.utils;

import java.io.IOException;

import org.apache.log4j.Logger;

import io.netty.buffer.ByteBuf;
import io.netty.buffer.Unpooled;
import jg.rpg.entity.MsgPacker;
import jg.rpg.entity.MsgUnPacker;
import jg.rpg.utils.config.GameConfig;

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
}