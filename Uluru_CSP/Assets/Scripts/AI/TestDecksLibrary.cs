using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// Class summary goes here...
/// </summary>
public class TestDecksLibrary
{
    #region Fields
    #region SerializedFields
    #endregion
    #endregion

    #region Properties
    #endregion

    #region Constructors
    #endregion

    #region Methods
    #region StaticMethods
    

    public static RuleCard CreateTestNo_1(DeckGenerator.enRuleCardColors color)
    {
        RuleCard ruleCard = null;
        switch (color)
        {
            case DeckGenerator.enRuleCardColors.WHITE:
                ruleCard = DeckGenerator.InitializeRuleCard(enRulesetType.NOT_ADJACENT_NOT_OPPOSITE_SIDE, Color.PINK);
                break;
            case DeckGenerator.enRuleCardColors.PINK:
                ruleCard = DeckGenerator.InitializeRuleCard(enRulesetType.MINIMUM_DISTANCE_2, Color.YELLOW);
                break;
            case DeckGenerator.enRuleCardColors.YELLOW:
                ruleCard = DeckGenerator.InitializeRuleCard(enRulesetType.ADJACENT, Color.WHITE);
                break;
            case DeckGenerator.enRuleCardColors.ORANGE:
                ruleCard = DeckGenerator.InitializeRuleCard(enRulesetType.OPPOSITE_SIDE, Color.BLUE);
                break;
            case DeckGenerator.enRuleCardColors.RED:
                ruleCard = DeckGenerator.InitializeRuleCard(enRulesetType.OPPOSITE_SIDE, Color.BLUE);
                break;
            case DeckGenerator.enRuleCardColors.GREEN:
                ruleCard = DeckGenerator.InitializeRuleCard(enRulesetType.AROUND_THE_CORNER, Color.WHITE);
                break;
            case DeckGenerator.enRuleCardColors.BLUE:
                ruleCard = DeckGenerator.InitializeRuleCard(enRulesetType.AROUND_THE_CORNER, Color.BLACK);
                break;
            case DeckGenerator.enRuleCardColors.BLACK:
                ruleCard = DeckGenerator.InitializeRuleCard(enRulesetType.NOT_ADJACENT_NOT_OPPOSITE_SIDE, Color.YELLOW);
                break;
            default:
                throw new IndexOutOfRangeException();
        }

        return ruleCard;
    }

    public static RuleCard CreateTestNo_2(DeckGenerator.enRuleCardColors color)
    {
        RuleCard ruleCard = null;
        switch (color)
        {
            case DeckGenerator.enRuleCardColors.WHITE:
                ruleCard = DeckGenerator.InitializeRuleCard(enRulesetType.AROUND_THE_CORNER, Color.GREEN);
                break;
            case DeckGenerator.enRuleCardColors.PINK:
                ruleCard = DeckGenerator.InitializeRuleCard(enRulesetType.ADJACENT, Color.RED);
                break;
            case DeckGenerator.enRuleCardColors.YELLOW:
                ruleCard = DeckGenerator.InitializeRuleCard(enRulesetType.ADJACENT, Color.BLUE);
                break;
            case DeckGenerator.enRuleCardColors.ORANGE:
                ruleCard = DeckGenerator.InitializeRuleCard(enRulesetType.NO_PREFERENCE, Color.NONE);
                break;
            case DeckGenerator.enRuleCardColors.RED:
                ruleCard = DeckGenerator.InitializeRuleCard(enRulesetType.OPPOSITE_SIDE, Color.BLACK);
                break;
            case DeckGenerator.enRuleCardColors.GREEN:
                ruleCard = DeckGenerator.InitializeRuleCard(enRulesetType.AROUND_THE_CORNER, Color.PINK);
                break;
            case DeckGenerator.enRuleCardColors.BLUE:
                ruleCard = DeckGenerator.InitializeRuleCard(enRulesetType.NOT_ADJACENT_NOT_OPPOSITE_SIDE, Color.PINK);
                break;
            case DeckGenerator.enRuleCardColors.BLACK:
                ruleCard = DeckGenerator.InitializeRuleCard(enRulesetType.MINIMUM_DISTANCE_2, Color.ORANGE);
                break;
            default:
                throw new IndexOutOfRangeException();
        }

        return ruleCard;
    }

    public static RuleCard CreateTestNo_3(DeckGenerator.enRuleCardColors color)
    {
        RuleCard ruleCard = null;
        switch (color)
        {
            case DeckGenerator.enRuleCardColors.WHITE:
                ruleCard = DeckGenerator.InitializeRuleCard(enRulesetType.LONG_SIDE, Color.NONE);
                break;
            case DeckGenerator.enRuleCardColors.PINK:
                ruleCard = DeckGenerator.InitializeRuleCard(enRulesetType.ADJACENT, Color.WHITE);
                break;
            case DeckGenerator.enRuleCardColors.YELLOW:
                ruleCard = DeckGenerator.InitializeRuleCard(enRulesetType.AROUND_THE_CORNER, Color.PINK);
                break;
            case DeckGenerator.enRuleCardColors.ORANGE:
                ruleCard = DeckGenerator.InitializeRuleCard(enRulesetType.OPPOSITE_SIDE, Color.RED);
                break;
            case DeckGenerator.enRuleCardColors.RED:
                ruleCard = DeckGenerator.InitializeRuleCard(enRulesetType.LONLEY_GROUP, Color.NONE);
                break;
            case DeckGenerator.enRuleCardColors.GREEN:
                ruleCard = DeckGenerator.InitializeRuleCard(enRulesetType.MINIMUM_DISTANCE_2, Color.RED);
                break;
            case DeckGenerator.enRuleCardColors.BLUE:
                ruleCard = DeckGenerator.InitializeRuleCard(enRulesetType.NOT_ADJACENT_NOT_OPPOSITE_SIDE, Color.GREEN);
                break;
            case DeckGenerator.enRuleCardColors.BLACK:
                ruleCard = DeckGenerator.InitializeRuleCard(enRulesetType.BUMERANG_GROUP, Color.NONE);
                break;
            default:
                throw new IndexOutOfRangeException();
        }

        return ruleCard;
    }
    #endregion
    #endregion
}
