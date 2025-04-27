using Godot;
using System;
using System.Collections.Generic;

/// <summary>
/// <para><b>Player.cs</b></para>
/// <para>Player.cs is a glorified struct that consolidates important player data (e.g. current hand, current score, etc)</para>
/// <para></para>
/// -- John
/// </summary>
public partial class Player : Node3D
{


    public Farm Farm; 


    public CardHand Hand; 


    private ICard _selectedCard;

    public override void _Ready()
    {
       
        Hand = new CardHand(new ICard[]{PlantCard.PLACEHOLDER}, false);

        GD.Print($"\"{Hand.GetCardByIndex(0)}\"");

        base._Ready();
    }
    public override void _Process(double delta)
    {
        base._Process(delta);
    }


    public bool HasCardSelected(){
        return _selectedCard != null;
    }

    public void SetSelectedCard(ICard card){
        _selectedCard = card; 
    }

    public ICard GetSelectedCard(){
        return _selectedCard;
    }

    public void PlaySelectedCardOnTile(Vector2I tile){
        if(HasCardSelected() && Farm.HasCoord(tile)){
            
        }
    }





}
