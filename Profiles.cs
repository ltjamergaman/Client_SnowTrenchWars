if(isObject(STWWindowProfile))
{
	STWWindowProfile.delete();
}
if(isObject(STWScrollProfile))
{
	STWScrollProfile.delete();
}
if(isObject(STWProgressProfile))
{
	STWProgressProfile.delete();
}
if(isObject(STWHealthBarProfile))
{
	STWHealthBarProfile.delete();
}
if(isObject(STWArmorBarProfile))
{
	STWArmorBarProfile.delete();
}
if(isObject(STWEXPBarProfile))
{
	STWEXPBarProfile.delete();
}
if(isObject(STWCheckBoxProfile))
{
	STWCheckBoxProfile.delete();
}

//--- OBJECT WRITE BEGIN ---
new GuiControlProfile(STWWindowProfile) {
   tab = "0";
   canKeyFocus = "0";
   mouseOverSelected = "0";
   modal = "1";
   opaque = "1";
   fillColor = "175 175 175 255";
   fillColorHL = "200 200 200 255";
   fillColorNA = "200 200 200 255";
   border = "1";
   borderThickness = "1";
   borderColor = "0 0 0 255";
   borderColorHL = "128 128 128 255";
   borderColorNA = "64 64 64 255";
   fontType = "Arial Black";
   fontSize = "18";
   fontColors[0] = "255 255 255 255";
   fontColors[1] = "255 255 255 255";
   fontColors[2] = "0 0 0 255";
   fontColors[3] = "200 200 200 255";
   fontColors[4] = "0 0 204 255";
   fontColors[5] = "85 26 139 255";
   fontColors[6] = "0 0 0 0";
   fontColors[7] = "0 0 0 0";
   fontColors[8] = "0 0 0 0";
   fontColors[9] = "0 0 0 0";
   fontColor = "0 0 0 255";
   fontColorHL = "255 255 255 255";
   fontColorNA = "0 0 0 255";
   fontColorSEL = "200 200 200 255";
   fontColorLink = "0 0 204 255";
   fontColorLinkHL = "85 26 139 255";
   doFontOutline = "0";
   fontOutlineColor = "255 255 255 255";
   justify = "left";
   textOffset = "5 2";
   autoSizeWidth = "0";
   autoSizeHeight = "0";
   returnTab = "0";
   numbersOnly = "0";
   cursorColor = "0 0 0 255";
   bitmap = "Add-ons/Client_SnowTrenchWars/UI/GUI Images/STWBlockWindow";
      hasBitmapArray = "1";
      text = "STWWindowCtrl test";
};
//--- OBJECT WRITE END ---

//--- OBJECT WRITE BEGIN ---
new GuiControlProfile(STWScrollProfile) {
   tab = "0";
   canKeyFocus = "0";
   mouseOverSelected = "0";
   modal = "1";
   opaque = "1";
   fillColor = "255 255 255 255";
   fillColorHL = "171 171 171 255";
   fillColorNA = "171 171 171 255";
   border = "1";
   borderThickness = "1";
   borderColor = "0 0 0 255";
   borderColorHL = "128 128 128 255";
   borderColorNA = "64 64 64 255";
   fontType = "Arial";
   fontSize = "14";
   fontColors[0] = "0 0 0 255";
   fontColors[1] = "32 100 100 255";
   fontColors[2] = "0 0 0 255";
   fontColors[3] = "200 200 200 255";
   fontColors[4] = "0 0 204 255";
   fontColors[5] = "85 26 139 255";
   fontColors[6] = "0 0 0 0";
   fontColors[7] = "0 0 0 0";
   fontColors[8] = "0 0 0 0";
   fontColors[9] = "0 0 0 0";
   fontColor = "0 0 0 255";
   fontColorHL = "32 100 100 255";
   fontColorNA = "0 0 0 255";
   fontColorSEL = "200 200 200 255";
   fontColorLink = "0 0 204 255";
   fontColorLinkHL = "85 26 139 255";
   doFontOutline = "0";
   fontOutlineColor = "255 255 255 255";
   justify = "left";
   textOffset = "0 0";
   autoSizeWidth = "0";
   autoSizeHeight = "0";
   returnTab = "0";
   numbersOnly = "0";
   cursorColor = "0 0 0 255";
   bitmap = "Add-ons/Client_SnowTrenchWars/UI/GUI Images/STWBlockScroll";
      hasBitmapArray = "1";
};
//--- OBJECT WRITE END ---

