//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-//
//--  WARNING  ------  WARNING  --//
//                                //
//  THESE ARE FUNCTIONS USED FOR  //
//  THE TRANSITION NOTIFICATION   //
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

//function GuiControl::shift(%this,%x,%y) //RTB Function - Credit goes to Ephialtes
//{
	//if(!isFile("Add-ons/System_ReturnToBlockland.zip"))
	//{
	//	%this.position = vectorAdd(%this.position,%x SPC %y);
	//}
	//else
	//{
		//return parent::shift(%this,%x,%y);
	//}
//}

$STW::GUI::TabNotify::HoldTime = 2000; //2 seconds

function clientCmdSTW_TabNotify(%message)
{
	STWGUI.doTabEffect(0,%message);
}

function STWGUI::doTabEffect(%this,%check,%message,%posY)
{
	%res = getWord(getRes(),0) SPC getWord(getRes(),1);
	%width = getWord(%res,0);
	%height = getWord(%res,1);
	%centerPosX = (%width / 2) - 100;
	%startPosY = %height;
	%endPosY = %height - 100;

	if(%check)
	{
		if(!isObject(STW_NotifyTab))
		{
			return;
		}
		if(getWord(STW_NotifyTab.getPosition(),1) <= %endPosY)
		{
			STW_NotifyTab.schedule(3500,"delete");
			return;
		}
		
		STW_NotifyTab.position = getWord(STW_NotifyTab.getPosition(),0) SPC %posY;
		%this.schedule(33,"doTabEffect",1,%message,getWord(STW_NotifyTab.getPosition(),1)-10);
	}
	else
	{
		if(isObject(STW_NotifyTab))
		{
			STW_NotifyTab.delete();
		}

		%maxChars = 47;
		%beginText = "<just:center><color:FFFFFF>";
		%message = %beginText @ %message;
		%textPos = "8 20";
	
		if(strLen(%message) > %maxChars)
		{
			%textPos = "8 10";
		}
	
		new GuiSwatchCtrl(STW_NotifyTab)
		{
			profile = "GuiDefaultProfile";
			horizSizing = "bottom";
			vertSizing = "right";
			position = %centerPosX SPC %startPosY;
			extent = "200 50";
			minExtent = "8 2";
			enabled = "1";
			visible = "1";
			clipToParent = "1";
			color = "50 50 50 175";

				new GuiMLTextCtrl(STW_NotifyTab_Text)
				{
					profile = "GuiMLTextProfile";
					horizSizing = "bottom";
					vertSizing = "right";
					position = %textPos;
					extent = "184 14";
					minExtent = "8 2";
					enabled = "1";
					visible = "1";
					clipToParent = "1";
					lineSpacing = "2";
					allowColorChars = "0";
					maxChars = "-1";
					text = %message;
					maxBitmapHeight = "-1";
					selectable = "1";
					autoResize = "1";
				};
		};
		
		PlayGui.add(STW_NotifyTab);
		%this.schedule(33,"doTabEffect",1,%message,getWord(STW_NotifyTab.getPosition(),1));
	}
}

//- GuiControl::shift (moves a gui in the X or Y)
//function GuiControl::shift(%this,%x,%y)
//{
//   %this.position = vectorAdd(%this.position,%x SPC %y);
//}

//- GuiControl::conditionalShiftY (shifts all controls >= %position by %amount in the Y)
//function GuiControl::conditionalShiftY(%this,%position,%amount)
//{
//   for(%i=0;%i<%this.getCount();%i++)
//   {
//      %control = %this.getObject(%i);
//      if(getWord(%control.position,1) >= %position)
//         %control.shift(0,%amount);
//   }
//}

//- RTBCC_Notification::step (plays a step through the animation)
//function RTBCC_Notification::step(%this)
//{
//   if(%this.state $= "left")
//   {
//      if(getWord(%this.window.position,0) <= 0)
//      {
//         if(%this.holdTime < 0)
//         {
//            %this.window.position = "0 0";
//            %this.state = "done";
//            return;
//         }
//         %this.window.position = "0 0";
//         %this.state = "wait";
//         %this.moveAnim = %this.schedule(%this.holdTime,"step");
//         return;
//      }
//      %this.window.position = vectorSub(%this.window.position,"10 0");
//      %this.moveAnim = %this.schedule(10,"step");
//   }
//   else if(%this.state $= "wait")
//   {
//      %this.state = "right";
//      %this.step();
//   }
//   else if(%this.state $= "right")
//   {
//      if(getWord(%this.window.position,0) >= getWord(%this.canvas.extent,0))
//      {
//         %this.window.position = getWord(%this.canvas.extent,0) SPC "0";
//         %this.state = "done";
//         %this.step();
//         return;
//      }
//      %this.window.position = vectorAdd(%this.window.position,"10 0");
//      %this.moveAnim = %this.schedule(10,"step");
//   }
//   else if(%this.state $= "done")
//   {
//      %y = getWord(%this.canvas.position,1);
//      %this.canvas.delete();
//
//      for(%i=0;%i<RTBCC_NotificationManager.getCount();%i++)
//      {
//         %notification = RTBCC_NotificationManager.getObject(%i);
//         if(!isObject(%notification.canvas))
//            continue;
//         if(getWord(%notification.canvas.position,1) < %y)
//            %notification.canvas.shift(0,50);
//      }
//      %this.delete();
//   }
//}