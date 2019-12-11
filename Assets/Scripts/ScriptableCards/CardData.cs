using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New CardData", menuName = "CardData", order = 51)]
public abstract class CardData : ScriptableObject
{
    [SerializeField]
    private Image card_Image;
    [SerializeField]
    private Sprite card_Sprite;
    [SerializeField]
    private int healPercent = 0;
    [SerializeField]
    private int damageBoostPercent = 0;
    [SerializeField]
    private string flavorText = "Card Text";
    [SerializeField]
    private int damageValue = 0;
    [SerializeField]
    private int sunlightCost = 0;
    [SerializeField]
    private string formation;

    public abstract void Activate(Player player, GameManager control, Board board, Vector2 aim_dir = new Vector2(), Board.BoardTile pointed_tile = null);

    public Image CardImage
    {
        get
        {
            return card_Image;
        }
    }
    public Sprite CardSprite
    {
        get
        {
            return card_Sprite;
        }
    }
    public int HealPercent
    {
        get
        {
            return healPercent;
        }
    }
    public int DamageBoost
    {
        get
        {
            return damageBoostPercent;
        }
    }
    public string FlavorText
    {
        get
        {
            return flavorText;
        }
    }
    public int SunlightCost
    {
        get
        {
            return sunlightCost;
        }
    }
    public string Formation
    {
        get
        {
            return formation;
        }
    }
}
