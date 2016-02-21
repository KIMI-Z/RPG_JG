package jg.rpg.entity.msgEntity;

import java.sql.SQLException;

import jg.rpg.common.abstractClass.EntityBase;
import jg.rpg.dao.db.DBHelper;
import jg.rpg.dao.db.DBMgr;
import jg.rpg.dao.db.RSHHelper;

public class Task extends EntityBase<Task>{

	private int id;
	private int taskId;
	private String type;
	private int roleId;
	private int status;
	private int goldCount;
	private int diamondCount;
	private int curStage;
	private int totalStage;
	
	
	
	public int getCurStage() {
		return curStage;
	}
	public void setCurStage(int curStage) {
		this.curStage = curStage;
	}
	public int getTotalStage() {
		return totalStage;
	}
	public void setTotalStage(int totalStage) {
		this.totalStage = totalStage;
	}
	public int getTaskId() {
		return taskId;
	}
	public void setTaskId(int taskId) {
		this.taskId = taskId;
	}
	public int getRoleId() {
		return roleId;
	}
	public int getDiamondCount() {
		return diamondCount;
	}
	public void setDiamondCount(int diamondCount) {
		this.diamondCount = diamondCount;
	}
	public void setRoleId(int roleId) {
		this.roleId = roleId;
	}
	public int getId() {
		return id;
	}
	public void setId(int id) {
		this.id = id;
	}
	public String getType() {
		return type;
	}
	public void setType(String type) {
		this.type = type;
	}
	public int getStatus() {
		return status;
	}
	public void setStatus(int status) {
		this.status = status;
	}
	public int getGoldCount() {
		return goldCount;
	}
	public void setGoldCount(int goldCount) {
		this.goldCount = goldCount;
	}
	@Override
	public boolean isNeedDelete() {
		return getStatus() >= 4 ? true : false;
	}
	@Override
	public boolean isExistInDB() throws SQLException {
		String sql = "select * from tb_task where id = ?";
		Task task = DBHelper.GetFirst(DBMgr.getInstance().getDataSource(), sql,
				RSHHelper.getTaskRSH(), getId());
		return task != null;
	}

	@Override
	public int updateToDB() throws SQLException {
		String sql = "update tb_task set status = ? where id = ?";
		
		return DBHelper.update(DBMgr.getInstance().getDataSource(), sql 
				,getStatus(), getId());
	}
	@Override
	public int deleteFromDB() throws SQLException {
		String sql = "delete from tb_task where id = ?";
		return DBHelper.update(DBMgr.getInstance().getDataSource(), sql , getId());
	}
	
	@Override
	public Task insertToDB() throws SQLException {
		if(isExistInDB()){
			throw new SQLException("Task has Exist!");
		}
		String sql = "insert into tb_task values(null,? ,?,?,?,?,?,?,?)";
		Task task = DBHelper.insert(DBMgr.getInstance().getDataSource(), sql,
				RSHHelper.getTaskRSH(), getTaskId(),getRoleId() , getType(),getStatus() , getGoldCount()
				, getDiamondCount(),getCurStage(),getTotalStage());
		setId(task.getId());
		return this;
	}
	
}
