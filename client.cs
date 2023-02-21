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
//|                     Add-On File Version: 2                     |\\
//|                               By                               |\\
//|                   Lt. Jamergaman BLID: 23108                   |\\
//|          Do not modify or (re)distribute this add-on!          |\\
//|                      © 2010 Lt. Jamergaman.                    |\\
//|                                                                |\\
//|                Contact me at: jamerga@yahoo.com                |\\
//|----------------------------------------------------------------|\\
//////////////////////////////////||\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

if(getWord(getRes(),0) < "640" || getWord(getRes(),1) < "480")
{
	messageBoxOK("Window Resolution Error","STW_HUD Configuration ERROR<br>Sorry but your window resolution must be AT LEAST 640 x 480 for the Snow Trench Wars Interface(s) to show correctly on the screen. Please change your resolution then restart Blockland.");
	return;
}	

exec("./parsers/char_limit_parser.cs");
exec("./parsers/stat_conversion.cs");
exec("./hud.cs");
exec("./Profiles.cs");
exec("./Transfer Data Functions.cs");
exec("./GUI/STWGUI.gui");
exec("./GUI/STW_DTPGUI.gui");
exec("./GUI/STW_OKCancelDlg.gui");
exec("./GUI/STW_OKDlg.gui");
exec("./GUI/STW_YesNoDlg.gui");
exec("./GUI/STW_ClanDlg.gui");
exec("./GUI/STW_KickGui.gui");
exec("./GUI/STW_MuteGui.gui");
exec("./GUI/STW_SetPermsGui.gui");
exec("./GUI/STW_HUD.gui");
exec("./GUI Exec.cs");

function clientCmdSTW_CheckForClient(%this)
{
	commandToServer('STW_hasClient',%this);
}

function clientCmdSTW_PlayChatSound()
{
	%ran = getRandom(0,1);
	%sound = "Chat_Beep1 Chat_Beep2";
	alxPlay(getWord(%sound,%ran));
}

//SOUND DATABLOCKS
if(isObject(Chat_Beep1))
{
	Chat_Beep1.delete();
}
if(isObject(Chat_Beep2))
{
	Chat_Beep2.delete();
}

new AudioProfile(Chat_Beep1)
{
	fileName = "Add-Ons/Client_SnowTrenchWars/Sounds/Chat_Beep1.wav";
	description = AudioGui;
	preload = true;
};

new AudioProfile(Chat_Beep2 : Chat_Beep1)
{
	fileName = "Add-Ons/Client_SnowTrenchWars/Sounds/Chat_Beep2.wav";
};

//Chat Beeps
package STW_Chat_Beep
{
	function clientCmdChatMessage(%a,%b,%c,%fmsg,%cp,%name,%cs,%msg)
	{
		clientCmdSTW_PlayChatSound();	
		return parent::clientCmdChatMessage(%a,%b,%c,%fmsg,%cp,%name,%cs,%msg);
	}
};
activatePackage(STW_Chat_Beep);

package STW_ClientConnection
{
	function Gameconnection::onConnectionAccepted(%this)
	{
		return parent::onConnectionAccepted(%this);
	}
	
	function disconnectedCleanup()
	{
		STW_HUD.delete();
		return parent::disconnectedCleanup();
	}
};
activatePackage(STW_ClientConnection);