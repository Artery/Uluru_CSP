public class Game
{
    private Gameplan m_gameplan = new Gameplan();
    private Hourglass m_hourglass = new Hourglass();

    private PlayerCollection m_players = new PlayerCollection();
    private CardCollection m_deck = new CardCollection();
    private CardCollection m_gamepile = new CardCollection();
    private CardCollection m_discardpile = new CardCollection();


    public PlayerCollection Players
    {
        get { return m_players; }
    }

    public CardCollection Deck
    {
        get { return m_deck; }
    }

    public CardCollection GamePile
    {
        get { return m_gamepile; }
    }

    public CardCollection DiscardPile
    {
        get { return m_discardpile; }
    }

    public Gameplan Gameplan
    {
        get { return m_gameplan; }
    }

    public Hourglass Hourglass
    {
        get { return m_hourglass; }
    }

    public Difficulty Difficulty { get; set; }
    public int MaxRounds { get; set; }
    public int CurrentRound { get; set; }
}
