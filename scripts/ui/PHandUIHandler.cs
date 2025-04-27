using Godot;
using System;

/// <summary>
/// Handles the selection and playing of the player cards 
/// </summary>
public partial class PHandUIHandler : Node
{
	[ExportGroup("References")]
	[Export] private TextureButton[] _cardButtons;
	[Export] private Player _playerReference;




	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		for(int i = 0; i < _cardButtons.Length; i++){
			GD.Print(_cardButtons[i].Name);
			int cIndex = i;
			_cardButtons[cIndex].Pressed += ()=> {GD.Print("Test " + _cardButtons[cIndex].Name);};
			_cardButtons[cIndex].Pressed += ()=> 
			{
				GD.Print(cIndex + " " + _playerReference.Hand.GetCardByIndex(cIndex));
				_playerReference.SetSelectedCard(_playerReference.Hand.GetCardByIndex(cIndex));

				GD.Print($"Setting selected card to {_playerReference.GetSelectedCard()}");
			};

		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
			
	}
}
