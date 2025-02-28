using Godot;
using System;



// TODO - Think about implimentation:
// Maybe have two classes, with one being responsible for runtime turn logic, while the other manages the callbacks.
//
// Or maybe someone should probably create a game manager class that handles the stuff in between turns 
// and we can go from there.
//
// -- John
public partial class TurnHandler : Node3D
{
    public static TurnHandler Singleton;

    /// delegate type should only be used to create other delegates
    public delegate void TurnCallback();

    public delegate void InstanceCreatedCallback();

    public static InstanceCreatedCallback OnInstanceCreated;

  
    /// <summary>
    /// Called every time the turn progresses, should only be subscribed to using Callback += func( args ); syntax.
    /// <para>Make sure to have code that handles unsubscribing (Callback -= func( args );) otherwise subscribed functions will be called the next time the delegate is invoked.</para>
    /// </summary> 
    public TurnCallback OnTurnProgress; 

    /// <summary>
    /// Called every time the turn completes, should only be subscribed to using Callback += func( args ); syntax.
    /// <para>Make sure to have code that handles unsubscribing (Callback -= func( args );) otherwise subscribed functions will be called the next time the delegate is invoked.</para>
    /// </summary> 

    public TurnCallback OnTurnComplete;

    
    public override void _Ready()
    {
        if(Singleton != null && Singleton != this && !this.IsQueuedForDeletion()){
            GD.PrintErr("ERROR::MULTIPLE INSTANCES OF TURN HANDLER DETECTED, REMOVING NEW INSTANCE");
            this.QueueFree();
        }
        else if(Singleton == null){
            Singleton = this;
            if(OnInstanceCreated != null) OnInstanceCreated.Invoke(); /// callback invoked if turn handler is loaded later in the node tree heirarchy
        }
    }


    public override void _Process(double delta)
    {
        if(this.IsQueuedForDeletion()) return; 

        if(Input.IsActionJustPressed("db_progressturn")){
            OnTurnProgress.Invoke();
        }
        else if(Input.IsActionJustPressed("db_endturn")){
            OnTurnComplete.Invoke();
        }
    }



}
