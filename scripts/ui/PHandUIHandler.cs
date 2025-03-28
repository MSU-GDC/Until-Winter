using Godot;
using System;

public partial class PHandUIHandler : Node
{
	[ExportGroup("References")]
	[Export] private TextureButton[] _cardButtons;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		for(int i = 0; i < _cardButtons.Length; i++){
			GD.Print(_cardButtons[i].Name);
			string temp = _cardButtons[i].Name;
			_cardButtons[i].Pressed += ()=> {GD.Print("Test " + temp);};
		}
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
			
	}
}
