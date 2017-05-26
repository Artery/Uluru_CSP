using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class DeckGenerator : MonoBehaviour
{
    [SerializeField]
    private List<DifficultyRuleCardCollection> m_RuleCardPrefabs;
    [SerializeField]
    private Transform m_DeckParentTransform;

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
                    RuleCard ruleCard = null;
                    if (i == 7)
                    {
                        Debug.Log("BLACK");
                        ruleCard = Instantiate(Instance.m_RuleCardPrefabs.SelectMany(asdf => asdf.RuleCards).
                            First(yo => yo.RulesetType == enRulesetType.NOT_ADJACENT_NOT_OPPOSITE_SIDE));
                        ruleCard.transform.SetParent(Instance.m_DeckParentTransform);
                        ruleCard.Color = Color.YELLOW;
                        ruleCard.Ruleset.Color = Color.YELLOW;
                        //deck.Insert(0, ruleCard);
                        deck.Add(ruleCard);
                    }
                    else if (i == 6)
                    {
                        Debug.Log("BLUE");
                        ruleCard = Instantiate(Instance.m_RuleCardPrefabs.SelectMany(asdf => asdf.RuleCards).
                            First(yo => yo.RulesetType == enRulesetType.AROUND_THE_CORNER));
                        ruleCard.transform.SetParent(Instance.m_DeckParentTransform);
                        ruleCard.Color = Color.BLACK;
                        ruleCard.Ruleset.Color = Color.BLACK;
                        //deck.Insert(0, ruleCard);
                        deck.Add(ruleCard);
                    }
                    else if (i == 5)
                    {
                        Debug.Log("GREEN");
                        ruleCard = Instantiate(Instance.m_RuleCardPrefabs.SelectMany(asdf => asdf.RuleCards).
                            First(yo => yo.RulesetType == enRulesetType.AROUND_THE_CORNER));
                        ruleCard.transform.SetParent(Instance.m_DeckParentTransform);
                        ruleCard.Color = Color.WHITE;
                        ruleCard.Ruleset.Color = Color.WHITE;
                        //deck.Insert(0, ruleCard);
                        deck.Add(ruleCard);
                    }
                    else if (i == 4)
                    {
                        Debug.Log("RED");
                        ruleCard = Instantiate(Instance.m_RuleCardPrefabs.SelectMany(asdf => asdf.RuleCards).
                            First(yo => yo.RulesetType == enRulesetType.OPPOSITE_SIDE));
                        ruleCard.transform.SetParent(Instance.m_DeckParentTransform);
                        ruleCard.Color = Color.BLUE;
                        ruleCard.Ruleset.Color = Color.BLUE;
                        //deck.Insert(0, ruleCard);
                        deck.Add(ruleCard);
                    }
                    else if (i == 3)
                    {
                        Debug.Log("ORANGE");
                        ruleCard = Instantiate(Instance.m_RuleCardPrefabs.SelectMany(asdf => asdf.RuleCards).
                            First(yo => yo.RulesetType == enRulesetType.OPPOSITE_SIDE));
                        ruleCard.transform.SetParent(Instance.m_DeckParentTransform);
                        ruleCard.Color = Color.BLUE;
                        ruleCard.Ruleset.Color = Color.BLUE;
                        //deck.Insert(0, ruleCard);
                        deck.Add(ruleCard);
                    }
                    else if (i == 2)
                    {
                        Debug.Log("YELLOW");
                        ruleCard = Instantiate(Instance.m_RuleCardPrefabs.SelectMany(asdf => asdf.RuleCards).
                            First(yo => yo.RulesetType == enRulesetType.ADJACENT));
                        ruleCard.transform.SetParent(Instance.m_DeckParentTransform);
                        ruleCard.Color = Color.WHITE;
                        ruleCard.Ruleset.Color = Color.WHITE;
                        //deck.Insert(0, ruleCard);
                        deck.Add(ruleCard);
                    }
                    else if (i == 1)
                    {
                        Debug.Log("PINK");
                        ruleCard = Instantiate(Instance.m_RuleCardPrefabs.SelectMany(asdf => asdf.RuleCards).
                            First(yo => yo.RulesetType == enRulesetType.MINIMUM_DISTANCE_2));
                        ruleCard.transform.SetParent(Instance.m_DeckParentTransform);
                        ruleCard.Color = Color.YELLOW;
                        ruleCard.Ruleset.Color = Color.YELLOW;

                        //deck.Insert(0, ruleCard);
                        deck.Add(ruleCard);
                    }
                    else if (i == 0)
                    {
                        Debug.Log("WHITE");
                        ruleCard = Instantiate(Instance.m_RuleCardPrefabs.SelectMany(asdf => asdf.RuleCards).
                            First(yo => yo.RulesetType == enRulesetType.NOT_ADJACENT_NOT_OPPOSITE_SIDE));
                        ruleCard.Color = Color.PINK;
                        ruleCard.Ruleset.Color = Color.PINK;
                        ruleCard.transform.SetParent(Instance.m_DeckParentTransform);

                        //deck.Insert(0, ruleCard);
                        deck.Add(ruleCard);
                    }
                    else
                    {
                        Debug.Log("As");
                        ruleCard = Instantiate(prefab);
                        ruleCard.transform.SetParent(Instance.m_DeckParentTransform);

                        deck.Insert(index, ruleCard);
                    }
                    //var ruleCard = Instantiate(prefab);


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
}
