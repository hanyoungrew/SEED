using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaField : Card
{
    Board board;
    Player player;
    Board.BoardTile pointed_tile;
    List<Board.BoardTile> affectedTiles = new List<Board.BoardTile>();
    string form;

    string typeReplace;


    public LavaField()
    {
        damageValue = 0;
        sunlightCost = 5;
        formation = "3X3";
        flavorText = "Set a Field Ablaze";
    }

    public override void Activate(Player player, GameManager control, Board board, Vector2 aim_dir = new Vector2(), Board.BoardTile pointed_tile = null)
    {
        if (player.leftPlayer && control.lSunlightCtr >= sunlightCost)
        {
            control.lSunlightCtr -= sunlightCost;
            startFlash(board, player, 0.1f, pointed_tile, formation, "Lava");
        }

        if (!player.leftPlayer && control.rSunlightCtr >= sunlightCost)
        {
            control.rSunlightCtr -= sunlightCost;
            startFlash(board, player, 0.1f, pointed_tile, formation, "Lava");
        }
    }

    public void startFlash(Board b, Player player, float secondsDelay, Board.BoardTile targetTile,
        string formation, string replaceTypeString)
    {

        board = b;
        this.player = player;
        pointed_tile = targetTile;
        form = formation;
        typeReplace = replaceTypeString;
        affectedTiles = b.ReplaceFormationTiles(targetTile, formation, "Flash", "Wall");

        Invoke("finishFlash", secondsDelay);
    }

    public void finishFlash()
    {
        board.RestoreFormationTiles(affectedTiles, pointed_tile, typeReplace);

    }
}