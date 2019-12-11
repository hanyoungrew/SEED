using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Card : MonoBehaviour
{
    public Image card_Image;
    public Sprite card_Sprite;
    public string flavorText = "Card Text";
    public int sunlightCost = 0;
    public float damageValue;
    public string formation; 
    

    //how long you have to wait after playing a card to pla it again
    public float cooldownTime = 3;


    public abstract void Activate(Player player, GameManager control, Board board, Vector2 aim_dir = new Vector2(), Board.BoardTile pointed_tile = null);

    public string toString()
    {
        return flavorText; 
    }

    public Sprite CardImage(){
        return card_Sprite;
    }


}
