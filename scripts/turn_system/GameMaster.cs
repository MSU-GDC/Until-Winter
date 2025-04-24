/// <summary>
/// <b>GameMaster.cs</b>
/// <para>Keeps track of in-game time (seasons, current turn, etc.).</para>
/// <para>Also responsible for keeping track of any active events, and stores an event table of possible events for the season.</para>
/// </summary>
public class GameMaster{

    private struct GameDefaults{
        public const int TURNS_PER_SEASON = 10;

    }



    private Season _currentSeason;

    private int _currentTurn; 

    private ICardDeck _eventDeck; 

    private CardHand _activeEvents; 

    public TurnDispatcher Dispatcher {get; private set;}

    ///private List<ITurnEvent> _events;

    
}

public enum Season{
    SPRING = 1,
    SUMMER = 2,
    AUTUMN = 3,
    WINTER = 4
}