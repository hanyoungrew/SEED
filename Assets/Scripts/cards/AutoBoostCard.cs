using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoBoostCard : Card
{

    #region card_var
    float damageBoostPercent;
    
    float oldstat;
    Player p;

    public Sprite buffed;
    public Sprite normal;
    
    public Sprite fbuffed;
    public Sprite fnormal;
    
    #endregion

    public AutoBoostCard()
    {
        damageBoostPercent = 100;
        flavorText = "Increase auto damage by " + damageBoostPercent.ToString() + " percent";
        sunlightCost = 3; 
    }

    // Start is called before the first frame update
    public override void  Activate(Player player, GameManager control, Board board, Vector2 aim_dir = new Vector2(), Board.BoardTile pointed_tile = null)
    {
        if (player.leftPlayer && control.lSunlightCtr >= sunlightCost)
        {
            buff(player);
            control.lSunlightCtr -= sunlightCost;
        }

        if (!player.leftPlayer && control.rSunlightCtr >= sunlightCost)
        {
            buff(player);
            control.rSunlightCtr -= sunlightCost;
        }
        player.playSound("Upgrade");
    }

    public void buff(Player player){
        p = player;
        oldstat = p.attackStat;
        p.attackStat *= (1.0f + (damageBoostPercent/100.0f));
        
        if (p.leftPlayer){
            p.spriteRenderer.sprite = buffed;
        } else {
            p.spriteRenderer.sprite = fbuffed;

        }
        RefreshPoly();


        Invoke("debuff", 5.0f);

    }

    public void debuff(){
        p.attackStat = oldstat;
        if (p.leftPlayer){
            p.spriteRenderer.sprite = normal;
        } else {
            p.spriteRenderer.sprite = fnormal;

        }
        RefreshPoly();

    }


    public void RefreshPoly(){
        Destroy(p.GetComponent<PolygonCollider2D>());
        p.gameObject.AddComponent<PolygonCollider2D>();
    }

}
