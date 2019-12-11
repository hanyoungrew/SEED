using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetWall : Card
{

    public SetWall()
    {
        flavorText = "Set wall on target Tile";
        sunlightCost = 4;
    }

    // Start is called before the first frame update
    public override void Activate(Player player, GameManager control, Board board, Vector2 aim_dir = new Vector2(), Board.BoardTile pointed_tile = null)
    {
        if (player.leftPlayer && control.lSunlightCtr >= sunlightCost){
            bool worked = board.replaceTileWithWall(pointed_tile);
            if (worked){
                control.lSunlightCtr -= sunlightCost; 
            }


        } else if (!player.leftPlayer && control.rSunlightCtr >= sunlightCost){
            bool worked = board.replaceTileWithWall(pointed_tile);
            if (worked){
                control.rSunlightCtr -= sunlightCost;
            }

        }
    }
}

