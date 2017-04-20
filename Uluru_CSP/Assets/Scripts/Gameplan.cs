using System;
using System.Collections.Generic;
using UnityEngine;

public class Gameplan : MonoBehaviour
{
    [SerializeField]
    private Color_CardMap m_slots = new Color_CardMap();
    [SerializeField]
    private CardCollection m_gamepile = new CardCollection();
    [SerializeField]
    private CardCollection m_discardpile = new CardCollection();

    public Color_CardMap Slots { get; set; }

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
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public void GenerateSequence()
    {
        throw new NotImplementedException();
    }

    public void DealOutNextSequence()
    {
        throw new NotImplementedException();
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }
}