//--- OBJECT WRITE BEGIN ---
new GuiControlProfile(STWProgressProfile) {
   tab = "1";
   canKeyFocus = "0";
   mouseOverSelected = "0";
   modal = "1";
   opaque = "0";
   fillColor = "25 25 255 255";
   fillColorHL = "255 255 255 255";
   fillColorNA = "255 200 255 255";
   border = "1";
   borderThickness = "1.5";
   borderColor = "255 255 255 255";
   borderColorHL = "128 128 128 255";
   borderColorNA = "64 64 64 255";
   fontType = "Arial";
   fontSize = "14";
   fontColors[0] = "0 0 0 255";
   fontColors[1] = "32 100 100 255";
   fontColors[2] = "0 0 0 255";
   fontColors[3] = "200 200 200 255";
   fontColors[4] = "0 0 204 255";
   fontColors[5] = "85 26 139 255";
   fontColors[6] = "0 0 0 0";
   fontColors[7] = "0 0 0 0";
   fontColors[8] = "0 0 0 0";
   fontColors[9] = "0 0 0 0";
   fontColor = "0 0 0 255";
   fontColorHL = "32 100 100 255";
   fontColorNA = "0 0 0 255";
   fontColorSEL = "200 200 200 255";
   fontColorLink = "0 0 204 255";
   fontColorLinkHL = "85 26 139 255";
   doFontOutline = "0";
   fontOutlineColor = "255 255 255 255";
   justify = "left";
   textOffset = "0 0";
   autoSizeWidth = "0";
   autoSizeHeight = "0";
   returnTab = "0";
   numbersOnly = "0";
   cursorColor = "0 0 0 255";
   bitmap = "Add-ons/Client_SnowTrenchWars/UI/GUI Images/STWBlockWindow";
};
//--- OBJECT WRITE END ---

//--- OBJECT WRITE BEGIN ---
new GuiControlProfile(STWHealthBarProfile) {
   tab = "1";
   canKeyFocus = "0";
   mouseOverSelected = "0";
   modal = "1";
   opaque = "0";
   fillColor = "255 0 0 255";
   fillColorHL = "255 255 255 255";
   fillColorNA = "255 200 255 255";
   border = "1";
   borderThickness = "1.5";
   borderColor = "255 255 255 255";
   borderColorHL = "128 128 128 255";
   borderColorNA = "64 64 64 255";
   fontType = "Arial";
   fontSize = "14";
   fontColors[0] = "0 0 0 255";
   fontColors[1] = "32 100 100 255";
   fontColors[2] = "0 0 0 255";
   fontColors[3] = "200 200 200 255";
   fontColors[4] = "0 0 204 255";
   fontColors[5] = "85 26 139 255";
   fontColors[6] = "0 0 0 0";
   fontColors[7] = "0 0 0 0";
   fontColors[8] = "0 0 0 0";
   fontColors[9] = "0 0 0 0";
   fontColor = "0 0 0 255";
   fontColorHL = "32 100 100 255";
   fontColorNA = "0 0 0 255";
   fontColorSEL = "200 200 200 255";
   fontColorLink = "0 0 204 255";
   fontColorLinkHL = "85 26 139 255";
   doFontOutline = "0";
   fontOutlineColor = "255 255 255 255";
   justify = "left";
   textOffset = "0 0";
   autoSizeWidth = "0";
   autoSizeHeight = "0";
   returnTab = "0";
   numbersOnly = "0";
   cursorColor = "0 0 0 255";
   bitmap = "Add-ons/Client_SnowTrenchWars/UI/GUI Images/STWBlockWindow";
};
//--- OBJECT WRITE END ---

//--- OBJECT WRITE BEGIN ---
new GuiControlProfile(STWArmorBarProfile) {
   tab = "1";
   canKeyFocus = "0";
   mouseOverSelected = "0";
   modal = "1";
   opaque = "0";
   fillColor = "0 255 0 255";
   fillColorHL = "255 255 255 255";
   fillColorNA = "255 200 255 255";
   border = "1";
   borderThickness = "1.5";
   borderColor = "255 255 255 255";
   borderColorHL = "128 128 128 255";
   borderColorNA = "64 64 64 255";
   fontType = "Arial";
   fontSize = "14";
   fontColors[0] = "0 0 0 255";
   fontColors[1] = "32 100 100 255";
   fontColors[2] = "0 0 0 255";
   fontColors[3] = "200 200 200 255";
   fontColors[4] = "0 0 204 255";
   fontColors[5] = "85 26 139 255";
   fontColors[6] = "0 0 0 0";
   fontColors[7] = "0 0 0 0";
   fontColors[8] = "0 0 0 0";
   fontColors[9] = "0 0 0 0";
   fontColor = "0 0 0 255";
   fontColorHL = "32 100 100 255";
   fontColorNA = "0 0 0 255";
   fontColorSEL = "200 200 200 255";
   fontColorLink = "0 0 204 255";
   fontColorLinkHL = "85 26 139 255";
   doFontOutline = "0";
   fontOutlineColor = "255 255 255 255";
   justify = "left";
   textOffset = "0 0";
   autoSizeWidth = "0";
   autoSizeHeight = "0";
   returnTab = "0";
   numbersOnly = "0";
   cursorColor = "0 0 0 255";
   bitmap = "Add-ons/Client_SnowTrenchWars/UI/GUI Images/STWBlockWindow";
};
//--- OBJECT WRITE END ---

