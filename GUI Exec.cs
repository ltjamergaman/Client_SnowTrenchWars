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
//|                           Version: 2                           |\\
//|                               By                               |\\
//|                   Lt. Jamergaman BLID: 23108                   |\\
//|----------------------------------------------------------------|\\
//////////////////////////////////||\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

exec("./GUI Functionality.cs");
exec("./administration.cs");
exec("./clan system.cs");
exec("./Transition Effect.cs");
exec("./rules.cs");

$remapDivision[$remapCount]		= "Snow Trench Wars GUI";
$remapName[$remapCount]			= "Toggle GUI";
$remapCmd[$remapCount]			= "STWGUI_Push";
$remapCount++;

exec("./store.cs");

//==================================\\
//                                   \\
//OPEN INTERFACE KEYBIND FUNCTION     //
//                                   //
//==================================//
function STWGUI_Push(%tog)
{
	if(%tog)
	{
		if(STWGUI.isAwake())
		{
			STWGUI.close();
		}
		else
		{
			STWGUI.open();
		}
	}
}

//=================\\
//                  \\
//OPEN INTERFACE     //
//                  //
//=================//
function STWGUI::open(%this)
{
	if(isObject(STW_HUD) && STW_HUD.visible)
	{
		STW_HUD.setVisible(0);
	}
	
	%this.closePages();
	clientCmdSTW_GetClientStats();
	STWGUI_Stats_Name.setValue("<font:lucida console:17><color:FF0000>"@$Pref::Player::NetName);
	clientCmdSTW_checkAdmin();
	%this.populateCCDivs();
	%this.populateCCColors();
	STWGUI_Store_ItemList.clear();
	canvas.pushDialog(STWGUI);
}

//====================\\
//					   \\
//CLOSE INTERFACE       //
//                     //
//====================//
function STWGUI::close(%this)
{
	if(isObject(STW_HUD) && !STW_HUD.visible)
	{
		STW_HUD.setVisible(1);
	}
	
	%this.closePages();
	%this.clearCCFields();
	%this.clearStats();
	STWGUI_Store_ItemList.clear();
	STWGUI_Rules_List.clear();
	canvas.popDialog(STWGUI);
}

//=======================\\
//                        \\
//OPENING/CLOSING PAGES    //
//                        //
//=======================//
function STWGUI::openPage(%this,%Num)
{
	%this.closePages();
	STWGUI_Page_Opening_TitleText.setVisible(0);
	STWGUI_Page_Opening_LowText.setVisible(0);
	
	if(%Num == 1) //INVENTORY
	{
		%this.openInventory();
	}
	if(%Num == 2) //STORE
	{
		%this.openStore();
	}
	if(%Num == 3) //RULES
	{
		STWGUI_Page_Rules.setVisible(1);
		clientCmdSTW_populateRulesList();
	}
	if(%Num == 4) //SETTINGS
	{
		STWGUI_Page_Settings.setVisible(1);
		%this.loadSTWGUISettings();
	}
	if(%Num == 5) //HELP
	{
		STWGUI_Page_Help.setVisible(1);
		//%this.populateHelpList();
	}
	if(%Num == 6) //CREDITS
	{
		STWGUI_Page_Credits.setVisible(1);
		//%this.populateCreditsList();
	}
	if(%Num == 7) //ADMINISTRATION
	{
		%this.openAdministration();
	}
	if(%Num == 8)
	{
		%this.openSuggestIndex();
	}
	if(%Num == 9)
	{
		%this.openReportIndex();
	}
}

//================\\
//                 \\
//CLOSE PAGES       //
//                 //
//================//
function STWGUI::closePages(%this)
{
	STWGUI_Page_Inventory.setVisible(0);
	if(STWGUI_Page_Store.visible == 1)
	{
		STWGUI.closeStore();
	}
	
	STWGUI_Page_Rules.setVisible(0);
	STWGUI_Rules_List.clear();
	
	if(STWGUI_Page_Settings.visible == 1)
	{
		STWGUI_Page_Settings.saveSTWSettings();
	}
	
	STWGUI_Page_Settings.setVisible(0);
	STWGUI_Page_Help.setVisible(0);
	STWGUI.closeHelpPages();
	STWGUI_Page_Credits.setVisible(0);
	
	if(STWGUI_Page_Administration.visible == 1)
	{
		%this.closeAdministration();
	}
	
	STWGUI_Page_ViewReports.setVisible(0);
	STWGUI_Page_ViewSuggestions.setVisible(0);
	
	STWGUI_Page_ClanCreate.setVisible(0);
	//STWGUI.clearCCFields();
	
	STWGUI_Page_PostSuggestion.setVisible(0);
	STWGUI_Page_PostReport.setVisible(0);
	
	STWGUI_Page_Opening_TitleText.setVisible(1);
	STWGUI_Page_Opening_LowText.setVisible(1);
}