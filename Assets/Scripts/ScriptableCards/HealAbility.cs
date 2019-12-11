using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAbility : CardData
{
    #region card_var
    float healPercent;

    #endregion
    public override void Activate(Player player, GameManager control, Board board, Vector2 aim_dir = new Vector2(), Board.BoardTile pointed_tile = null)
    {

        if (player.leftPlayer && control.lSunlightCtr >= SunlightCost)
        {
            player.TakeDamage(-1 * (healPercent / 100.0f), true);
            control.lSunlightCtr -= SunlightCost;
        }

        if (!player.leftPlayer && control.rSunlightCtr >= SunlightCost)
        {
            player.TakeDamage(-1 * (healPercent / 100.0f), true);
            control.rSunlightCtr -= SunlightCost;
        }



    }
}
