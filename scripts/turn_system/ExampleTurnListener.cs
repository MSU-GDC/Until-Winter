using Godot;
using System;

public partial class ExampleTurnListener : Node3D
{
	private Vector3 v3_initialPos;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if(TurnHandler.Singleton == null) TurnHandler.OnInstanceCreated += InitTurnCallbacks;	/// if this object was created before the turn handler, wait until the turn handler is created to subscribe callbacks
		else InitTurnCallbacks();															 	/// otherwise subscribe the callbacks the normal way
		v3_initialPos = Position;
	}

	private void InitTurnCallbacks(){
		TurnHandler.Singleton.OnTurnComplete += ResetPos; 
		TurnHandler.Singleton.OnTurnProgress += MoveRandom; 
		TurnHandler.Singleton.OnTurnComplete += InvokeOnce;
	}

	private void ResetPos(){
		Position = v3_initialPos; 
	}

	private void MoveRandom(){
		Random rng = new Random();
		float randX = (float)rng.NextDouble() * 5.0f;
		float randZ = (float)rng.NextDouble() * -5.0f;

		Position = new Vector3(randX,0f,randZ);
	}
	private void InvokeOnce(){
		TurnHandler.Singleton.OnTurnComplete -= InvokeOnce; 

		GD.Print("Invoked once");
	}
}
