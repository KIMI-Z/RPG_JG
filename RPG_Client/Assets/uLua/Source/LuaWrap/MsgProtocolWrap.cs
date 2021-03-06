﻿using System;
using LuaInterface;

public class MsgProtocolWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateMsgProtocol),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("Error", get_Error, null),
			new LuaField("Success", get_Success, null),
			new LuaField("Login", get_Login, null),
			new LuaField("Get_ServerList", get_Get_ServerList, null),
			new LuaField("Register", get_Register, null),
			new LuaField("Query_Status", get_Query_Status, null),
			new LuaField("PreSelectHero", get_PreSelectHero, null),
			new LuaField("EnterGame", get_EnterGame, null),
			new LuaField("Get_TaskList", get_Get_TaskList, null),
			new LuaField("Update_PlayerInfo", get_Update_PlayerInfo, null),
			new LuaField("Get_EquipList", get_Get_EquipList, null),
			new LuaField("Dress_Equip", get_Dress_Equip, null),
			new LuaField("Sale_Equip", get_Sale_Equip, null),
			new LuaField("Upgrade_Equip", get_Upgrade_Equip, null),
			new LuaField("Undress_Equip", get_Undress_Equip, null),
			new LuaField("AcceptTask", get_AcceptTask, null),
			new LuaField("Get_SkillList", get_Get_SkillList, null),
			new LuaField("Upgrade_Skill", get_Upgrade_Skill, null),
			new LuaField("Get_PlayerInfo", get_Get_PlayerInfo, null),
		};

		LuaScriptMgr.RegisterLib(L, "MsgProtocol", typeof(MsgProtocol), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateMsgProtocol(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			MsgProtocol obj = new MsgProtocol();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: MsgProtocol.New");
		}

		return 0;
	}

	static Type classType = typeof(MsgProtocol);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Error(IntPtr L)
	{
		LuaScriptMgr.Push(L, MsgProtocol.Error);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Success(IntPtr L)
	{
		LuaScriptMgr.Push(L, MsgProtocol.Success);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Login(IntPtr L)
	{
		LuaScriptMgr.Push(L, MsgProtocol.Login);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Get_ServerList(IntPtr L)
	{
		LuaScriptMgr.Push(L, MsgProtocol.Get_ServerList);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Register(IntPtr L)
	{
		LuaScriptMgr.Push(L, MsgProtocol.Register);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Query_Status(IntPtr L)
	{
		LuaScriptMgr.Push(L, MsgProtocol.Query_Status);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_PreSelectHero(IntPtr L)
	{
		LuaScriptMgr.Push(L, MsgProtocol.PreSelectHero);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_EnterGame(IntPtr L)
	{
		LuaScriptMgr.Push(L, MsgProtocol.EnterGame);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Get_TaskList(IntPtr L)
	{
		LuaScriptMgr.Push(L, MsgProtocol.Get_TaskList);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Update_PlayerInfo(IntPtr L)
	{
		LuaScriptMgr.Push(L, MsgProtocol.Update_PlayerInfo);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Get_EquipList(IntPtr L)
	{
		LuaScriptMgr.Push(L, MsgProtocol.Get_EquipList);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Dress_Equip(IntPtr L)
	{
		LuaScriptMgr.Push(L, MsgProtocol.Dress_Equip);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Sale_Equip(IntPtr L)
	{
		LuaScriptMgr.Push(L, MsgProtocol.Sale_Equip);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Upgrade_Equip(IntPtr L)
	{
		LuaScriptMgr.Push(L, MsgProtocol.Upgrade_Equip);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Undress_Equip(IntPtr L)
	{
		LuaScriptMgr.Push(L, MsgProtocol.Undress_Equip);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AcceptTask(IntPtr L)
	{
		LuaScriptMgr.Push(L, MsgProtocol.AcceptTask);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Get_SkillList(IntPtr L)
	{
		LuaScriptMgr.Push(L, MsgProtocol.Get_SkillList);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Upgrade_Skill(IntPtr L)
	{
		LuaScriptMgr.Push(L, MsgProtocol.Upgrade_Skill);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Get_PlayerInfo(IntPtr L)
	{
		LuaScriptMgr.Push(L, MsgProtocol.Get_PlayerInfo);
		return 1;
	}
}

