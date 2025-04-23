using Godot;
using System;


/// <summary>
/// Example card manager object that would keep track of the decks the player has access to each season
/// -- John
/// </summary>
public partial class CardManagerObject : Node3D
{

	public  ICard[] SummerCards = null;
	public  ICard[] WinterCards = null;
	public  ICard[] AutumnCards = null;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
