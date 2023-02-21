function STW_convertStrength(%val,%maxval)
{
	%min = "0";
	%half = "0.5";
	%max = "1";
	//%val = mFloatLength(%val,0);
	//%maxval = mFloatLength(%maxval,0);
	
	if(%val >= %maxval && %maxval != -1 && %val != 0)
	{
		%val = 1;
		return 1;
	}
	else if(%val <= 0)
	{
		%val = 0;
		return 0;
	}
	else
	{
		%val = %val / %maxval;
	}
	
	return %val;
}

function STW_convertEXP(%exp,%reqexp)
{
	%min = "0";
	%half = "0.5";
	%max = "1";
	//%exp = mFloatLength(%exp,0);
	//%reqexp = mFloatLength(%reqexp,0);
	
	if(%exp >= %reqexp)
	{
		%exp = 1;
		return 1;
	}
	else if(%exp <= 0)
	{
		%exp = 0;
		return 0;
	}
	else
	{
		%exp = %exp / %reqexp;
		//%exp = getSubStr(%exp,0,2);
	}
	
	return %exp;
}