using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoBoostCard : Card
{

    #region card_var
    float damageBoostPercent;

    #endregion

    public AutoBoostCard()
    {
        damageBoostPercent = 50;
        flavorText = "Increase auto damage by " + damageBoostPercent.ToString() + " percent";
        sunlightCost = 3; 
    }

    // Start is called before the first frame update
    public override void  Activate(Player player, GameManager control, Board board, Vector2 aim_dir = new Vector2(), Board.BoardTile pointed_tile = null)
    {
        if (player.leftPlayer && control.lSunlightCtr >= sunlightCost)
        {
            player.attackStat *= (1.0f + (damageBoostPercent/100.0f));
            control.lSunlightCtr -= sunlightCost;
        }

        if (!player.leftPlayer && control.rSunlightCtr >= sunlightCost)
        {
            player.attackStat *= (1.0f + (damageBoostPercent/100.0f));
            control.rSunlightCtr -= sunlightCost;
        }
    }


}
