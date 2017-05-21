using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class DeckGenerator : MonoBehaviour
{
    [SerializeField]
    private List<DifficultyRuleCardCollection> m_RuleCardPrefabs;

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
        var selectedRuleCardPrefabs = new CardCollection(Instance.RuleCardPrefabs.Where(cardset => cardset.Difficulty <= difficulty).SelectMany(collection => collection.RuleCards));

        var deck = new CardCollection();
        int cardCounter = 0;
        
        foreach (var prefab in selectedRuleCardPrefabs)
        {
            if (prefab.Color == Color.NONE)
            {
                for (int i = 0; i < 2; i++)
                {
                    var index = m_RandomNumberGenerator.Next(0, cardCounter++);
                    var ruleCard = Instantiate(prefab);

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
}
