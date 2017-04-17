using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    private Gameplan m_gameplan = new Gameplan();
    [SerializeField]
    private Hourglass m_hourglass = new Hourglass();

    [SerializeField]
    private Difficulty m_difficulty;
    [SerializeField]
    private int m_maxRounds;
    [SerializeField]
    private int m_currentRound;

    [SerializeField]
    private PlayerCollection m_players = new PlayerCollection();
    [SerializeField]
    private CardCollection m_deck = new CardCollection();
    [SerializeField]
    private CardCollection m_gamepile = new CardCollection();
    [SerializeField]
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

    public Difficulty Difficulty
    {
        get { return m_difficulty; }
        set { m_difficulty = value; }
    }
    public int MaxRounds
    {
        get { return m_maxRounds; }
        set { m_maxRounds = value; }
    }
    public int CurrentRound
    {
        get { return m_currentRound; }
        set { m_currentRound = value; }
    }
}
