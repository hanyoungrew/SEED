using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dominance : Card
{
    Board board;
    Player player;
    Board.BoardTile pointed_tile;
    List<Board.BoardTile> affectedTiles = new List<Board.BoardTile>();
    string form;

    string typeReplace;


    public Dominance()
    {
        damageValue = 1f;
        sunlightCost = 7;
        formation = "Plus";
        flavorText = "ROW-COL attack";
    }

    public override void Activate(Player player, GameManager control, Board board, Vector2 aim_dir = new Vector2(), Board.BoardTile pointed_tile = null)
    {
        if (player.leftPlayer && control.lSunlightCtr >= sunlightCost)
        {
            control.lSunlightCtr -= sunlightCost;
            startFlash(board, player, 0.1f, pointed_tile, formation, "Dirt");
        }

        if (!player.leftPlayer && control.rSunlightCtr >= sunlightCost)
        {
            control.rSunlightCtr -= sunlightCost;
            startFlash(board, player, 0.1f, pointed_tile, formation, "Dirt");
        }
        player.playSound("Dominance");
    }

    public void startFlash(Board b, Player player, float secondsDelay, Board.BoardTile targetTile,
        string formation, string replaceTypeString)
    {

        board = b;
        this.player = player;
        pointed_tile = targetTile;
        form = formation;
        typeReplace = replaceTypeString;
        affectedTiles = b.ReplaceFormationTiles(targetTile, formation, "Flash", "");

        Invoke("finishFlash", secondsDelay);
    }

    public void finishFlash()
    {
        board.RestoreFormationTiles(affectedTiles, pointed_tile, typeReplace);
        board.triggerDamage(damageValue, player, affectedTiles);

    }
}