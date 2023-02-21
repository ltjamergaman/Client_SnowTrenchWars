
//--------------------------------------------------------------------------------------------------------------------------//
//THESE FUNCTIONS BELOW ARE TO BE USED ONLY FOR CLIENT TO SERVER TO CLIENT PURPOSES, IF NOT USED CORRECTLY, ERRORS MAY OCCUR//
//--------------------------------------------------------------------------------------------------------------------------//

function clientCmdSTW_Clan_LoadSettings(%team,%ff,%bank,%upgrades,%admins,%cas)
{
	$STW::GUI::Clan::Settings::Team = %team;
	$STW::GUI::Clan::Settings::FriendlyFire = %ff;
	$STW::GUI::Clan::Settings::Bank = %bank;
	$STW::GUI::Clan::Settings::Upgrades = %upgrades;
	$STW::GUI::Clan::Settings::Admins = %admins;
	$STW::GUI::Clan::Settings::CAS = %cas;
	
	STW_ClanDlg.loadSettings(1);
}

function STW_ClanDlg::open(%this)
{
	STW_ClanDlg.loadSettings();
	canvas.pushDialog(STW_ClanDlg);
	STW_ClanDlg_PlayerList.clear();
	STW_ClanDLG_ClanPlayerList.clear();
	%this.populatePlayerList();
	%this.populateClanPlayerList();
	$STW::GUI::Clan::List::CPLSelected = "";
	$STW::GUI::Clan::List::PLSelected = "";
}

function STW_ClanDlg::populatePlayerList(%this)
{
	%list = NPL_List;
	
    for(%i = 0; %i < %list.RowCount(); %i++)
    {
        %blah = %list.getRowText(%i);
        STW_ClanDlg_PlayerList.addRow(%i,"\c5"@%blah);
    }
}

function STW_ClanDlg::populateClanPlayerList(%this,%check,%members)
{
	if(%check)
	{
		//%len = getWordCount(%members);
		//for(%i = 0; %i <= %len; %i++)
		//{
			%blah = %members;
			STW_ClanDlg_ClanPlayerList.addRow(STW_ClanDlg_ClanPlayerList.rowCount()+1,"\c4"@%blah);
		//}
	}
	else
	{
		clientCmdSTW_getClanMembers();
	}
}

function STW_ClanDlg::clickList(%this,%list)
{
	if(%list == 1)
	{
		%blah = STW_ClanDlg_PlayerList;
		$STW::GUI::Clan::List::PLSelected = getWord(%blah.getRowTextByID(%blah.getSelectedID()),1);
		STW_ClanDlg_ClanPlayerList.clearSelection();
	}
	else
	{
		%blah = STW_ClanDlg_ClanPlayerList;
		$STW::GUI::Clan::List::CPLSelected = getWord(%blah.getRowTextByID(%blah.getSelectedID()),1);
		STW_ClanDlg_PlayerList.clearSelection();
	}
}

function STW_ClanDlg::openSettings(%this)
{
	STW_ClanDlg_Settings.setVisible(1);
	STW_ClanDlg.loadSettings();
}

function STW_ClanDlg::loadSettings(%this,%check)
{
	if(%check)
	{
		%team = $STW::GUI::Clan::Settings::Team;
		%ff = $STW::GUI::Clan::Settings::FriendlyFire;
		%bank = $STW::GUI::Clan::Settings::Bank;
		%upgrades = $STW::GUI::Clan::Settings::Upgrades;
		%admins = $STW::GUI::Clan::Settings::Admins;
		%cas = $STW::GUI::Clan::Settings::CAS;
		%a = 0;
		
		for(%i = 1; %i < STW_ClanDlg_Settings.getCount()-1; %i++)
		{
			%a++;
			if(%a == 1)
			{
				STW_ClanDlg_Settings.getObject(%i).setValue(%team);
			}
			if(%a == 2)
			{
				STW_ClanDlg_Settings.getObject(%i).setValue(%ff);
			}
			if(%a == 3)
			{
				STW_ClanDlg_Settings.getObject(%i).setValue(%bank);
			}
			if(%a == 4)
			{
				STW_ClanDlg_Settings.getObject(%i).setValue(%upgrades);
			}
			if(%a == 5)
			{
				STW_ClanDlg_Settings.getObject(%i).setValue(%admins);
			}
			if(%a == 6)
			{
				STW_ClanDlg_Settings.getObject(%i).setValue(%cas);
			}
		}
	}
	else
	{
		commandToServer('STW_Clan_LoadSettings');
	}
}

