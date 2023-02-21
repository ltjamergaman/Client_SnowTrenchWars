$STW::Client::WeaponData::SaveDir = "config/client/Snow Trench Wars/Weapon Data";

function clientCmdSTW_RankUp()
{
	commandToServer('STW_RankUp');
}

function clientCmdSTW_getClientStats(%check,%stats)
{
	if(%check)
	{
		%Level = getWord(%stats,1);
		%Rank = getWord(%stats,2);
		%EXP = getWord(%stats,3);
		%ReqEXP = getWord(%stats,4);
		%CPs = getWord(%stats,5);
		%Money = getWord(%stats,6);
		%Armor = getWord(%stats,7);
		%PlayerType = getWord(%stats,8) SPC getWord(%stats,9) SPC getWord(%stats,10) SPC getWord(%stats,11);
		
		STWGUI_Stats_Level.setValue("<font:Lucida Console:14>Level: <color:FFFF00>"@%level);
		STWGUI_Stats_Rank.setValue("<font:Lucida Console:14>Rank: <color:FFFF00>"@%rank);
		STWGUI_Stats_EXP.setValue("<font:Lucida Console:14>EXP: <color:FFFF00>"@%exp@"<color:FFFFFF>/<color:FFFF00>"@%reqexp);
		STWGUI_Stats_CPs.setValue("<font:Lucida Console:14>CP(s): <color:FFFF00>"@%cps);
		STWGUI_Stats_Money.setValue("<font:Lucida Console:14>Money: <color:FFFF00>$"@%money);
		STWGUI_Stats_Armor.setValue("<font:Lucida Console:14><color:00FFFF>Armor<color:FFFFFF>: "@%armor);
		STWGUI_Stats_PlayerType.setValue("<font:Lucida Console:14><color:FF00FF>Player<color:FFFFFF>: "@%playertype);
	}
	else
	{
		commandToServer('STW_sendClientStats');
	}
}

function clientCmdSTW_getWeaponsInfo(%check,%itemData,%name,%damage,%maxammo,%value)
{
	if(%check)
	{
		STW_SaveWeaponData(%itemData,%name,%damage,%maxammo,%value);
		$STW::Client::WeaponData[%itemData].Name = %name;
		$STW::Client::WeaponData[%itemData].Damage = %damage;
		$STW::Client::WeaponData[%itemData].MaxAmmo = %maxammo;
		$STW::Client::WeaponData[%itemData].Value = %value;
	}
	else
	{
		commandToServer('STW_SendWeaponsInfo');
	}
}

function STW_SaveWeaponData(%itemData,%name,%damage,%maxammo,%value)
{
	%file = new FileObject();
	%file.openForWrite($STW::Client::WeaponData::SaveDir @ "/" @ %itemData @".txt");
	%file.writeLine(%name);
	%file.writeLine(%damage);
	%file.writeLine(%maxAmmo);
	%file.writeLine(%value);
	%file.close();
	%file.delete();
}

function clientCmdSTW_DonateToPlayer(%money,%player)
{
	commandToServer('STW_DonateMoney',%player,%money);
	canvas.popDialog(STW_DTPGUI);
	$STW::GUI::DTP::Money = "100";
	STW_DTPGUI_UserName.setValue("");
	clientCmdSTW_GetClientStats();
}
