public class GameStateManager
{
    private static GameStateManager _instance;
    public static GameStateManager Instance
    {
        //if there is now game state manager make one
        get
        {
            if (_instance == null)
                _instance = new GameStateManager();

            return _instance;
        }
    }
    public GameState CurrentGameState { get; private set; }
    public delegate void GameStateChangeHandler(GameState newGameState);
    public event GameStateChangeHandler OnPauseChange;
    // Start is called before the first frame update
    private GameStateManager()
    {

    }
    public void SetState(GameState newGameState)
    {
        if (newGameState == CurrentGameState)
        {
            return;
        }
        CurrentGameState = newGameState;
        OnPauseChange?.Invoke(newGameState);
    }


}
