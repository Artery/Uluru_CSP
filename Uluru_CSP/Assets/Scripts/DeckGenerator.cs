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

    private static readonly List<Func<enRuleCardColors, RuleCard>> TestCases = new List<Func<enRuleCardColors, RuleCard>>
                                                           {
                                                               DeckGenerator.CreateTestNo_1,
                                                               DeckGenerator.CreateTestNo_2,
                                                               DeckGenerator.CreateTestNo_3
                                                           };

    public static CardCollection GenerateTestDecks()
    {
        var deck = new CardCollection();

        foreach (var testCase in TestCases)
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

    private static RuleCard InitializeRuleCard(enRulesetType rulesetType, Color ruleCardColor)
    {
        var ruleCard = Instantiate(Instance.m_RuleCardPrefabs.SelectMany(asdf => asdf.RuleCards).
                                            First(yo => yo.RulesetType == rulesetType));
        ruleCard.Color = ruleCardColor;
        ruleCard.Ruleset.Color = ruleCardColor;
        ruleCard.transform.SetParent(Instance.m_DeckParentTransform);

        return ruleCard;
    }

    public static RuleCard CreateTestNo_1(enRuleCardColors color)
    {
        RuleCard ruleCard = null;
        switch(color)
        {
            case enRuleCardColors.WHITE:
                ruleCard = InitializeRuleCard(enRulesetType.NOT_ADJACENT_NOT_OPPOSITE_SIDE, Color.PINK);
                break;
            case enRuleCardColors.PINK:
                ruleCard = InitializeRuleCard(enRulesetType.MINIMUM_DISTANCE_2, Color.YELLOW);
                break;
            case enRuleCardColors.YELLOW:
                ruleCard = InitializeRuleCard(enRulesetType.ADJACENT, Color.WHITE);
                break;
            case enRuleCardColors.ORANGE:
                ruleCard = InitializeRuleCard(enRulesetType.OPPOSITE_SIDE, Color.BLUE);
                break;
            case enRuleCardColors.RED:
                ruleCard = InitializeRuleCard(enRulesetType.OPPOSITE_SIDE, Color.BLUE);
                break;
            case enRuleCardColors.GREEN:
                ruleCard = InitializeRuleCard(enRulesetType.AROUND_THE_CORNER, Color.WHITE);
                break;
            case enRuleCardColors.BLUE:
                ruleCard = InitializeRuleCard(enRulesetType.AROUND_THE_CORNER, Color.BLACK);
                break;
            case enRuleCardColors.BLACK:
                ruleCard = InitializeRuleCard(enRulesetType.NOT_ADJACENT_NOT_OPPOSITE_SIDE, Color.YELLOW);
                break;
            default:
                throw new IndexOutOfRangeException();
        }
        
        return ruleCard;
    }

    public static RuleCard CreateTestNo_2(enRuleCardColors color)
    {
        RuleCard ruleCard = null;
        switch (color)
        {
            case enRuleCardColors.WHITE:
                ruleCard = InitializeRuleCard(enRulesetType.AROUND_THE_CORNER, Color.GREEN);
                break;
            case enRuleCardColors.PINK:
                ruleCard = InitializeRuleCard(enRulesetType.ADJACENT, Color.RED);
                break;
            case enRuleCardColors.YELLOW:
                ruleCard = InitializeRuleCard(enRulesetType.ADJACENT, Color.BLUE);
                break;
            case enRuleCardColors.ORANGE:
                ruleCard = InitializeRuleCard(enRulesetType.NO_PREFERENCE, Color.NONE);
                break;
            case enRuleCardColors.RED:
                ruleCard = InitializeRuleCard(enRulesetType.OPPOSITE_SIDE, Color.BLACK);
                break;
            case enRuleCardColors.GREEN:
                ruleCard = InitializeRuleCard(enRulesetType.AROUND_THE_CORNER, Color.PINK);
                break;
            case enRuleCardColors.BLUE:
                ruleCard = InitializeRuleCard(enRulesetType.NOT_ADJACENT_NOT_OPPOSITE_SIDE, Color.PINK);
                break;
            case enRuleCardColors.BLACK:
                ruleCard = InitializeRuleCard(enRulesetType.MINIMUM_DISTANCE_2, Color.ORANGE);
                break;
            default:
                throw new IndexOutOfRangeException();
        }

        return ruleCard;
    }

    public static RuleCard CreateTestNo_3(enRuleCardColors color)
    {
        RuleCard ruleCard = null;
        switch (color)
        {
            case enRuleCardColors.WHITE:
                ruleCard = InitializeRuleCard(enRulesetType.LONG_SIDE, Color.NONE);
                break;
            case enRuleCardColors.PINK:
                ruleCard = InitializeRuleCard(enRulesetType.ADJACENT, Color.WHITE);
                break;
            case enRuleCardColors.YELLOW:
                ruleCard = InitializeRuleCard(enRulesetType.AROUND_THE_CORNER, Color.PINK);
                break;
            case enRuleCardColors.ORANGE:
                ruleCard = InitializeRuleCard(enRulesetType.OPPOSITE_SIDE, Color.RED);
                break;
            case enRuleCardColors.RED:
                ruleCard = InitializeRuleCard(enRulesetType.LONLEY_GROUP, Color.NONE);
                break;
            case enRuleCardColors.GREEN:
                ruleCard = InitializeRuleCard(enRulesetType.MINIMUM_DISTANCE_2, Color.RED);
                break;
            case enRuleCardColors.BLUE:
                ruleCard = InitializeRuleCard(enRulesetType.NOT_ADJACENT_NOT_OPPOSITE_SIDE, Color.GREEN);
                break;
            case enRuleCardColors.BLACK:
                ruleCard = InitializeRuleCard(enRulesetType.BUMERANG_GROUP, Color.NONE);
                break;
            default:
                throw new IndexOutOfRangeException();
        }

        return ruleCard;
    }
}
