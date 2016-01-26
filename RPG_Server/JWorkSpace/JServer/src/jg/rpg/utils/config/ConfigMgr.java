package jg.rpg.utils.config;

import java.awt.Component;
import java.io.File;
import java.util.Iterator;
import java.util.List;

import org.dom4j.Attribute;
import org.dom4j.Document;
import org.dom4j.Element;
import org.dom4j.bean.BeanDocumentFactory;
import org.dom4j.io.SAXReader;

import jg.rpg.entity.DBEntityInfo;
import jg.rpg.exceptions.InitException;

public class ConfigMgr {

	private DBEntityInfo strogeDbInfo;
	
	private static boolean isInit;
	private static ConfigMgr inst;
	public static ConfigMgr getInstance(){
		if(inst == null){
			inst = new ConfigMgr();
		}
		return inst;
	}
	private ConfigMgr(){

	}

	public void init() throws Exception {
		String path = System.getProperty("user.dir")+
				File.separator+"config"+File.separator+"config.xml";
		Document document = parse(path);
		if(document != null){
			process(document);
		}else{
			throw new InitException("ConfigMgr init error!!!");
		}
	}
	
	private Document parse(String url) throws Exception {
        SAXReader reader = new SAXReader(BeanDocumentFactory.getInstance());
        return reader.read(url);
    }
	
    private void process(Document document) throws Exception {
        // find all of the windows
    	Element root = document.getRootElement();
    	Element eDB = root.element("db");
    	Element eSDB = eDB.element("StorageDB");
    	
    	//��װStorgeDBxinxi
    	strogeDbInfo = new DBEntityInfo();
    	strogeDbInfo.setDriver(eSDB.elementTextTrim("driver"));
    	strogeDbInfo.setUser(eSDB.elementTextTrim("user"));
    	strogeDbInfo.setPwd(eSDB.elementTextTrim("passworld"));
    	strogeDbInfo.setUrl(eSDB.elementTextTrim("url"));
    }
    
    
	public DBEntityInfo getStrogeDbInfo() {
		return strogeDbInfo;
	}
 
}

