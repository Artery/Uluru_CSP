using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class DeckGenerator : MonoBehaviour
{
    public enum enRuleCardColors { WHITE = 0, PINK = 1, YELLOW = 2, ORANGE = 3, RED = 4, GREEN = 5, BLUE = 6, BLACK = 7 }

    [SerializeField]
    private List<DifficultyRuleCardCollection> m_RuleCardPrefabs;
    [SerializeField]
    private Transform m_DeckParentTransform;

    [SerializeField]
    private bool GeneratePredefinedTestSequences;

    private static readonly List<Color> m_Colors = Enum.GetValues(typeof(Color)).Cast<Color>().Where(color => color >= 0).ToList();
    private static readonly System.Random m_RandomNumberGenerator = new System.Random();

    public static DeckGenerator Instance;

    public List<DifficultyRuleCardCollection> RuleCardPrefabs
    {
        get { return m_RuleCardPrefabs; }
    }

    void Awake ()
    {
        Instance = this;
    }

    public static CardCollection GenerateDeckBase(object arg)
    {
        if(arg is Difficulty)
        {
            return GenerateDeck((Difficulty) arg);
        }
        else if (arg is List<Func<enRuleCardColors, RuleCard>>)
        {
            return GenerateTestDecks((List<Func<enRuleCardColors, RuleCard>>)arg);
        }
        else
        {
            throw new ArgumentException();
        }
    }

    public static CardCollection GenerateTestDecks(List<Func<enRuleCardColors, RuleCard>> testCases)
    {
        var deck = new CardCollection();

        foreach (var testCase in testCases)
        {
            foreach (var color in Enum.GetValues(typeof(enRuleCardColors)).Cast<enRuleCardColors>())
            {
                deck.Add(testCase(color));
            }
        }

        return deck;
    }

    public static CardCollection GenerateDeck(Difficulty difficulty)
    {
        //ToDo
        //Needs refactoring
        var selectedRuleCardPrefabs = new CardCollection(Instance.RuleCardPrefabs.Where(cardset => cardset.Difficulty <= difficulty).SelectMany(collection => collection.RuleCards));

        var deck = new CardCollection();
        int cardCounter = 0;
        
        foreach (var prefab in selectedRuleCardPrefabs)
        {
            if (prefab.Color == Color.NONE)
            {
                int bound = prefab.RulesetType == enRulesetType.NO_PREFERENCE ? 8 : 2;
                for (int i = 0; i < bound; i++)
                {
                    var index = m_RandomNumberGenerator.Next(0, cardCounter++);
                    var ruleCard = Instantiate(prefab);
                    ruleCard.transform.SetParent(Instance.m_DeckParentTransform);

                    deck.Insert(index, ruleCard);
                }
            }
            else
            {
                foreach (var color in m_Colors)
                {
                    var index = m_RandomNumberGenerator.Next(0, cardCounter++);
                    var ruleCard = Instantiate(prefab);
                    ruleCard.Color = color;

                    deck.Insert(index, ruleCard);
                }
            }
        }

        return deck;
    }

    public static RuleCard InitializeRuleCard(enRulesetType rulesetType, Color ruleCardColor)
    {
        var ruleCard = Instantiate(Instance.m_RuleCardPrefabs.SelectMany(asdf => asdf.RuleCards).
                                            First(yo => yo.RulesetType == rulesetType));
        ruleCard.Color = ruleCardColor;
        ruleCard.Ruleset.Color = ruleCardColor;
        ruleCard.transform.SetParent(Instance.m_DeckParentTransform);

        return ruleCard;
    }
}
