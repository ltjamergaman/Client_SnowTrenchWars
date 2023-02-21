//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-//
//--  WARNING  ------  WARNING  --//
//                                //
//  THESE ARE FUNCTIONS USED FOR  //
//   THE ADMINISTRATION CLIENT    //
//         USAGE                  //
//                                //
//  DO NOT MESS WITH ANY OF THIS  //
//   FUNCTIONALITY BECAUSE YOU    //
//  COULD POSSIBLY FUCK SOMETHING //
//  UP HORRIBLY TO THE POINT OF   //
//   YOU NEEDING TO RE-DOWNLOAD   //
//        THE ADD-ON              //
//                                //
//--  WARNING  ------  WARNING  --//
//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-//

function clientCmdSTW_checkAdmin(%check,%admin)
{
	if(%check)
	{
		$STW::Client::isAdmin = %admin;
	}
	else
	{
		commandToServer('STW_checkAdmin');
	}
}

function STWGUI::openBanGui(%this)
{
	canvas.pushDialog(addBanGui);
	for(%i = 0; %i < addBanGui.getCount(); %i++)
	{
		%obj = addBanGui.getObject(0).getObject(%i);
		if(%obj.getClassName() $= "GuiCheckBoxCtrl")
		{
			%obj.variable = "$STW::GUI::Administration::BanPerm";
		}
		if(%obj.getClassName() $= "GuiBitmapButtonCtrl")
		{
			%obj.command = "STWGUI.banPlayer();";
		}
		return;
	}
}

function STWGUI::openKickGui(%this)
{
	canvas.pushDialog(STW_KickGui);
	STW_KickGui_User.setValue("<just:center><font:impact:16>Kicking:<br><color:FFFF00>"@$STW::GUI::Administration::PLSelected);
}

function STWGUI::openMuteGui(%this)
{
	canvas.pushDialog(STW_MuteGui);
}

function STW_KickGui::kickPlayer(%this)
{
	%user = $STW::GUI::Administration::PLSelected;
	%reason = STW_KickGui_Reason.getValue();
	commandToServer('STW_KickPlayer',%user,%reason);
	canvas.popDialog(STW_KickGui);
}

function STW_MuteGui::mutePlayer(%this)
{
	%user = $STW::GUI::Administration::PLSelected;
	%perm = STW_MuteGui_Perm.getValue();
	%time = STW_MuteGui_Time.getValue();
	
	if(%perm == 1)
	{
		%time = -1;
	}
	
	%time = trim(%time);
	%reason = STW_MuteGui_Reason.getValue();
	commandToServer('Mute',%user,%time,%reason);
	canvas.popDialog(STW_MuteGui);
	STW_MuteGui_Time.setValue(1);
	STW_MuteGui_Reason.setValue("");
	STW_MuteGui_Perm.setValue(0);
	STW_MuteGui_blocker.setVisible(0);
}

function STWGUI::banPlayer(%this)
{
	%day = 1440;
	%hour = 60;
	%minute = 1;
	%perm = -1;
	
	%reason = addBan_Reason.getValue();
	%user = $STW::GUI::Administration::PLSelected;
	%blah = STWGUI_Administration_APL;
	%selrowtext = %blah.getRowTextByID(%blah.getSelectedID());
	%blid = getWord(%selrowtext,getWordCount(%selrowtext)-3);
	%banPerm = $STW::GUI::Administration::BanPerm;
	%banDays = getWord(addBan_Days.getValue(),0);
	%banHours = getWord(addBan_Hours.getValue(),0);
	%banMinutes = getWord(addBan_Minutes.getValue(),0);
	
	if(%banPerm == 1)
	{
		%time = -1;
	}
	else
	{
		if(%banDays > 1)
		{
			%day = %day * %banDays;
		}
		else if(%banDays < 1)
		{
			%day = 0;
		}
		if(%banHours > 1)
		{
			%hour = %hour * %banHours;
		}
		else if(%banHours < 1)
		{
			%hour = 0;
		}
		if(%banMinutes > 1)
		{
			%minute = %minute * %banMinutes;
		}
		else if(%banMinutes < 1)
		{
			%Minute = 0;
		}
		
		%time = %day + %hour + %minute;
	}
	
	commandToServer('ban',%user,%blid,%time,%reason);
	
	canvas.popDialog(addBanGui);
	
	for(%i = 0; %i < addBanGui.getCount(); %i++)
	{
		%obj = addBanGui.getObject(0).getObject(%i);
		
		if(%obj.getClassName() $= "GuiCheckBoxCtrl")
		{
			%obj.variable = "";
		}
		if(%obj.getClassName() $= "GuiBitmapButtonCtrl")
		{
			%obj.command = "addBanGui.ban();";
		}
		
		return;
	}
}

