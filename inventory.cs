function STWGUI::openInventory(%this)
{
	clientCmdSTW_getInventory();
	STWGUI_Page_Inventory.setVisible(1);
}

function STWGUI::closeInventory(%this)
{
}

function clientCmdSTW_getInventory(%check,%itemData,%name,%damage,%maxammo,%value,%slot)
{
	if(%check)
	{
		%slot = "STWGUI_Inventory_Slot" @ %slot;
		
		if(%name $= "Empty")
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
		commandToServer('STW_sendInventory');
	}
}

function STWGUI::selectInvSlot(%this,%slot)
{
	if($STW::GUI::InventorySystem::SelectedBackSlot !$= "")
	{
		$STW::GUI::InventorySystem::SelectedBackSlot.setColor("255 255 255 255");
		$STW::GUI::InventorySystem::SelectedBackSlot = "";
	}
	if($STW::GUI::InventorySystem::SelectedSlot !$= "")
	{
		$STW::GUI::InventorySystem::SelectedSlot = "";
	}
	if($STW::GUI::InventorySystem::SelectedSlotNum !$= "")
	{
		$STW::GUI::InventorySystem::selectedSlotNum = "";
	}
	
	$STW::GUI::InventorySystem::SelectedSlotNum = %slot;
	%invslot = "STWGUI_Inventory_Slot" @ %slot;
	$STW::GUI::InventorySystem::SelectedSlot = %invslot;
	%backSlot = "STWGUI_Inventory_Slot" @ %slot @ "_Back";
	$STW::GUI::InventorySystem::SelectedBackSlot = %backSlot;
	%backSlot.setColor("105 255 105 255");
	
	%itemData = %invslot.weaponData;
	%itemName = %invslot.weaponName;
	%itemDamage = %invslot.weaponDamage;
	%itemMaxAmmo = %invslot.weaponMaxAmmo;
	%itemValue = %invslot.weaponValue;
	
	STWGUI_Inventory_WD_Name.setValue("Name: "@%itemName);
	STWGUI_Inventory_WD_Damage.setValue("Damage: "@%itemDamage);
	STWGUI_Inventory_WD_ClipSize.setValue("Clip Size: "@%itemMaxAmmo);
}