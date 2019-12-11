using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePointer : MonoBehaviour
{
    Board.BoardTile curr_tile;

    Board board;

    public bool leftPlayer;

    private void Awake(){
        board = GameObject.Find("GameBoard").GetComponent<Board>();
        curr_tile = board.PositionToTile(this.transform.position);
    }

    public void AwakePlayer(bool lP){
        leftPlayer = lP;
    }

    public void UpdateTile(Vector2 pd) {
        if (pd != Vector2.zero){
            Board.BoardTile x = null;
            if (pd == Vector2.left){
                x = board.Left(curr_tile);
            } else if (pd == Vector2.right) {
                x = board.Right(curr_tile);
            } else if (pd == Vector2.up) {
                x = board.Up(curr_tile);
            } else if (pd == Vector2.down) {
                x = board.Down(curr_tile);
            }

            if (x != null){
                curr_tile = x;
                this.transform.position = curr_tile.getPosition();
            }
        }

    }

    public Board.BoardTile PointedTile(){
        return curr_tile;
    }

}