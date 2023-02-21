//////////////////////////////////||\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
//|----------------------------------------------------------------|\\
//|   /-------------/ |------------------| |---|    |---|    |---| |\\
//|  /             /  |                  | |   |    |   |    |   | |\\
//| |   |---------/   |------|    |------| |   |    |   |    |   | |\\
//|  \   \                   |    |        |   |    |   |    |   | |\\
//|    \   \                 |    |        |   |    |   |    |   | |\\
//|      \   \               |    |        |   |    |   |    |   | |\\
//|        \   \             |    |        |   |    |   |    |   | |\\
//| 	     \   \           |    |        |   |    |   |    |   | |\\
//| 		   \   \         |    |         \   \   |   |   /   /  |\\
//|   /---------|  |         |    |          \   |--|   |--|   /   |\\
//|  /            /          |    |           \               /    |\\
//| /------------/           |----|            \-------------/     |\\
//|----------------------------------------------------------------|\\
//|                    All GUI(s) Functionality                    |\\
//|----------------------------------------------------------------|\\
//////////////////////////////////||\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

//=======================================================//
//                                                       //
//                    Client Commands                    //
//                 STW GUI Functionality                 //
//                                                       //
//=======================================================//

//========================\\
//                         \\
//Button Tags               //
//                         //
//========================//

function clientCmdSTW_NewTagDelete(%obj)
{
}

function clientCmdSTW_NewTagAdd(%obj,%pos,%ext)
{
}

//========================\\
//                         \\
//Notifications             //
//                         //
//========================//

function clientCmdSTW_OKDlgNotify(%title,%message)
{
	STW_OKDlg.open(%title,%message);
}

function clientCmdSTW_YesNoDlgNotify(%title,%message)
{
	STW_YesNoDlg.open(%title,%message);
}

function clientCmdSTW_OKCancelDlgNotify(%title,%message)
{
	STW_OKCancelDlg.open(%title,%message);
}

////////////////////////////////////////////////////

function STWGUI::clearStats(%this)
{
	STWGUI_Stats_Level.setValue("<font:Lucida Console:14>Level: <color:FFFF00>N/A");
	STWGUI_Stats_Rank.setValue("<font:Lucida Console:14>Rank: <color:FFFF00>N/A");
	STWGUI_Stats_EXP.setValue("<font:Lucida Console:14>EXP: <color:FFFF00>N/A");
	STWGUI_Stats_CPs.setValue("<font:Lucida Console:14>CP(s): <color:FFFF00>N/A");
	STWGUI_Stats_Money.setValue("<font:Lucida Console:14>Money: <color:FFFF00>N/A");
	STWGUI_Stats_Armor.setValue("<font:Lucida Console:14><color:00FFFF>Armor<color:FFFFFF>: N/A");
	STWGUI_Stats_PlayerType.setValue("<font:Lucida Console:14><color:FF00FF>Player<color:FFFFFF>: N/A");
	STWGUI_Stats_Name.setValue("<font:Lucida Console:17><color:FF0000>STW[OS]");
}
	
function STWGUI::openDTPBox(%this)
{
	if(STW_DTPGUI.isAwake())
	{
		return canvas.popDialog(STW_DTPGUI);
	}
	
	$STW::GUI::DTP::Money = "100";
	STW_DTPGUI_UserName.setValue("");
	canvas.pushDialog(STW_DTPGUI);
}

function STWGUI::openClanBox(%this,%check)
{
	if(STW_ClanDlg.isAwake())
	{
		return canvas.popDialog(STW_ClanDlg);
	}
	
	if(%check == 1)
	{
		STW_ClanDlg.open();
	}
	else if(%check !$= "" && %check == 0)
	{
		clientCmdSTW_YesNoDlgNotify("Clan Access Denied","Do you want to create a clan?");
	}
	else if(%check $= "")
	{
		commandToServer('STW_checkIsInClan');
	}
}

function STWGUI::createClan(%this,%name,%div,%color,%vars)
{
	%CIAT = getWord(%vars,0);
	%FF = getWord(%vars,1);
	%Bank = getWord(%vars,2);
	%Upgrades = getWord(%vars,3);
	%Admins = getWord(%vars,4);
	%CAS = getWord(%vars,5);
	
	%name = trim(%name);
	
	commandToServer('STW_Clan_Create',%name,%div,%color,%vars);
}

