/// <summary>
/// <b>TurnDispatcher<b>
/// <para>Dispatcher class for manages the turn callbacks, callbacks can be invoked manually but this is not recommended</para>
/// </summary>
public class TurnDispatcher
{
    /// delegate type should only be used to create other delegates
    public delegate void TurnCallback();

    // public delegate void InstanceCreatedCallback();

    // public static InstanceCreatedCallback OnInstanceCreated;

  
    /// <summary>
    /// Called every time the turn progresses, should only be subscribed to using <code>Callback += func( args );</code> syntax.
    /// <para>Make sure to have code that handles unsubscribing using the syntax <code>Callback -= func( args );</code> otherwise subscribed functions will be called the next time the delegate is invoked.</para>
    /// </summary> 
    public TurnCallback OnTurnBegin; 

    /// <summary>
    /// Called every time the turn completes, should only be subscribed to using <code>Callback += func( args );</code> syntax.
    /// <para>Make sure to have code that handles unsubscribing using the syntax <code>Callback -= func( args );</code> otherwise subscribed functions will be called the next time the delegate is invoked.</para>
    /// </summary> 

    public TurnCallback OnTurnEnd;

    public TurnDispatcher(){}


    public void InvokeTurnBeginCallbacks(){
        OnTurnBegin.Invoke();
    }

    public void InvokeTurnEndCallbacks(){
        OnTurnEnd.Invoke();
    }
}
