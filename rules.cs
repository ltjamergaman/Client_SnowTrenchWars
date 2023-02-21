//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-//
//--  WARNING  ------  WARNING  --//
//                                //
//  THESE ARE FUNCTIONS USED FOR  //
//  THE CLIENT-SIDED RULE         //
//    MODIFICATION USAGE          //
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

function clientCmdSTW_populateRulesList(%check,%rule,%i)
{
	if(%check)
	{
		STWGUI.populateRulesList(%rule,%i);
	}
	else
	{
		STWGUI_Rules_List.clear();
		commandToServer('STW_sendRulesList');
	}
}

function STWGUI::populateRulesList(%this,%rule,%i)
{
	%obj = STWGUI_Rules_List;
	%obj.addRow(%i,%rule);
}

function STWGUI::openRuleWindow(%this)
{
	STWGUI_Rules_Window.setVisible(1);
	STWGUI_Rules_Window_Text.setValue("");
}

function STWGUI::closeRuleWindow(%this)
{
	STWGUI_Rules_Window_Text.setValue("");
	STWGUI_Rules_Window.setVisible(0);
}

function STWGUI::removeRule(%this,%row)
{
	commandToServer('STW_removeRule',%row);
}

function STWGUI::modifyRule(%this,%rule)
{
}

function STWGUI::selectRule(%this)
{
	$STW::GUI::Ruling::SelectedRule = getWord(STWGUI_Rules_List.getRowTextByID(STWGUI_Rules_List.getSelectedID),0);	
}