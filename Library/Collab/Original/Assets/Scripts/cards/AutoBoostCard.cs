using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoBoostCard : Card
{

    #region card_var
    float damageBoostPercent;

    float normalAttack;
    #endregion

    Player dPlayer;
    public AutoBoostCard()
    {
        damageBoostPercent = 50;
        flavorText = "Increase auto damage by " + damageBoostPercent.ToString() + " percent for 5 seconds";
        sunlightCost = 3; 
    }

    // Start is called before the first frame update
    public override void  Activate(Player player, GameManager control, Board board, Vector2 aim_dir = new Vector2(), Board.BoardTile pointed_tile = null)
    {
        if (player.leftPlayer && control.lSunlightCtr >= sunlightCost)
        {
            buff(player);
            control.lSunlightCtr -= sunlightCost;
            dPlayer = player;
            Invoke("debuff", 5.0f);
        }

        if (!player.leftPlayer && control.rSunlightCtr >= sunlightCost)
        {
            buff(player);
            control.rSunlightCtr -= sunlightCost;
            dPlayer = player;
            Invoke("debuff", 5.0f);

        }
    }

    public void buff(Player player){
        normalAttack = player.attackStat;
        player.attackStat *= (1.0f + (damageBoostPercent/100.0f));
    }

    //so that attack buffs do not stack
    public void debuff(){
        dPlayer.attackStat = normalAttack;
        dPlayer = null;

    }

}