function STWGUI::getCCOptions(%this)
{
	%CIAT = $STW::GUI::CC::CIAT;
	%FF = $STW::GUI::CC::FriendlyFire;
	%Bank = $STW::GUI::CC::Bank;
	%Upgrades = $STW::GUI::CC::Upgrades;
	%Admins = $STW::GUI::CC::Admins;
	%CAS = $STW::GUI::CC::CAS;
	
	%options = %CIAT SPC %FF SPC %Bank SPC %Upgrades SPC %Admins SPC %CAS;
	return %options;
}

function STWGUI::clearCCFields(%this)
{
	STWGUI_CC_Div.clear();
	STWGUI_CC_Color.clear();
	STWGUI_CC_Name.setValue("");
	$STW::GUI::CC::CIAT = 0;
	$STW::GUI::CC::FriendlyFire = 0;
	$STW::GUI::CC::Bank = 0;
	$STW::GUI::CC::Upgrades = 0;
	$STW::GUI::CC::Admins = 0;
	$STW::GUI::CC::CAS = 0;
}

function STWGUI::openRankUpDlg(%this)
{
	if(STWGUI_RankUpDlg.visible == 1)
	{
		return STWGUI_RankUpDlg.visible = 0;
	}
	
	STWGUI_RankUpDlg_Text.setValue("<just:center><font:MS Sans:14>Ranking Up resets your Inventory, Tool Slots, Money, Level & EXP.<br><br>Your Upgrades, Armor, Captured Points, Total EXP/Score, & Researched Items stay unaffected.");
	STWGUI_RankUpDlg.pane = 1;
	STWGUI_RankUpDlg.setVisible(1);
}

function STWGUI::rankUpContinue(%this)
{
	clientCmdSTW_GetClientStats();
	
	if(STWGUI_RankUpDlg.pane == 1)
	{
		STWGUI_RankUpDlg_Text.setValue("<just:center><font:MS Sans:14>Are you sure you want to?");
		STWGUI_RankUpDlg.pane = 2;
	}
	else if(STWGUI_RankUpDlg.pane == 2)
	{
		clientCmdSTW_RankUp();
		
		STWGUI_RankUpDlg.pane = 1;
		STWGUI_RankUpDlg.setVisible(0);
		STWGUI_RankupDlg_Text.setValue("<just:center><font:MS Sans:14>Ranking Up resets your Inventory, Tool Slots, Money, Level & EXP.<br><br>Your Upgrades, Armor, Captured Points, Total EXP/Score, & Researched Items stay unaffected.");
	}
}

function STWGUI::populateCCDivs(%this)
{
	STWGUI_CC_Div.clear();
	
	for(%i = 2; %i < 100; %i++)
	{
		%div = %i;
		STWGUI_CC_Div.addFront(%i,%i,0);
	}
}

function STWGUI::populateCCColors(%this)
{
	STWGUI_CC_Color.clear();
	
	for(%i = 0; %i < 9; %i++)
	{
		%color = %i;
		STWGUI_CC_Color.addFront(%i,%i,0);
	}
}

function STW_OKDlg::open(%this,%title,%message)
{
	STW_OKDlg_Frame.setValue(%title);
	STW_OKDlg_Text.setValue(%message);
	canvas.pushDialog(%this);
}

function STW_OKDlg::close(%this)
{
	STW_OKDlg_Frame.setValue("");
	STW_OKDlg_Text.setValue("");
	canvas.popDialog(%this);
}

function STW_YesNoDlg::open(%this,%title,%message)
{
	STW_YesNoFrame.setValue(%title);
	STW_YesNoText.setValue(%message);
	canvas.pushDialog(%this);
}

function STW_YesNoDlg::close(%this)
{
	STW_YesNoFrame.setValue("");
	STW_YesNoText.setValue("");
	canvas.popDialog(%this);
}

function STW_YesNoDlg::NoPush(%this)
{
	STW_YesNoFrame.setValue("");
	STW_YesNoText.setValue("");
	canvas.popDialog(%this);
}

function STW_OKCancelDlg::OKPush(%this)
{
	STW_OKCancelFrame.setValue("");
	STW_OKCancelText.setValue("");
	canvas.popDialog(%this);
}

function STW_OKCancelDlg::CancelPush(%this)
{
	STW_OKCancelFrame.setValue("");
	STW_OKCancelText.setValue("");
	canvas.popDialog(%this);
}

//--------------------//
//                    //
//HELP PAGE FUNCT.    //
//                    //
//--------------------//

