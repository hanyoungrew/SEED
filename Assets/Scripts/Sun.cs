using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    
    #region toggle
    public bool on;
    #endregion
    
    #region sun_variables

    [SerializeField]
    GameObject sunlighttoken;

    [SerializeField]
    float leftSpawnTime;
    float leftCurrentSpawnTimer;

    [SerializeField]
    float rightSpawnTime;
    float rightCurrentSpawnTimer;

    #endregion

    #region board_variable

    Board board;
    int leftOffset;
    int rightOffset;
    int boardHeight;

    #endregion

    //spawns a sunlight token at intervals on a random position on the board.
    //once the sunlight token is picked up, reset the cooldown for sunlight tokens to spawn
    //later add ways for the sunlight token to respawn, regardless of being picked up

    // Start is called before the first frame update
    void Start()
    {
        leftCurrentSpawnTimer = leftSpawnTime;
        rightCurrentSpawnTimer = rightSpawnTime;
        board = GameObject.FindGameObjectWithTag("Board").
            GetComponent<Board>();
        boardHeight = board.upOffset + board.downOffset;
        leftOffset = board.leftOffset;
        rightOffset = board.rightOffset;
    }

    // Update is called once per frame
    void Update()
    {

        leftCurrentSpawnTimer -= Time.deltaTime;
        rightCurrentSpawnTimer -= Time.deltaTime;
        
        if (leftCurrentSpawnTimer <= 0)
        {
            spawnRandomSunlight(true);
            leftCurrentSpawnTimer = leftSpawnTime;
        }
        if (rightCurrentSpawnTimer <= 0)
        {
            spawnRandomSunlight(false);
            rightCurrentSpawnTimer = rightSpawnTime;
        }

    }

    private void spawnRandomSunlight(bool playerLeft)
    {
        if (!on){
            return;
        }
        int randomX;
        int randomY;


        //calculate random indices
        Random.seed = System.DateTime.Now.Millisecond;
        if (playerLeft)
        {
            randomX = Random.Range(0, leftOffset);
            randomY = Random.Range(0, boardHeight);
        }
        else
        {
            randomX = Random.Range(leftOffset, leftOffset + rightOffset);
            randomY = Random.Range(0, boardHeight);
        }

        Board.BoardTile curTile = board.IndexToTile(randomX, randomY);

        //if sunlight cannot be accessed by anyone, retry
        while(curTile.getWalkable() == -1){
            Random.seed += 1;
            if (playerLeft)
            {
                randomX = Random.Range(0, leftOffset);
                randomY = Random.Range(0, boardHeight);
            }
            else
            {
                randomX = Random.Range(leftOffset, leftOffset + rightOffset);
                randomY = Random.Range(0, boardHeight);
            }
            curTile = board.IndexToTile(randomX, randomY);
        }

        Vector2 curPos = curTile.getPosition();
        Instantiate(sunlighttoken, new Vector3(curPos.x, curPos.y, -1), Quaternion.identity);
    }
}
