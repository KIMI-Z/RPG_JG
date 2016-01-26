package jg.rpg;

import jg.rpg.dao.db.DBMgr;
import jg.rpg.utils.config.ConfigMgr;

public class LaunchServer {

	public static void main(String[] args) {
		//init all manager
		try {
			ConfigMgr.getInstance().init();
			DBMgr.getInstance().init();
			
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
