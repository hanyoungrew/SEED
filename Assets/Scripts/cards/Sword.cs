using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Card
{

	#region temp workaround_for_coroutine_nonsense_bug
	Board board;
	Player player;
	Board.BoardTile pointed_tile;
	List<Board.BoardTile> affectedTiles = new List<Board.BoardTile>();
	string form;

	string typeReplace;

	#endregion


	public Sword()
	{
		damageValue = 20;
		sunlightCost = 10;
		flavorText = "A sword of holy starch.";

	}

	public override void Activate(Player player, GameManager control, Board board, Vector2 aim_dir = new Vector2(), Board.BoardTile pointed_tile = null)
	{
		//player.activateSword();
	}
}
