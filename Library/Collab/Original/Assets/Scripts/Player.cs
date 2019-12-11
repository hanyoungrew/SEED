using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{


    #region GAMEMANAGER/controller manager
    GameManager control;
    ControllerManager cmanager;

    #endregion

    //variables that are changed in between rounds via upgrades
    #region playerSTATS reference

    PlayerStats stats;
    public float attackStat;

    float speedStat;

    float projectileSpeedStat;

    float basic_attack_duration;
    float sword_attack_duration; 

    float healthStat;

    int sunlightTokens;

    #endregion

    #region controller_inputs
    //InputActions inputActions;
    Vector2 in_movement_dir;
    Vector2 in_aim_dir;

    //not direct input
    Vector2 prev_in_aim_dir;

    Vector2 in_tile_dir;

    float in_attack;
    //not direct input
    bool attacking;

    float in_spell;
    float in_prev;

    float in_next;

    float in_dash;

    float taking_damage;
    float damage_in_progress;
    float damage_timer;
    float on_fire;
    float healing;
    float swordUnlocked; 

    float player_flash; 

    #endregion

    #region player_references


    //the game board
    private Board board;

    //current tile player is on
    RoundUI roundUI;

    public GameObject BasicAttackPrefab;

    //true => left player, false => right player


    #endregion

    #region player var
    public bool leftPlayer;
    Rigidbody2D playerRB;
    SpriteRenderer spriteRenderer;


    #endregion

    #region player colors
    Color pcolor;
    Color heal_color = Color.white;

    Color damage_color = Color.black;

    Color fire_color = Color.red;

    Color play_card_color = Color.blue;
    #endregion
    

    #region player position/tile
    float x_input;
    float y_input;
    private Board.BoardTile curr_tile;

    bool stuckInMud;
    #endregion


    #region aim direction/tile pointer
    
    AimingDirection aimer;
    public TilePointer tilePointer;

    public Board.BoardTile pointed_tile;

    #endregion


    #region attacking_var
    float attack_timer;
    #endregion

    #region health/death/being damaged_var

    // amount of health current
    private float round_health;
    private float base_health;
    bool dead;

    bool isOnLava;
    int onFireTimer = 3;
    int onFireCounter = 0;
    bool lavaCoroutineStarted;

    #endregion

    #region card_management

    //list of cards/card cooldown timers
    public List<(Card, float)> card_holster;
    public int card_index;
    public Card current_card;

    public float card_timer;

    public string current_card_name;

    #endregion

    #region player_animations
    #endregion

    //FUNCTIONS
    #region unityFunc


    // Start is called before the first frame update
    
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        //determine my identity
        int whichPlayer;
        try {
            cmanager = GameObject.Find("ControllerManager").GetComponent<ControllerManager>();
            whichPlayer = cmanager.numPlayers;
            if (whichPlayer == 1) {
                leftPlayer = true;
                gameObject.name = "LeftPlayer";
                gameObject.tag = "Left";

            } else {
                leftPlayer = false;
                gameObject.name = "RightPlayer";
                gameObject.tag = "Right";
            }

        } catch {
            Debug.Log("no controllers");
        }

        //set sprite visuals
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (leftPlayer){
            spriteRenderer.color = Color.green;
            pcolor = Color.green;
        } else {
            spriteRenderer.color =  new Color32(145, 61, 136, 255);
            pcolor =  new Color32(145, 61, 136, 255);
        }


        //set control if game manager is initialized, i.e. started from _preload
        control = GameObject.Find("GameManager").GetComponent<GameManager>();
        //initialize info from game manager/update game manager with reference to player
        if (leftPlayer) {
            stats = control.lStats;
            card_holster = control.leftCardHolster;
            control.lPlayer = this;
        } else {
            stats = control.rStats;
            card_holster = control.rightCardHolster;
            control.rPlayer = this;
        }




    }



    // Update is called once per frame
    void Update()
    {
        if (roundHealthPercentage() <= 0)
        {
            Die();
        }
        
        
        //update card_timer


        //moved

        /* 
        //decrement cooldown if necessary
        if (card_timer > 0){
            card_timer -= Time.deltaTime;
            if (card_timer < 0) {
                card_timer = 0;
            }
            if (leftPlayer){
                control.leftCardHolster[card_index] = (current_card, card_timer);
            } else {
                control.rightCardHolster[card_index] = (current_card, card_timer);
            }
        } 
        */ 

        //flash upon heal/buff
        if (player_flash == 1 && damage_in_progress == 0)
        {
            damage_in_progress = 1;
            Color flashColor = healing == 1 ? heal_color : damage_color;
            if (on_fire == 1) flashColor = fire_color;
            StartCoroutine(playerFlash(flashColor));
            taking_damage = 0;
        }

        if (board != null) {
            curr_tile = board.PositionToTile(playerRB.position);

            //update board's references of player tiles
            if (leftPlayer)
            {
                if (curr_tile != board.leftPlayerTile)
                {
                    board.leftPlayerTile = curr_tile;
                }
            }
            if (!leftPlayer)
            {
                if (curr_tile != board.rightPlayerTile)
                {
                    board.rightPlayerTile = curr_tile;
                }
            }


        }



       
        //tile effects
        if (get_currTile() != null)
        {
            stuckInMud = false;

            if (get_currTile().curTileType() == "Mud")
            {
                stuckInMud = true;
            }


            else if (get_currTile().curTileType() == "Lava")
            {
                if (!lavaCoroutineStarted)
                StartCoroutine(StartBurning());
            }
        }

        //TestMove for keyboard
        TestMove();

        x_input = in_movement_dir.x;
        y_input = in_movement_dir.y;
        attack_timer -= Time.deltaTime;

        //adjust aim pointer
        if (in_aim_dir!= prev_in_aim_dir){
            if (aimer != null) {
                aimer.MoveAimer(in_aim_dir);
                prev_in_aim_dir = in_aim_dir;
            }
        }
        
        //adjust tile pointer
        if (in_tile_dir != Vector2.zero){
            if (!dead && control.roundSafe) {
                tilePointer.UpdateTile(in_tile_dir);
            }
            in_tile_dir = Vector2.zero;
        }

        if (tilePointer != null){
            //read tile pointer
            pointed_tile = tilePointer.PointedTile();
        }




        //Move
        Move();


        if (in_attack != 0) {
            attacking = !attacking;
            if (attacking) {
                BasicAttack();
            }
            in_attack = 0;
        }

        //Prev Card
        if (in_prev != 0) {
            in_prev = 0;
            cyclePrev();
            if (leftPlayer) {
                //Debug.Log(current_card.flavorText);
            }

        }

        //Next Card
        if (in_next != 0) {
            in_next = 0;
            cycleNext();
            if (leftPlayer) {
                //Debug.Log(current_card.flavorText);
            }
        }

        //Card Attack
        if (in_spell != 0)
        {
            in_spell = 0;
            if (leftPlayer)
            {
                //Debug.Log(current_card.flavorText);
            }
            playCard();
        }

        //Dash Attack
        if (in_dash != 0){
            in_dash = 0;
            //do dashing code here
        }

    }


    //private void OnEnable() {
    //    inputActions.Enable();
    //}

    //private void OnDisable() {
    //    inputActions.Disable();

    //}
    #endregion

    #region loading functions

    public void loadPlayer(){

        //REPEAT EVERYTHING PAST THIS BEFORE EVERY ROUND START

        //initialize stats
        attackStat = stats.attackStat;
        speedStat = stats.speedStat;
        projectileSpeedStat = stats.projectileSpeedStat;
        basic_attack_duration = stats.basic_attack_duration;
        sword_attack_duration = stats.sword_attack_duration; 
        healthStat = stats.healthStat;
   
        //initialize local card var
        card_index = 0;
        current_card = card_holster[0].Item1;
        card_timer = card_holster[0].Item2;
        current_card_name = current_card.name;


        //find component references
        board = GameObject.Find("GameBoard").GetComponent<Board>();
        roundUI = GameObject.Find("Round UI").GetComponent<RoundUI>();
        roundUI.UpdatePlayerCard(this);
        playerRB = GetComponent<Rigidbody2D>();
        aimer = GetComponentInChildren<AimingDirection>();
        if (leftPlayer) {
            tilePointer = GameObject.Find("LeftPointer").GetComponent<TilePointer>();           
        } else {
            tilePointer = GameObject.Find("RightPointer").GetComponent<TilePointer>();
        }

        //update components
        tilePointer.leftPlayer = this.leftPlayer;
        if (leftPlayer)
        {
            board.lPlayer = this;
        } else
        {
            board.rPlayer = this;
        }

        //starting position
        if (leftPlayer) {
            playerRB.transform.position = board.lPStartingLoc;
        } else {
            playerRB.transform.position = board.rPStartingLoc;
        }


        //misc
        attacking = false;
        attack_timer = 0;
        dead = false;
        round_health = healthStat;
        stuckInMud = false;
        taking_damage = 0;
        on_fire = 0;
        damage_in_progress = 0;
        damage_timer = 0.5f;
        healing = 0;
        player_flash = 0;
        isOnLava = false;
        lavaCoroutineStarted = false;
        swordUnlocked = 0; 
        //lol intialize control vectors so no weird glitches
        in_movement_dir = Vector2.zero;
        in_aim_dir = Vector2.up;

    }


    #endregion


    #region control functions


    private void OnMove(InputValue val) {
        in_movement_dir = val.Get<Vector2>().normalized;

    }

    private void OnAimPointer(InputValue val) {
        Vector2 signal = val.Get<Vector2>().normalized;
        if (signal != Vector2.zero) {
            in_aim_dir = signal;
        }
    }

    private void OnTileSelectionPointer(InputValue val) {
        in_tile_dir = val.Get<Vector2>().normalized;
    }

    private void OnBasicAttack() {

        in_attack = 1;
    }

    private void OnCastSpell() {
        //Debug.Log("");

        in_spell = 1;
    }

    private void OnPrevSpell() {
        //Debug.Log("");
        in_prev = 1;

    }


    private void OnNextSpell() {
        //Debug.Log("");
        in_next = 1;

    }

    private void OnDash() {
        //Debug.Log("");
        in_dash = 1;

    }

    #endregion

    #region basic_movement
    // moves one unit in a direction
    void Move() {
        if (!control.roundSafe){
            if (playerRB != null){
                playerRB.velocity = Vector2.zero;
            }
        }

        if (attack_timer <= 0 && (!dead && control.roundSafe)) {
            Vector2 movementVector = new Vector2(x_input, y_input) * Time.deltaTime * speedStat;
            
            if (stuckInMud) {
                movementVector = movementVector / 2;
            }
            
            playerRB.velocity = movementVector * 100;
            
            
            //Board.BoardTile nextTile = board.PositionToTile(nextPos);
            //if (nextTile != null && nextTile.CanBeAccessedBy(leftPlayer)) {
            //    playerRB.MovePosition(nextPos);
            //}
        } 
    }

    //just for testing
    void TestMove()
    {
        if (leftPlayer)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                in_movement_dir = Vector2.up;
            }
            else if(Input.GetKeyDown(KeyCode.A))
            {
                in_movement_dir = Vector2.left;
            }
            else if(Input.GetKeyDown(KeyCode.S))
            {
                in_movement_dir = Vector2.down;
            }
            else if(Input.GetKeyDown(KeyCode.D))
            {
                in_movement_dir = Vector2.right;
            } 



            if (Input.GetKeyDown(KeyCode.Space)){    
                in_attack = 1;
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                in_spell = 1;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                in_next = 1;
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                in_prev = 1;
            }

        }
        if (!leftPlayer)
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                in_movement_dir = Vector2.up;
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                in_movement_dir = Vector2.down;
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                in_movement_dir = Vector2.left;
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                in_movement_dir = Vector2.right;
            }
            
        }
    }


    #endregion

    #region basic_attack

    public void BasicAttack() {
        if (!dead && attacking) {
            if (attack_timer <= 0) {
                attack_timer = basic_attack_duration;
                StartCoroutine(BasicAttackRoutine());
            }
        }
    }

    //public void SwordAttack()
    //{
    //    if (!dead && attacking)
    //    {
    //        if (attack_timer <= 0)
    //        {
    //            attack_timer = sword_attack_duration;
    //            StartCoroutine(SwordAttackRoutine());
    //        }
    //    }
    //}

    //IEnumerator SwordAttackRoutine()
    //{
    //    Vector2 curPos = playerRB.position;

    //    GameObject swordSprite = Instantiate()

    //}

    IEnumerator BasicAttackRoutine() {

        while (!dead && control.roundSafe){
            if (!attacking){
                break;
            }
            //ANIMATION HERE
            yield return null;

            //instantiate/initialize the BasicAttack proectile

            Vector2 spawnPos = playerRB.position;
            GameObject basicAttack = (GameObject)Instantiate(BasicAttackPrefab, spawnPos, Quaternion.identity);

            //essentially the Awake function
            BasicAttack projectile = basicAttack.GetComponent<BasicAttack>();
            projectile.setPlayer(leftPlayer);
            projectile.setDamage(1 * attackStat);
            projectile.setSpeed(1 * projectileSpeedStat);
            projectile.setDirection(in_aim_dir);
            projectile.setBoard(board);

            yield return new WaitForSeconds(0.1f);
            //ANIMATION HERE
            yield return null;
        }

    }
    #endregion

    #region health/damage/death_func
    public void TakeDamage(float amount, bool isHealing)
    {
        if (control.roundSafe) {
            // Reduce the current health by the damage amount.
            round_health -= amount;
            if (round_health > healthStat){
                round_health = healthStat;
            }
            roundUI.UpdatePlayerHealth(leftPlayer, this);
            //Debug.Log(damage_amt.ToString() + " ayyy");
            if (isHealing)
            {
                healing = 1; 
            } else
            {
                taking_damage = 1;
                healing = 0; 
            }
            player_flash = 1;
        }
    }
    //get the player's current roundHealth
    public float roundHealthPercentage() {

        return (this.round_health / healthStat);
    }



     public void Die()
    {
        // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
        //playerAudio.clip = deathClip;
        //playerAudio.Play();
        //also ANIMATION
        //Debug.Log("PLAYER DEAD");
        //if already dead do nothing
        if (dead){
            return;
        }
        if (control.roundSafe){
            dead = true;
            StartCoroutine("DieRoutine");
        }

    }

    IEnumerator DieRoutine() {
        //wait for length of death animation/hurtsound
        yield return new WaitForSeconds(.1f);
        if (leftPlayer) {
            control.leftPlayerDead();
        } else {
            control.rightPlayerDead();
        }

    }

    #endregion

    #region misc
    //flash upon hit/heal/buff
    IEnumerator playerFlash(Color changeColor)
    {
        if (dead){
            yield break;
        }
        Color oldColor = pcolor;
        spriteRenderer.color = changeColor;
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = oldColor; 
        damage_in_progress = 0;
        player_flash = 0;
        healing = 0; 
    }

    #endregion

    #region update sunlight counter
    public void updateSunlightCounter() {
        if (leftPlayer) {
            control.lSunlightCtr += 1;
        } else {
            control.rSunlightCtr += 1;
        }
        //Debug.Log("leftsunlight counter" + control.lSunlightCtr);
        //Debug.Log("rightsunlight counter" + control.rSunlightCtr);
    }
    #endregion

    #region card_selection/playing
    public void cyclePrev()
    {
        if (!dead && control.roundSafe) {
            if (card_index == 0) {
                card_index = card_holster.Count - 1;
            } else {
                card_index -= 1;
            }
            UpdateCurrentCard();
        }
    }

    public void cycleNext()
    {
        if (!dead && control.roundSafe) {
            card_index = (card_index + 1) % card_holster.Count;
            UpdateCurrentCard();
        }
    }

    public void UpdateCurrentCard()
    {
        current_card = card_holster[card_index].Item1;
        card_timer = card_holster[card_index].Item2;
        roundUI.UpdatePlayerCard(this);
    }

    public void playCard()
    {
        if (card_holster[card_index].Item2 == 0) {
            if (!dead && control.roundSafe) {



                //find condition based off if we have enough sunlight tokens
                //color flash to indicate card only happens if we have enough sunlight tokens
                int sunlightTokenss;
                if (leftPlayer){
                    sunlightTokenss = Int32.Parse(control.leftSunlight());

                } else {
                    sunlightTokenss = Int32.Parse(control.rightSunlight());
                }

                if (sunlightTokenss >= current_card.sunlightCost){
                    StartCoroutine(playerFlash(play_card_color));
                    current_card.Activate(this, control, board, in_aim_dir, pointed_tile);
                    card_holster[card_index] = (card_holster[card_index].Item1, current_card.cooldownTime);
                    
                    //Debug.Log(card_timer);
                }

            }



        }
        

    }

    #endregion




    #region burning_coroutine
    //UPDATE targetTile to always be curr_tile pointer
    IEnumerator StartBurning()
    {
        Debug.Log("started burning");
        if (onFireCounter == 0)
        {
            onFireCounter = onFireTimer;
        }

        while (onFireCounter > 0)
        {
            if (!lavaCoroutineStarted)
            {
                onFireCounter = onFireTimer;
                lavaCoroutineStarted = true;
                on_fire = 1; 
            }
            onFireCounter--;
            TakeDamage(0.5f, false);
            yield return new WaitForSeconds(1);
        }

        lavaCoroutineStarted = false;
        on_fire = 0;
    }

    #endregion

    #region GETTERS
    public Board.BoardTile get_currTile()
    {
        return curr_tile;
    }
    #endregion
}