function STW_ClanDlg::saveSettings(%this)
{
	%team = $STW::GUI::Clan::Settings::Team;
	%ff = $STW::GUI::Clan::Settings::FriendlyFire;
	%bank = $STW::GUI::Clan::Settings::Bank;
	%upgrades = $STW::GUI::Clan::Settings::Upgrades;
	%admins = $STW::GUI::Clan::Settings::Admins;
	%cas = $STW::GUI::Clan::Settings::CAS;
	STW_ClanDlg_Settings.setVisible(0);
	commandToServer('STW_Clan_UpdateSettings',%team,%ff,%bank,%upgrades,%admins,%cas);
}

//----------------------------------------//
//                                        //
//            CLIENT COMMANDS             //
//                                        //
//----------------------------------------//

function clientCmdSTW_failureClanCheck(%title,%message)
{
	STW_YesNoDlg_YES.command = "STWGUI_Page_ClanCreate.setVisible(1);STWGUI.populateCCDivs();STWGUI.populateCCColors();STW_YesNoDlg.NOPush();";
	STW_YesNoDlg_NO.command = "STW_YesNoDlg.NOPush();";
	STW_YesNoFrame.setValue(%title);
	STW_YesNoText.setValue(%message);
	canvas.pushDialog(STW_YesNoDlg);
}

function clientCmdSTW_successClanCheck()
{
	STW_ClanDlg.open();
}

function clientCmdSTW_CCFailure(%title,%message)
{
	STW_YesNoDlg_YES.command = "STWGUI.clearCCFields();STW_YesNoDlg.NOPush();STWGUI.populateCCDivs();STWGUI.populateCCColors();";
	STW_YesNoDlg_NO.command = "STWGUI.clearCCFields();STWGUI.closePages();STW_YesNoDlg.NOPush();";
	STW_YesNoFrame.setValue(%title);
	STW_YesNoText.setValue(%message);
	canvas.pushDialog(STW_YesNoDlg);
}

function clientCmdSTW_CCSuccess(%title,%message)
{
	STWGUI.clearCCFields();
	STWGUI.closePages();
	STW_OKDlg_Frame.setValue(%title);
	STW_OKDlg_Text.setValue(%message);
	canvas.pushDialog(STW_OKDlg);
}

function clientCmdSTW_updateClanSettings(%check,%name,%div,%color,%team,%ff,%bank,%upgrades,%admins,%cas)
{
	if(%check)
	{
		$STW::GUI::Clan::Settings::Name = %name;
		$STW::GUI::Clan::Settings::Division = %div;
		$STW::GUI::Clan::Settings::Color = %color;
		$STW::GUI::Clan::Settings::Team = %team;
		$STW::GUI::Clan::Settings::FriendlyFire = %ff;
		$STW::GUI::Clan::Settings::Bank = %bank;
		$STW::GUI::Clan::Settings::Upgrades = %upgrades;
		$STW::GUI::Clan::Settings::Admins = %admins;
		$STW::GUI::Clan::Settings::CAS = %cas;
	}
	else
	{
		commandToServer('STW_loadClanSettings');
	}
}

function clientCmdSTW_getClanMembers(%check,%members)
{
	if(%check)
	{
		STW_ClanDlg.populateClanPlayerList(1,%members);
	}
	else
	{
		commandToServer('STW_sendClanMembers');
	}
}