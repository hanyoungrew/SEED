using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealCard : Card
{
    #region card_var
    float healPercent;

    #endregion


    public HealCard()
    {
        healPercent = 50;
        flavorText = "Heals 2 Health";
        sunlightCost = 3; 

    }


    public override void Activate(Player player, GameManager control, Board board, Vector2 aim_dir = new Vector2(), Board.BoardTile pointed_tile = null)
    {

        if (player.leftPlayer && control.lSunlightCtr >= sunlightCost)
        {
            player.TakeDamage(-1 * (healPercent / 100.0f), true);
            control.lSunlightCtr -= sunlightCost;
        }

        if (!player.leftPlayer && control.rSunlightCtr >= sunlightCost)
        {
            player.TakeDamage(-1 * (healPercent / 100.0f), true);
            control.rSunlightCtr -= sunlightCost;
        }



    }




}
