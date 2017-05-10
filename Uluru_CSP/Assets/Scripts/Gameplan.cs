using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Gameplan : MonoBehaviour
{
    [SerializeField]
    private List<Slot> m_slots;
    [SerializeField]
    private CardCollection m_gamepile = new CardCollection();
    [SerializeField]
    private CardCollection m_discardpile = new CardCollection();

    public List<Slot> Slots
    {
        get
        {
            return m_slots;
        }
    }

    public CardCollection GamePile
    {
        get { return m_gamepile; }
    }

    public CardCollection DiscardPile
    {
        get { return m_discardpile; }
    }

    public void Intialize(CardCollection gameDeck)
    {
        GamePile.AddRange(gameDeck);
    }

    //Clears the whole Gameplan and it's piles
    public void Clear()
    {
        GamePile.Clear();
        DiscardPile.Clear();

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
        foreach(var slot in Slots)
        {
            slot.SetRuleCard(GamePile.FirstOrDefault());
            GamePile.RemoveAt(0);
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
        DiscardPile.AddRange(Slots.Select(slot => slot.RuleCard));
        ResetSlots();
    }
}