//--- OBJECT WRITE BEGIN ---
new GuiControlProfile(STWEXPBarProfile) {
   tab = "1";
   canKeyFocus = "0";
   mouseOverSelected = "0";
   modal = "1";
   opaque = "0";
   fillColor = "255 255 0 255";
   fillColorHL = "255 255 255 255";
   fillColorNA = "255 200 255 255";
   border = "1";
   borderThickness = "1.5";
   borderColor = "255 255 255 255";
   borderColorHL = "128 128 128 255";
   borderColorNA = "64 64 64 255";
   fontType = "Arial";
   fontSize = "14";
   fontColors[0] = "0 0 0 255";
   fontColors[1] = "32 100 100 255";
   fontColors[2] = "0 0 0 255";
   fontColors[3] = "200 200 200 255";
   fontColors[4] = "0 0 204 255";
   fontColors[5] = "85 26 139 255";
   fontColors[6] = "0 0 0 0";
   fontColors[7] = "0 0 0 0";
   fontColors[8] = "0 0 0 0";
   fontColors[9] = "0 0 0 0";
   fontColor = "0 0 0 255";
   fontColorHL = "32 100 100 255";
   fontColorNA = "0 0 0 255";
   fontColorSEL = "200 200 200 255";
   fontColorLink = "0 0 204 255";
   fontColorLinkHL = "85 26 139 255";
   doFontOutline = "0";
   fontOutlineColor = "255 255 255 255";
   justify = "left";
   textOffset = "0 0";
   autoSizeWidth = "0";
   autoSizeHeight = "0";
   returnTab = "0";
   numbersOnly = "0";
   cursorColor = "0 0 0 255";
   bitmap = "Add-ons/Client_SnowTrenchWars/UI/GUI Images/STWBlockWindow";
};
//--- OBJECT WRITE END ---

//--- OBJECT WRITE BEGIN ---
new GuiControlProfile(STWCheckBoxProfile) {
   tab = "0";
   canKeyFocus = "0";
   mouseOverSelected = "0";
   modal = "1";
   opaque = "0";
   fillColor = "232 232 232 255";
   fillColorHL = "200 200 200 255";
   fillColorNA = "200 200 200 255";
   border = "1";
   borderThickness = "1";
   borderColor = "0 0 0 255";
   borderColorHL = "128 128 128 255";
   borderColorNA = "64 64 64 255";
   fontType = "Arial";
   fontSize = "14";
   fontColors[0] = "0 0 0 255";
   fontColors[1] = "32 100 100 255";
   fontColors[2] = "0 0 0 255";
   fontColors[3] = "200 200 200 255";
   fontColors[4] = "0 0 204 255";
   fontColors[5] = "85 26 139 255";
   fontColors[6] = "0 0 0 0";
   fontColors[7] = "0 0 0 0";
   fontColors[8] = "0 0 0 0";
   fontColors[9] = "0 0 0 0";
   fontColor = "0 0 0 255";
   fontColorHL = "32 100 100 255";
   fontColorNA = "0 0 0 255";
   fontColorSEL = "200 200 200 255";
   fontColorLink = "0 0 204 255";
   fontColorLinkHL = "85 26 139 255";
   doFontOutline = "1";
   fontOutlineColor = "255 255 255 255";
   justify = "left";
   textOffset = "0 0";
   autoSizeWidth = "0";
   autoSizeHeight = "0";
   returnTab = "0";
   numbersOnly = "0";
   cursorColor = "0 0 0 255";
   bitmap = "Add-ons/Client_SnowTrenchWars/UI/GUI Images/STW_torqueCheck";
      fixedExtent = "1";
      hasBitmapArray = "1";
};
//--- OBJECT WRITE END ---
