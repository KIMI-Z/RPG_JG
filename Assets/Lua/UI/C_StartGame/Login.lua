﻿Login = {};
local this = Login;
local inst;


function this.Awake()
	inst = this.inst;
end

function this.Login()
	--local username = 
	UITools.Log('Login');
end

function this.Register()
	UITools.ClosePanel(inst);
	UITools.D('Register'):OnCommand('Show');
end

function  this.OnCommand(command , param)
	if command == 'Login' then
		this.Login();
	elseif command == 'Register' then
		this.Register();
	end
end
