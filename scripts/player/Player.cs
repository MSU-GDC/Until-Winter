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

    public override void _Ready()
    {
       
        Hand = new CardHand(new ICard[]{PlantCard.PLACEHOLDER}, false);

        base._Ready();
    }
    public override void _Process(double delta)
    {
        base._Process(delta);
    }


}
