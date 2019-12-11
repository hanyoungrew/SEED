using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    #region board_state_var
    //scalar by which tiles are centered. by default, tiles are 1 unit by 1 unit.
    public int tileScale = 1;

    //offset number of tiles from center of board

    public int downOffset;    

    public int upOffset;

    public int leftOffset;

    public int rightOffset;

    public int holes;

    public int walls;
    

    //stores game logic constructs
    private BoardTile[,] boardArray;
    public BoardTile leftPlayerTile;
    public BoardTile rightPlayerTile;

    public BoardTile leftBoardCardPointer;
    public BoardTile rightBoardCardPointer;
  
    //stores sprites
    //2D array, indexed by x_index, y_index => tile
    private GameObject[,] tileArray;
    #endregion

    #region player_variables

    public Player lPlayer;
    public Player rPlayer;

    public Vector2 lPStartingLoc;
    public Vector2 rPStartingLoc;

    #endregion

    #region GameManager

    public GameManager control;

    #endregion

    #region Tile Sprites
    public GameObject DefaultTile;
    public GameObject HoleTile;
    public GameObject WallTile;
    public GameObject LavaTile;
    public GameObject FlashTile;
    public GameObject StoneTile;
    public GameObject DirtTile;
    public GameObject MudTile;
    #endregion



    #region Unity Functions
    //instantiates Tiles
    void Awake()
    {
        int numTiles = (leftOffset + rightOffset) * (downOffset + upOffset);
        holes = Mathf.Min(holes, numTiles);
        walls = Mathf.Min(walls, numTiles - holes);

        boardArray = new BoardTile[leftOffset + rightOffset,  downOffset + upOffset];
        tileArray = new GameObject[leftOffset + rightOffset, downOffset + upOffset];
        // i is width offset, j is height offset, i.e. # of tiles
        //(i,j) corresponds to tile with southwest corner being (i,j) * tileScale

        for (int i = -leftOffset; i < rightOffset; i++)
        {
            for (int j = -downOffset; j < upOffset; j++)
            {
                //center of the tile position
                float xPos = (i + 0.5f) * tileScale;
                float yPos = (j + 0.5f) * tileScale;
                
                int x_index = i + leftOffset;
                int y_index = j + downOffset;

                //10/27 changed implementation to have all board tiles simply be accessible by everyone by default
                //bool leftPlayer = (i < 0);

                boardArray[x_index,  y_index] = new BoardTile(x_index, y_index, xPos, yPos, 2, true);

                //if (leftPlayer){
                tileArray[x_index, y_index] = Instantiate(DefaultTile, new Vector3(xPos, yPos, 0), Quaternion.identity);
                //} else {
                //    Instantiate(RightTile, new Vector3(xPos, yPos, 0), Quaternion.identity);
                //}
            }
        }

        control = GameObject.Find("GameManager").GetComponent<GameManager>();
        //lPlayer = GameObject.Find("LeftPlayer").GetComponent<Player>();
        //rPlayer = GameObject.Find("RightPlayer").GetComponent<Player>();

        leftPlayerTile = PositionToTile(lPStartingLoc);
        rightPlayerTile = PositionToTile(rPStartingLoc);

        //i think 1/8 tiles being a hole, 1/8 tiles being a wall is good?
        //this is assuming 4x8 = 32 total tiles, so 8 are obstacles
        generateHoles_Walls(holes, walls);
    }

    #endregion
    private void Update() {
        //Debug.Log(leftPlayerTile.getPosition());

    }


    #region Basic Board API
    //get board tile corresponding to a position. returns null if out of bounds
    public BoardTile PositionToTile(Vector2 position){
        float x = position.x;
        float y = position.y;

        // i => ith tile (negative means left, positive means right)
        int i = (int) Mathf.Floor(x / tileScale);
        int j = (int) Mathf.Floor(y / tileScale);
                
        int x_index = i + leftOffset;
        int y_index = j + downOffset;

        BoardTile tile = null;

        if (x_index < 0 || y_index < 0){
            return null;
        }

        if (x_index >= (leftOffset + rightOffset) || y_index >= (upOffset + downOffset)){
            return null;
        }

        tile = boardArray[x_index, y_index];

        return tile;
    }

    //get board index corresponding to a position, returns null if out of bounds
    public Vector2? BoardIndices(Vector2 position){
        float x = position.x;
        float y = position.y;

        // i => ith tile (negative means left, positive means right)
        int i = (int) Mathf.Floor(x / tileScale);
        int j = (int) Mathf.Floor(y / tileScale);
                
        float x_index = i + leftOffset;
        float y_index = j + downOffset;

        if ((x_index < 0) || (y_index < 0)){
            return null;
        } else {
            return new Vector2(x_index, y_index);
        }

    }

    //for sunlight token spawner
    public BoardTile IndexToTile(int x, int y){
        return boardArray[x, y];
    }


    //given a valid BoardTile, returns next tile in said direction. returns null if next one is out of bounds.
    #region board direction

    public BoardTile safeAccess(int x, int y){
        if (x < 0 || y < 0){
            return null;
        }

        if (x >= (leftOffset + rightOffset) || y >= (upOffset + downOffset)){
            return null;
        }
        else {
            return boardArray[x,y];
        }
    }


    public BoardTile Up(BoardTile curr){

        return safeAccess(curr.getXIndex(), curr.getYIndex() + 1);
    }

    public BoardTile Left(BoardTile curr){

        return safeAccess(curr.getXIndex() - 1, curr.getYIndex());
    }

    public BoardTile Right(BoardTile curr){



        return safeAccess(curr.getXIndex() + 1, curr.getYIndex());
    }

    public BoardTile Down(BoardTile curr){


        return safeAccess(curr.getXIndex(), curr.getYIndex() - 1);
    }

    public BoardTile TopLeft(BoardTile curr)
    {

        return safeAccess(curr.getXIndex() - 1, curr.getYIndex() + 1);
    }

    public BoardTile TopRight(BoardTile curr)
    {

        return safeAccess(curr.getXIndex() + 1, curr.getYIndex() + 1);

    }

    public BoardTile DownLeft(BoardTile curr)
    {

        return safeAccess(curr.getXIndex() - 1, curr.getYIndex() - 1);

    }

    public BoardTile DownRight(BoardTile curr)
    {

        return safeAccess(curr.getXIndex() + 1, curr.getYIndex() - 1);

    }

    #endregion

    #endregion

    #region BoardTileClass
    public class BoardTile {
       
        #region BoardTile_var

        //walkable = -1 => no player can walk on block
        // 0 => only left player can walk on block
        // 1 => only right player can walk on block
        // 2 => both players can walk on block
        int walkable;

        //i.e. can a projectile pass through this tile
        bool projectile_passable;

        //used by x_index
        int x_index;

        int y_index; 

        //centered position of board tile
        Vector2 position;
        #endregion

        #region tile_variety

        string tileType; 

        #endregion


        #region internal_tile_timers

        bool lavaDurationExpected;
        bool lavaCurrentTimer;

        #endregion

        //constructor from indices
        public BoardTile(int x_index, int y_index, float xPos, float yPos, int walkable, bool proj_passable) 
        { 
            this.walkable = walkable;
            projectile_passable = proj_passable;
            position = new Vector2(xPos, yPos);
            this.x_index = x_index;
            this.y_index = y_index;
            tileType = "Default";
        }

        #region getters

        public int getWalkable(){
            return  walkable;
        }

        public bool getPassable(){
            return  projectile_passable;
        }

        public int getXIndex(){
            return  x_index;
        }

        public int getYIndex(){
            return  y_index;
        }

        public Vector2 getPosition(){
            return position;
        }
        public string curTileType()
        {
            return tileType;
        }
        #endregion 


        #region setters
        public void setWalkable(int w){
            walkable = w;
        }
        public void setPassable(bool p){
            projectile_passable = p;
        }
        public void setTileType(string newTileType)
        {
            tileType = newTileType;
        }
        #endregion


        #region misc_methods
        //returns whether a player can access a board tile
        public bool CanBeAccessedBy(bool player){
            
            if (walkable == -1){
                return false;
            //if left player on right player tile
            } else if (player && walkable == 1){
                return false;
            //if right player on left player tile
            } else if (!player && walkable == 0){
                return false;
            } else {
                return true;
            }
            
        }

        public bool isOpponentHereBoardTile(BoardTile opponentTile)
        {
            return this == opponentTile;
        }

        #endregion

    }

    #endregion


    #region Changing Board Tiles/Sprites

    //get reference to game object from tile
    public GameObject tileCorrespondingObject(BoardTile tile){
        int x_index = tile.getXIndex();
        int y_index = tile.getYIndex();
        
        return tileArray[x_index, y_index];
    }


    //replace the sprite corresponding to board tile with a replacement sprite.
    //Does not do anything with board tile logic, don't forget to update that separately.
    public void replaceSprite(BoardTile change, GameObject replacement) {
        int x_index = change.getXIndex();
        int y_index = change.getYIndex();

        Destroy(tileArray[x_index, y_index]);

        Vector2 pos = change.getPosition();
        
        tileArray[x_index, y_index] = Instantiate(replacement, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
    }


    //replaces tile at position with hole tile. updates board tile to be a hole
    //walkable = -1 => no player can walk on block
    // 0 => only left player can walk on block
    // 1 => only right player can walk on block
    // 2 => both players can walk on block
    public void replaceTileWithDefault(BoardTile change)
    {
        replaceSprite(change, DefaultTile);
        change.setWalkable(2);
        change.setPassable(true);
        change.setTileType("Default");

    }

    public bool replaceTileWithHole(BoardTile change) {
        if (leftPlayerTile == change || rightPlayerTile == change){
            //Debug.Log("cant spawn hole on player");
            return false;
        }  else {
            replaceSprite(change, HoleTile);
            change.setWalkable(-1);
            change.setPassable(true);
            change.setTileType("Hole");
            return true;
        }


    }

    public bool replaceTileWithWall(BoardTile change) {
        if (leftPlayerTile == change || rightPlayerTile == change){
            //Debug.Log("cant spawn wall on player");
            return false;
        }  else {
            replaceSprite(change, WallTile);
            change.setWalkable(-1);
            change.setPassable(false);
            change.setTileType("Wall");
            return true;
        }
    }

    public void replaceTileWithLava(BoardTile change)
    {
        replaceSprite(change, LavaTile);
        change.setPassable(true);
        change.setWalkable(2);
        change.setTileType("Lava");
        StartCoroutine(revertTileTimer(change, 10f, "Lava", "Stone"));
    }

    public void replaceTileWithFlash(BoardTile change)
    {
        replaceSprite(change, FlashTile);
        change.setWalkable(2);
        change.setPassable(true);
        change.setTileType("Flash");
    }

    public void replaceTileWithStone(BoardTile change)
    {
        replaceSprite(change, StoneTile);
        change.setWalkable(2);
        change.setPassable(true);
        change.setTileType("Stone");
    }


    public void replaceTileWithDirt(BoardTile change)
    {
        replaceSprite(change, DirtTile);
        change.setWalkable(2);
        change.setPassable(true);
        change.setTileType("Dirt");
    }

    public void replaceTileWithMud(BoardTile change)
    {
        replaceSprite(change, MudTile);
        change.setWalkable(2);
        change.setPassable(true);
        change.setTileType("Mud");
        StartCoroutine(revertTileTimer(change, 10f, "Mud", "Dirt"));
    }

    IEnumerator revertTileTimer(BoardTile targetTile, float timer, string desiredType, string revertType)
    {
        yield return new WaitForSeconds(timer);
        //if the targetTile is still the desiredType, revert it
        if (targetTile.curTileType() == desiredType)
        {
            replaceTile(targetTile, revertType);
        }
    }


    /* Larger function that figures which sort of tile to replace the targetTile with */
    public void replaceTile(BoardTile targetTile, string type)
    {
        switch (type)
        {
            case (null): break;
            case "": break;
            case "Default":
                replaceTileWithDefault(targetTile);
                break;
            case "Lava":
                replaceTileWithLava(targetTile);
                break;
            case "Wall":
                replaceTileWithWall(targetTile);
                break;
            case "Hole":
                replaceTileWithHole(targetTile);
                break;
            case "Flash":
                replaceTileWithFlash(targetTile);
                break;
            case "Stone":
                replaceTileWithStone(targetTile);
                break;
            case "Dirt":
                replaceTileWithDirt(targetTile);
                break;
            case "Mud":
                replaceTileWithMud(targetTile);
                break;                 
        }
    }

    #endregion

    #region Hole/WallSpawner
    

    public void generateHoles_Walls(int holes, int walls){

        HashSet<BoardTile> obstacles = new HashSet<BoardTile>();
        //add starting locations of player tiles so that you cant place another wall/hole there
        obstacles.Add(leftPlayerTile);
        obstacles.Add(rightPlayerTile);


        //generate holes
        for(int i = 0; i < holes; i++){
            Random.seed = System.DateTime.Now.Millisecond + i;
            int randomX = Random.Range(0,  leftOffset + rightOffset);
            int randomY = Random.Range(0, upOffset + downOffset);
            BoardTile curTile = IndexToTile(randomX, randomY);

            //try again if chosen tile already in obstacle
            while(obstacles.Contains(curTile)){
                Random.seed += 1;
                randomX = Random.Range(0,  leftOffset + rightOffset);
                randomY = Random.Range(0, upOffset + downOffset);
                curTile = IndexToTile(randomX, randomY);
            }
            replaceTileWithHole(curTile);
            obstacles.Add(curTile);
        }

        //generate walls
        for(int i = 0; i < walls; i++){
            Random.seed = System.DateTime.Now.Millisecond + i;
            int randomX = Random.Range(0,  leftOffset + rightOffset);
            int randomY = Random.Range(0, upOffset + downOffset);
            //Debug.Log(randomX);
            //Debug.Log(randomY);
            BoardTile curTile = IndexToTile(randomX, randomY);

            //try again if chosen tile already in obstacle
            while(obstacles.Contains(curTile)){
                Random.seed += 1;
                randomX = Random.Range(0,  leftOffset + rightOffset);
                randomY = Random.Range(0, upOffset + downOffset);
                curTile = IndexToTile(randomX, randomY);
            }
            replaceTileWithWall(curTile);
            obstacles.Add(curTile);
        }

    }
    #endregion

    #region advanced Board API

    //do damage to all the affected tyles to opponent
    public void triggerDamage(float damage_amt, Player playerWhoCast,
        List<Board.BoardTile> affectedTiles)
    {
        bool isleftPlayer = playerWhoCast.leftPlayer;
        BoardTile opponentTile = isleftPlayer ? rPlayer.get_currTile() : lPlayer.get_currTile();
        Player opponent = isleftPlayer ? rPlayer : lPlayer;

        //Debug.Log(damage_amt.ToString() + " ayyy");


        CallForDamageOnTiles(damage_amt, opponent, opponentTile, affectedTiles);
    }

    //helper for triggerDamage
    public void CallForDamageOnTiles(float damage_amt, Player opponent, BoardTile opponentTile, List<BoardTile> affectedTiles)
    {
        foreach (BoardTile curTile in affectedTiles)
        {
            if (curTile != null)
            {
                if (curTile.isOpponentHereBoardTile(opponentTile))
                {
                    opponent.TakeDamage(damage_amt, false);
                    break;
                }
            }
        }
    }


    //is the opponent currently here
    public bool isOpponentHere(BoardTile targetTile, bool leftPlayer)
    {
        if (leftPlayer && targetTile == rPlayer.get_currTile())
        {
            return true; 
        }

        if (!leftPlayer && targetTile == lPlayer.get_currTile())
        {
            return true; 
        }

        return false;

    }

    //replacing and restoring tiles via formation
    //instead of replacing walls, damage them!
    //returns a bool, i.e. has wall been destroyed yet
    //true if destroyed
    //false if still standing

    //right now k is the default damage to wall
    int k = 10;
    public bool damageWall(BoardTile tile){
        GameObject walltile = tileCorrespondingObject(tile);
        for (int i = 0; i < k; i++) {
            int remaining_hits = walltile.GetComponent<WallTileBreaking>().DamageWall();
            if (remaining_hits == 0){
                Board.BoardTile wallT = this.PositionToTile(walltile.transform.position);
                this.replaceTile(wallT, "Default");
                return true;
            }
        }
        return false;
    }

    public List<Board.BoardTile> ReplaceFormationTiles(BoardTile targetTile, string form, string tileType, string exceptionType)
    {

        List<Board.BoardTile> returnTiles = formation(targetTile, form, exceptionType);

        foreach (BoardTile curTile in returnTiles)
        {
            if (curTile.curTileType() == "Wall"){
                damageWall(curTile);
            } else {
                
                replaceTile(curTile, tileType);

            }

        }

        return returnTiles;
    }

    public void RestoreFormationTiles(List<Board.BoardTile> tilesToDeflash, Board.BoardTile targetTile, string replaceTileString)
    {
        foreach (Board.BoardTile curActiveFlashTile in tilesToDeflash)
        {
            //if a player is sitting on the selected tile, you cannot change that tile to be a wall, to avoid having players be stuck in walls
            //therefore if we are trying to replace walls, replace with dirt instead
            bool p_on_wall_tile = (replaceTileString == "Wall") && ((curActiveFlashTile == leftPlayerTile) || (curActiveFlashTile == rightPlayerTile));
            if (!p_on_wall_tile){

                //if wall do nothing, cannot cause flash on wall tile
                if (curActiveFlashTile.curTileType() == "Wall"){
                    //Debug.Log("wall detected");
                } else {
                    replaceTile(curActiveFlashTile, replaceTileString);
                }
                //} else {
                //}

            } else {
                if (curActiveFlashTile.curTileType() == "Flash"){
                    replaceTile(curActiveFlashTile, "Dirt");
                }
            }


            


        }

        if (replaceTileString != null)
        {
            if (replaceTileString == "Wall"){
                //
                //replaceTile(targetTile, "Dirt");
                //replaceTile(targetTile, replaceTileString);


            } else  {
                replaceTile(targetTile, replaceTileString);
            }

            

        }
    }

    //helper function for matching formations, to be extended
    public List<Board.BoardTile> formation(BoardTile targetTile, string form, string exceptionTypes) {

        List<Board.BoardTile> returnTiles = new List<Board.BoardTile>();
        if (form != "3X3Not")
        {
            returnTiles.Add(targetTile);
        }
        BoardTile up = Up(targetTile);
        BoardTile down = Down(targetTile);
        BoardTile left = Left(targetTile);
        BoardTile right = Right(targetTile);
        BoardTile topLeft = TopLeft(targetTile);
        BoardTile topRight = TopRight(targetTile);
        BoardTile botLeft = DownLeft(targetTile);
        BoardTile botRight = DownRight(targetTile);
        
        //add more here

        if (form == "Cross")
        {
            if (up != null && up.curTileType() != exceptionTypes) returnTiles.Add(up);
            if (left != null && left.curTileType() != exceptionTypes) returnTiles.Add(left);
            if (right != null && right.curTileType() != exceptionTypes) returnTiles.Add(right);
            if (down != null && down.curTileType() != exceptionTypes) returnTiles.Add(down);
        }

        if (form == "3X3")
        {
            if (up != null && up.curTileType() != exceptionTypes) returnTiles.Add(up);
            if (left != null && left.curTileType() != exceptionTypes) returnTiles.Add(left);
            if (right != null && right.curTileType() != exceptionTypes) returnTiles.Add(right);
            if (down != null && down.curTileType() != exceptionTypes) returnTiles.Add(down);
            if (topLeft != null && topLeft.curTileType() != exceptionTypes) returnTiles.Add(topLeft);
            if (topRight != null && topRight.curTileType() != exceptionTypes) returnTiles.Add(topRight);
            if (botLeft != null && botLeft.curTileType() != exceptionTypes) returnTiles.Add(botLeft);
            if (botRight != null && botRight.curTileType() != exceptionTypes) returnTiles.Add(botRight);
        }

        if (form == "3X3Not")
        {
            if (up != null && up.curTileType() != exceptionTypes) returnTiles.Add(up);
            if (left != null && left.curTileType() != exceptionTypes) returnTiles.Add(left);
            if (right != null && right.curTileType() != exceptionTypes) returnTiles.Add(right);
            if (down != null && down.curTileType() != exceptionTypes) returnTiles.Add(down);
            if (topLeft != null && topLeft.curTileType() != exceptionTypes) returnTiles.Add(topLeft);
            if (topRight != null && topRight.curTileType() != exceptionTypes) returnTiles.Add(topRight);
            if (botLeft != null && botLeft.curTileType() != exceptionTypes) returnTiles.Add(botLeft);
            if (botRight != null && botRight.curTileType() != exceptionTypes) returnTiles.Add(botRight);
        }

        if (form == "Plus")
        {
            foreach (BoardTile curTile in ColumnTiles(targetTile))
            {
                if (curTile.curTileType() != exceptionTypes) returnTiles.Add(curTile);
            }

            foreach (BoardTile curTile in RowTiles(targetTile))
            {
                if (curTile.curTileType() != exceptionTypes) returnTiles.Add(curTile);
            }
        }


        return returnTiles;
    }

    public List<Board.BoardTile> RowTiles(BoardTile curr)
	{
		List<BoardTile> affectedTiles = new List<BoardTile>();
		int x_ind = curr.getXIndex();
		int height = upOffset + downOffset;

        for (int i = 0; i < height; i++)
		{
			affectedTiles.Add(boardArray[x_ind, i]);
		}
		return affectedTiles;
	}

	public List<Board.BoardTile> ColumnTiles(BoardTile curr)
	{
		List<BoardTile> affectedTiles = new List<BoardTile>();
		int y_ind = curr.getYIndex();
		int width = leftOffset + rightOffset;

		for (int i = 0; i < width; i++)
		{
			affectedTiles.Add(boardArray[i, y_ind]);
		}
		return affectedTiles;
	}


    #endregion




}
