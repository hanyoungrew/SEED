using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLava : Card
{
    public SetLava()
    {
        flavorText = "Sets the Tile to Lava. Neat";
        sunlightCost = 5;
    }

    // Start is called before the first frame update
    public override void Activate(Player player, GameManager control, Board board, Vector2 aim_dir = new Vector2(), Board.BoardTile pointed_tile = null)
    {
        if (pointed_tile == null){
            //Debug.Log("ah fuck");
        }
        if (player.leftPlayer && control.lSunlightCtr >= sunlightCost){
            control.lSunlightCtr -= sunlightCost; 
            board.replaceTile(pointed_tile, "Lava");

        } else if (!player.leftPlayer && control.rSunlightCtr >= sunlightCost){
            control.rSunlightCtr -= sunlightCost;
            board.replaceTile(pointed_tile, "Lava");

        }

    }

}

