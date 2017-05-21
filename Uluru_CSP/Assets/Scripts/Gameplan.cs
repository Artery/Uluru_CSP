using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Gameplan : MonoBehaviour
{
    [SerializeField]
    private List<Slot> m_slots;
    [SerializeField]
    private CardCollection m_Deck = new CardCollection();

    public List<Slot> Slots
    {
        get
        {
            return m_slots;
        }
    }

    public CardCollection Deck
    {
        get { return m_Deck; }
    }

    public void Intialize(CardCollection gameDeck)
    {
        Deck.AddRange(gameDeck);
    }

    //Clears the whole Gameplan and it's piles
    public void Clear()
    {
        Deck.Clear();

        ResetSlots();
    }

    //Resets the slots, by removing the RuleCards from each color
    public void ResetSlots()
    {
        m_slots.ForEach(slot => slot.SetRuleCard(null));
    }

    //Fills the slots with RuleCards from the GamePile
    //Only fills "intern" Slots, to make the new assignments visible for the players
    //use DealOutNextSequence
    public void GenerateSequence()
    {
        foreach (var slot in Slots)
        {
            var nextCard = Deck.FirstOrDefault();
            slot.SetRuleCard(nextCard);

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
        //throw new NotImplementedException();
    }

    //Resets the Gameplan by removing the RuleCards from the Slots
    //and adding them to the DiscardPile
    public void Reset()
    {
        ResetSlots();
    }
}
