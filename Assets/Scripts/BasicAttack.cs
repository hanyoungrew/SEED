using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//basic attack projectile. moves straight toward the other side of the field.
public class BasicAttack : MonoBehaviour
{
    //should all be initialized during instantiation
    #region reference_var
    Board board;

    Board.BoardTile curr_tile;
    
    //if spawned by leftPlayer, moves right until out of bounds or crashes into rightPlayer
    bool leftPlayer;

    float damage_multiplier;

    float move_speed;

    #endregion


    #region projectile_var
    //how much time the projectile spends on one tile
    public float base_damage = 1;

    Vector2 curr_dir;
    #endregion


    //needed because need to instantiate projectile and set properties upon instantiation
    #region reference_setters

    public void setPlayer(bool player){
        this.leftPlayer = player;

    }

    public void setDamage(float damage){
        this.damage_multiplier = damage;
    }

    public void setSpeed(float speed){
        this.move_speed = speed;
        
    }

    public void setDirection(Vector2 direction){
        this.curr_dir = direction;
    }

    public void setBoard(Board b){
        this.board = b;
    }
    #endregion

    #region unity_func
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move(){

        Vector2 movementVector = Time.deltaTime * move_speed * curr_dir;

        Vector2 nextPos = (Vector2)gameObject.transform.position + movementVector;
        
        //update position/board position
        gameObject.transform.position = nextPos;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //crash into wall
        if (other.tag == "Wall"){
            Destroy(gameObject);
            return;
        }

        if (other.tag == "WallTile"){
            int remaining_hits = other.GetComponent<WallTileBreaking>().DamageWall();
            if (remaining_hits == 0){
                Board.BoardTile wallT = board.PositionToTile(other.transform.position);
                board.replaceTile(wallT, "Default");
            }
            Destroy(gameObject);
            return;
        }

        
        //inflict damage on Player here
        if ((other.tag == "Right" && leftPlayer) || (other.tag == "Left" && !leftPlayer)) {
            Destroy(gameObject);
            other.GetComponent<Player>().TakeDamage(base_damage * damage_multiplier, false);
        }


    }

    #endregion
}
