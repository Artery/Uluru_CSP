using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles the Gameplan-board, which displays the RuleCards each round and handles the game-deck
/// </summary>
public class Gameplan : MonoBehaviour
{
    #region Fields
    #region SerializedFields
    [SerializeField]
    private List<Slot> m_Slots;
    [SerializeField]
    private CardCollection m_Deck = new CardCollection();
    #endregion
    #endregion

    #region Properties
    public List<Slot> Slots
    {
        get
        {
            return m_Slots;
        }
    }

    public CardCollection Deck
    {
        get { return m_Deck; }
    }
    #endregion

    #region Constructors
    #endregion

    #region Methods
    #region MonoMethods
    void Awake() { }

    void Start() { }

    void Update() { }

    //Resets the Gameplan by removing the RuleCards from the Slots
    //and adding them to the DiscardPile
    public void Reset()
    {
        ResetSlots();
    }
    #endregion

    #region ClassMethods
    public void Intialize(CardCollection gameDeck)
    {
        Deck.AddRange(gameDeck);
    }

    //Clears the whole Gameplan and the deck
    public void Clear()
    {
        Deck.Clear();
        ResetSlots();
    }

    //Resets the slots, by removing the RuleCards
    public void ResetSlots()
    {
        m_Slots.ForEach(slot => slot.SetRuleCard(null));
    }

    //Fills the slots with RuleCards from the Deck
    //Only fills "intern" Slots, to make the new assignments visible for the players
    //use DealOutNextSequence
    public void GenerateSequence()
    {
        foreach (var slot in Slots)
        {
            var nextCard = Deck.FirstOrDefault();
            slot.SetRuleCard(nextCard);

            //When a card is put on the Gameplan it's not removed from the Deck,
            //instead it's put under the Deck
            if (nextCard != null)
            {
                Deck.RemoveAt(0);
                Deck.Add(nextCard);
            }
        }
    }

    //Makes the current "intern" Slots visible to the players
    public void DealOutNextSequence()
    {
        //ToDO
        //throw new NotImplementedException();
    }
    #endregion
    #endregion
}
