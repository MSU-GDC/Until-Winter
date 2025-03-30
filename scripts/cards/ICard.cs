using Godot;
using System;

public partial interface ICard
{
	public string GetName();
	public string GetDescription();

	public CardID GetID(); 
}

public enum CardID{
	NONE = 0x00,
	PL_GENERICPLANT = 0x01 //used for testing purposes
	
}


