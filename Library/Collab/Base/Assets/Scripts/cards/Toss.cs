using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toss : Card
{

    #region temp workaround_for_coroutine_nonsense_bug
    Board board;
    Player player;
    Board.BoardTile pointed_tile;
    List<Board.BoardTile> affectedTiles = new List<Board.BoardTile>(); 
    string form;

    string typeReplace;

    #endregion


    public Toss()
    {
        damageValue = 0.5f;
        sunlightCost = 6;
        formation = "3X3";
        flavorText = "AOE attack";

    }

    public override void Activate(Player player, GameManager control, Board board, Vector2 aim_dir = new Vector2(), Board.BoardTile pointed_tile = null)
    {
        if (player.leftPlayer && control.lSunlightCtr >= sunlightCost)
        {
            control.lSunlightCtr -= sunlightCost;
            startFlash(board, player, 0.1f, pointed_tile, formation, "Default");
        }

        if (!player.leftPlayer && control.rSunlightCtr >= sunlightCost)
        {
            control.rSunlightCtr -= sunlightCost;
            startFlash(board, player, 0.1f, pointed_tile, formation, "Default");
        }
    }


    public void startFlash(Board b, Player player, float secondsDelay, Board.BoardTile targetTile,
        string formation, string replaceTypeString){
        board = b;
        this.player = player;
        pointed_tile = targetTile;
        form = formation;
    //Debug.Log("Toss used");

        typeReplace = replaceTypeString;
        affectedTiles = b.ReplaceFormationTiles(targetTile, formation, "Flash", "");

        Invoke("finishFlash", secondsDelay);
    }

    public void finishFlash(){
        board.RestoreFormationTiles(affectedTiles, pointed_tile, typeReplace);
        board.triggerDamage(damageValue, player, affectedTiles);

    }
}
