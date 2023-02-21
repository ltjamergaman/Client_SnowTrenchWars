function clientCmdSTW_createHUD()
{
	if(isObject(STW_HUD))
	{
		PlayGUI.add(STW_HUD);
	}
	else
	{
		exec("./GUI/STW_HUD.gui");
		PlayGUI.add(STW_HUD);
	}
	
	STW_HUD.adjustToResolution();
}

function clientCmdSTW_UpdateHUDStats(%check,%vars)
{
	if(%check)
	{
		STW_HUD.UpdateStats(%vars);
	}
	else
	{
		commandToServer('STW_SendHUDStats');
	}
}

function STW_HUD::UpdateStats(%this,%vars)
{
	%health = getWord(%vars,0);
	%maxhealth = getWord(%vars,1);
	%armor = getWord(%vars,2);
	%maxarmor = getWord(%vars,3);
	%level = getWord(%vars,4);
	%rank = getWord(%vars,5);
	%exp = getWord(%vars,6);
	%reqexp = getWord(%vars,7);
	%money = getWord(%vars,8);
	%cps = getWord(%vars,9);
	
	%health = STW_convertStrength(%health,%maxHealth);
	%armor = STW_convertStrength(%armor,%maxarmor);
	%exp = STW_convertEXP(%exp,%reqexp);
	
	STW_HUD_Health.setValue(%health);
	STW_HUD_Armor.setValue(%armor);
	STW_HUD_RankLevel.setValue("<just:center><font:arial:12><color:FFFFFF>R<color:FFFF00>"@%rank@" <color:FFFFFF>| L<color:FFFF00>"@%level);
	STW_HUD_EXP.setValue(%exp);
	STW_HUD_Money.setValue("<just:center><font:arial:12><color:FFFF00>"@%money);
	STW_HUD_CPs.setValue("<just:center><font:arial:12><color:FFFFFF>C.P.s <color:00AAEE>"@%cps);
}

function STW_HUD::AdjustToResolution(%this)
{
	%obj1 = STW_HUD_Armor.getID();
	%obj2 = STW_HUD_Health.getID();
	%obj3 = STW_HUD_EXP.getID();
	%obj4 = STW_HUD_RankLevel.getID();
	%obj5 = STW_HUD_CPs.getID();
	%obj6 = STW_HUD_Money.getID();
	%icon1 = STW_HUD_ArmorIcon.getID();
	%icon2 = STW_HUD_HealthIcon.getID();
	%icon3 = STW_HUD_EXPIcon.getID();
	%icon4 = STW_HUD_RankLevelIcon.getID();
	%icon5 = STW_HUD_CPsIcon.getID();
	%icon6 = STW_HUD_MoneyIcon.getID();
	
	echo("- STW_HUD::AdjustToResolution - Checking resolution...");
	%res = getWord(getRes(),0) SPC getWord(getRes(),1);
	%width = getWord(%res,0);
	%height = getWord(%res,1);
	
	if(%width < 640 || %height < 480)
	{
		error("- STW_HUD::AdjustToResolution - Resolution is too small for the HUD to fit the screen! Will not further commence with sequence.");
		return;
	}
	
	echo("|- STW_HUD::AdjustToResolution - Resolution is fine" NL " |- Commencing with interface adjustment sequence");
	
	
	%this.extent = %res;
	
	%icon1.position = "7" SPC (%height - 90);
	%icon2.position = "7" SPC (%height - 60);
	%icon3.position = "7" SPC (%height - 30);
	%icon4.position = (%width - 42) SPC (%height - 120);
	%icon5.position = (%width - 42) SPC (%height - 90);
	%icon6.position = (%width - 42) SPC (%height - 60);
	%obj1.position = "37" SPC (%height - 84);
	%obj2.position = "37" SPC (%height - 54);
	%obj3.extent = (%width - 60) SPC "13";
	%obj3.position = "37" SPC (%height - 24);
	%obj4.position = (%width - 128) SPC (%height - 114);
	%obj5.position = (%width - 128) SPC (%height - 84);
	%obj6.position = (%width - 128) SPC (%height - 54);
}