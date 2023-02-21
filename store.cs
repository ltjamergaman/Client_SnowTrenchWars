//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-//
//--  WARNING  ------  WARNING  --//
//                                //
//  THESE ARE FUNCTIONS USED FOR  //
//  THE CLIENT-SIDED STORE USAGE  //
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

exec("./inventory.cs");

//--------------\\
//Client Commands \\
//-----------------//

function clientCmdSTW_populateItemList(%category,%check,%item,%value,%itemdata,%i)
{
	if(%check)
	{
		%item = %item TAB %value TAB %itemdata;
		STWGUI.populateItemList(%item,%i);
	}
	else
	{
		STWGUI_Store_ItemList.clear();
		commandToServer('STW_populateItemList',%category);
	}
}

//---------------\\
//Interface Func. \\
//-----------------//

function STWGUI::openStore(%this)
{
	STWGUI_Store_ItemList.clear();
	clientCmdSTW_getToolSlots();
	STWGUI_Page_Store.setVisible(1);
}

function STWGUI::closeStore(%this)
{
	STWGUI_Store_ItemList.clear();
	for(%i = 0; %i < 5; %i++)
	{
		%obj = "STWGUI_Store_Slot" @ %i;
	}
	STWGUI_Page_Store.setVisible(0);
}

function STWGUI::populateItemList(%this,%item,%a)
{
	%obj = STWGUI_Store_ItemList;
	//echo(%item);
	//echo(lastWord(%item));
	//for(%i = 0; %i < %obj.rowCount(); %i++)
	//{
	%obj.addRow(%a,%item);
	//}
}

function STWGUI::buyWeapon(%this)
{
	%obj = STWGUI_Store_ItemList;
	if(%obj.getSelectedID() !$= "")
	{
		%item = getWord(%obj.getRowTextByID(%obj.getSelectedID()),getWordCount(%obj.getRowTextByID(%obj.getSelectedID()))-1);
		commandToServer('STW_buyItem',%item);
	}
}

//===============================================|
//                                               |
//  T O O L  S L O T  F U N C T I O N A L I T Y  |
//                                               |
//   DO NOT MESS WITH-------------------------   |
//===============================================|

function clientCmdSTW_getToolSlots(%check,%itemData,%name,%value,%slot)
{
	if(%check)
	{
		%slot = "STWGUI_Store_Slot" @ %slot;
		
		if(%name $= "Empty" || %name $= "")
		{
			%slot.setBitmap("Add-ons/Client_SnowTrenchWars/UI/Empty");
		}
		else
		{
			%slot.setBitmap("Add-ons/Client_SnowTrenchWars/UI/Items/Icon_" @ %itemData);
		}
		
		%slot.weaponData = %itemData;
		%slot.weaponName = %name;
		%slot.weaponDamage = %damage;
		%slot.weaponMaxAmmo = %maxammo;
		%slot.weaponValue = %value;
	}
	else
	{
		commandToServer('STW_sendToolSlots');
	}
}

function STWGUI::selectToolSlot(%this,%slot)
{
	if($STW::GUI::Store::SelectedBackSlot !$= "")
	{
		$STW::GUI::Store::SelectedBackSlot.setColor("255 255 255 255");
		$STW::GUI::Store::SelectedBackSlot = "";
	}
	if($STW::GUI::Store::SelectedSlot !$= "")
	{
		$STW::GUI::Store::SelectedSlot = "";
	}
	if($STW::GUI::Store::SelectedSlotNum !$= "")
	{
		$STW::GUI::Store::SelectedToolSlotNum = "";
	}
	
	$STW::GUI::Store::SelectedSlotNum = %slot;
	%toolslot = "STWGUI_Store_Slot" @ %slot;
	$STW::GUI::Store::SelectedSlot = %toolslot;
	%backSlot = "STWGUI_Store_Slot" @ %slot @ "_Back";
	$STW::GUI::Store::SelectedBackSlot = %backSlot;
	%backSlot.setColor("105 255 105 255");
	
	%itemData = %toolslot.weaponData;
	%itemName = %toolslot.weaponName;
	%itemDamage = %toolslot.weaponDamage;
	%itemMaxAmmo = %toolslot.weaponMaxAmmo;
	%itemValue = %toolslot.weaponValue;
}