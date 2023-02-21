//-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-//
//|                                                                   |//
//|    There are a few parsers in this file, please read carefully    |//
//|                                                                   |//
//| #1) charLimParse - string, character - returns string | Desc.     |//
//|	  This is a parser in which detects a specified character in a    |//
//|   string to stop reading the string directly when it reads the    |//
//|    specified character and returns what's left of the string      |//
//|                                                                   |//
//|     Example: charLimParse("Blah*stupid","*"); - returns Blah      |//
//|                                                                   |//
//| #2) charLimIntParse - string, character, integer - returns string |//
//|  Desc. This is a parser in which works like charLimParse but it   |//
//|  stops reading the string when it reads a certain amount of the   |//
//|                 specified character in the string                 |//
//|                                                                   |//
//|   Example: charLimIntParse("Blah*stupid*blah","*",2); - returns   |//
//|                            Blah*stupid                            |//
//|                                                                   |//
//|                 Made by Lt. Jamergaman BLID 23108                 |//
//|                                                                   |//
//-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-//

//usage: charLimParse(string, character) - return string
function charLimParse(%string,%char)
{
	//%chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890-=!@#$%^&*()_+[]\;',./{}|:\"<>?";
	for(%i = 0; %i <= strLen(%string); %i++)
	{
		if(getSubStr(%string,%i,1) $= %char)
		{
			return %laststring;
		}
		else
		{
			%laststring = %laststring @ getSubStr(%string,%i,1);
		}
	}
}

//usage: charLimParseInt(string, character, int) - return string
function charLimIntParse(%string,%char,%int)
{
	%a = 0;
	//%chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890-=!@#$%^&*()_+[]\;',./{}|:\"<>?";
	for(%i = 0; %i <= strLen(%string); %i++)
	{
		if(getSubStr(%string,%i,1) $= %char)
		{
			%a++;
			if(%a >= %int)
			{
				return %laststring;
			}
			else
			{
				%laststring = %laststring @ getSubStr(%string,%i,1);
			}
		}
		else
		{
			%laststring = %laststring @ getSubStr(%string,%i,1);
		}
	}
}