function STWGUI::openHelpPage(%this,%pageNum)
{
	%this.closeHelpPages();
	
	if(%pageNum == 1)
	{
		STWGUI_Help_Inventory.setVisible(1);
	}
	if(%pageNum == 2)
	{
		STWGUI_Help_Store.setVisible(1);
	}
	if(%pageNum == 3)
	{
		STWGUI_Help_Gameplay.setVisible(1);
	}
	if(%pageNum == 4)
	{
		STWGUI_Help_Administration.setVisible(1);
	}
	if(%pageNum == 5)
	{
		STWGUI_Help_Stats.setVisible(1);
	}
	if(%pageNum == 6)
	{
		STWGUI_Help_Clans.setVisible(1);
	}
	if(%pageNum == 7)
	{
		STWGUI_Help_Rules.setVisible(1);
	}
}

function STWGUI::closeHelpPages(%this)
{
	STWGUI_Help_Inventory.setVisible(0);
	STWGUI_Help_Store.setVisible(0);
	STWGUI_Help_Gameplay.setVisible(0);
	STWGUI_Help_Administration.setVisible(0);
	STWGUI_Help_Stats.setVisible(0);
	STWGUI_Help_Clans.setVisible(0);
	STWGUI_Help_Rules.setVisible(0);
}

function STWGUI::openSuggestIndex(%this)
{
	%this.closeSuggestIndex();
	STWGUI_Page_PostSuggestion.setVisible(1);
}

function STWGUI::openReportIndex(%this)
{
	%this.closeReportIndex();
	STWGUI_Page_PostReport.setVisible(1);
}

function STWGUI::closeSuggestIndex(%this)
{
	%count = STWGUI_Page_PostSuggestion.getCount();
	
	STWGUI.clearRSFields();
	
	STWGUI.closePages();
}

function STWGUI::closeReportIndex(%this)
{
	%count = STWGUI_Page_PostReport.getCount();
	
	STWGUI.clearRSFields();
	
	STWGUI.closePages();
}

function STWGUI::selectReportSubject(%this,%num)
{
	switch$(%num)
	{
		case 1:
		$STW::GUI::Reporting::Subject = "Admin Abuse";
		
		case 2:
		$STW::GUI::Reporting::Subject = "Exploiting";
		
		case 3:
		$STW::GUI::Reporting::Subject = "Cheating";
		
		case 4:
		$STW::GUI::Reporting::Subject = "Spamming";
		
		case 5:
		$STW::GUI::Reporting::Subject = "Other";
	}
}

function STWGUI::submitReportPost(%this)
{
	%subject = $STW::GUI::Reporting::Subject;
	%userID = STWGUI_Page_PostReport_NameIDText.getValue();
	%comment = STWGUI_Page_PostReport_CommentText.getValue();
	%otherText = STWGUI_Page_PostReport_OtherText.getValue();
	STWGUI.clearRSFields();
	
	commandToServer('STW_makeReport',%subject,%userID,%comment,%otherText);
}

function STWGUI::selectSuggestionSubject(%this,%num)
{
	switch$(%num)
	{
		case 1:
		$STW::GUI::Suggesting::Subject = "New Feature(s)";
		
		case 2:
		$STW::GUI::Suggesting::Subject = "New Weapon(s)";
		
		case 3:
		$STW::GUI::Suggesting::Subject = "New Interface";
		
		case 4:
		$STW::GUI::Suggesting::Subject = "Spamming";
		
		case 5:
		$STW::GUI::Suggesting::Subject = "Other";
	}
}

function STWGUI::submitSuggestionPost(%this)
{
	%subject = $STW::GUI::Suggesting::Subject;
	%comment = STWGUI_Page_PostSuggestion_CommentText.getValue();
	%otherText = STWGUI_Page_PostSuggestion_OtherText.getValue();
	STWGUI.clearRSFields();
	
	commandToServer('STW_makeSuggestion',%subject,%comment,%othertext);
}

function STWGUI::clearRSFields(%this)
{
	for(%i = 0; %i < %count; %i++)
	{
		%obj = STWGUI_Page_PostReport.getObject(%i);
		
		if(%obj.profile $= "GuiRadioProfile")
		{
			%obj.setValue(0);
		}
	}
	
	STWGUI_Page_PostReport_OtherText.setValue("");
	STWGUI_Page_PostReport_CommentText.setValue("");
	STWGUI_Page_PostReport_NameIDText.setValue("");
	
	//
	
	for(%i = 0; %i < %count; %i++)
	{
		%obj = STWGUI_Page_PostSuggestion.getObject(%i);
		
		if(%obj.profile $= "GuiRadioProfile")
		{
			%obj.setValue(0);
		}
	}
	
	STWGUI_Page_PostSuggestion_OtherText.setValue("");
	STWGUI_Page_PostSuggestion_CommentText.setValue("");
}