function STWGUI::openAdministration(%this)
{
	clientCmdSTW_checkAdmin();
	
	if($STW::Client::isAdmin > 0)
	{
		STWGUI_Page_Administration.setVisible(1);
		%this.populateAPL();
	}
	else
	{
		%this.closePages();
	}
}

function STWGUI::closeAdministration(%this)
{
	commandToServer('STW_checkAdmin');
	STWGUI_Page_Administration.setVisible(0);
	STWGUI_Administration_APL.clear();
	deleteVariables("$STW::GUI::Administration*");
}

function STWGUI::populateAPL(%this)
{
	%list = NPL_List;
	
    for(%i = 0; %i < %list.RowCount(); %i++)
    {
        %blah = %list.getRowText(%i);
		%blah = getSubStr(%blah,0,StrLen(%blah)-4);
		//echo(%blah);
		//echo(%count);
		//echo(getSubStr(%blah,2,%count-18));
        STWGUI_Administration_APL.addRow(%i,"\c0"@%blah);
    }
}

function STWGUI::clickAPL(%this)
{
	%blah = STWGUI_Administration_APL;
	$STW::GUI::Administration::PLSelected = getWord(%blah.getRowTextByID(%blah.getSelectedID()),1);
	clientCmdSTW_getUserStats();
}

function STW_MuteGui::clickPermanently(%this)
{
	STW_MuteGui_Blocker.setVisible(STW_MuteGui_Perm.getValue());
}

function STWGUI::openWarnBox(%this)
{
	if(STWGUI_WarnBox.visible == 1)
	{
		return STWGUI_WarnBox.visible = 0;
	}
	
	STWGUI_WarnBox_Title.setValue("");
	STWGUI_WarnBox_Message.setValue("");
	STWGUI_WarnBox.user = $STW::GUI::Administration::PLSelected;
	STWGUI_WarnBox.setVisible(1);
}

function STWGUI::sendWarning(%this,%username,%title,%message)
{
	//%username = $STW::GUI::Administration::PLSelected;
	commandToServer('STW_SendWarning',%username,%title,%message);
	STWGUI_WarnBox.setVisible(0);
	STWGUI_WarnBox_Title.setValue("");
	STWGUI_WarnBox_Message.setValue("");
	STWGUI_WarnBox.user = "";
}

function STWGUI::resetPlayer(%this)
{
	if($STW::GUI::Administration::PLSelected !$= "")
	{
		commandToServer('STW_resetPlayer',$STW::GUI::Administration::PLSelected);
	}
}

function clientCmdSTW_getUserStats(%check,%stats)
{
	if(%check)
	{
		%level = getWord(%stats,0);
		%rank = getWord(%stats,1);
		%exp = getWord(%stats,2);
		%cps = getWord(%stats,3);
		%money = getWord(%stats,4);
		%armor = getWord(%stats,5);
		%playertype = getWord(%stats,6);
		%stwid = getWord(%stats,7);
		%bamount = getWord(%stats,8);
		%kamount = getWord(%stats,9);
		%blid = getWord(%stats,10);
	}
	else
	{
		commandToServer('STW_SendUserStats');
	}
}

function STWGUI::viewReports(%this)
{
	STWGUI.clearVRFields();
	STWGUI_Page_ViewReports.setVisible(1);
	clientCmdSTW_populateReports();
}

function STWGUI::viewSuggestions(%this)
{
	STWGUI.clearVSFields();
	STWGUI_Page_ViewSuggestions.setVisible(1);
	clientCmdSTW_populateSuggestions();
}

function STWGUI::closeVRPage(%this)
{
	STWGUI.clearVRFields();
	STWGUI_Page_ViewReports.setVisible(0);
}

function STWGUI::closeVSPage(%this)
{
	STWGUI.clearVSFields();
	STWGUI_Page_ViewSuggestions.setVisible(0);
}

function STWGUI::clearVRFields(%this)
{
}

function STWGUI::clearVSFields(%this)
{
}

function clientCmdSTW_populateReports(%check,%post,%i)
{
	if(%check)
	{
		STWGUI.populateReports(%post,%i);
	}
	else
	{
		STWGUI_Page_ViewReports_PostList.clear();
		commandToServer('STW_sendReportsList');
	}
}

function clientCmdSTW_populateSuggestions(%check,%post,%i)
{
	if(%check)
	{
		STWGUI.populateSuggestions(%post,%i);
	}
	else
	{
		STWGUI_Page_ViewSuggestions_PostList.clear();
		commandToServer('STW_sendSuggestionsList');
	}
}

function STWGUI::populateReports(%this,%post,%i)
{
	%obj = STWGUI_Page_ViewReports_PostList;
	%obj.addRow(%i,%post);
}

function STWGUI::populateSuggestions(%this,%post,%i)
{
	%obj = STWGUI_Page_ViewSuggestions_PostList;
	%obj.addRow(%i,%post);
}