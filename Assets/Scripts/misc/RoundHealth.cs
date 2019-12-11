//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class Health : MonoBehaviour
//{
//	public float maxHealth;                                     // The amount of health the player starts the game with.
//	public float current_round_health;                                 // The current health the player has.
//	public Slider LeftHP;                                        // Reference to the UI's health bar.
//	public Slider RightHP;                                        // Reference to the UI's health bar.

//	//public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
//	//public AudioClip deathClip;                                 // The audio clip to play when the player dies.
//	//public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
//	//public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.

//	Animator anim;                                              // Reference to the Animator component.
//    AudioSource playerAudio;                                    // Reference to the AudioSource component.
//    Player player;                                              // Reference to the Player script.
//    bool isDead;                                                // Whether the player is dead.
//    bool damaged;                                               // True when the player gets damaged.


//    void Awake()
//    {
//        // Setting up the references.
//        anim = GetComponent<Animator>();
//        playerAudio = GetComponent<AudioSource>();
//		// Set the initial health of the player.
//		current_round_health = maxHealth;
//    }


//    void Update()
//    {

//        // ##UI to make the damage image flah upon taking damage
//        //// If the player has just been damaged...
//        //if (damaged)
//        //{
//        //    // ... set the colour of the damageImage to the flash colour.
//        //    damageImage.color = flashColour;
//        //}
//        //// Otherwise...
//        //else
//        //{
//        //    // ... transition the colour back to clear.
//        //    damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
//        //}

//        //// Reset the damaged flag.
//        //damaged = false;
//    }


//    public void TakeDamage(int amount)
//    {
//        // Set the damaged flag so the screen will flash.
//        damaged = true;

//        // Reduce the current health by the damage amount.
//        current_round_health -= amount;

//        // Set the health bar's value to the current health.
//        healthSlider.value = current_round_health/ maxHealth;

//        //// Play the hurt sound effect.
//        //playerAudio.Play();

//        // If the player has lost all it's health and the death flag hasn't been set yet...
//        if (current_round_health <= 0 && !isDead)
//        {
//            // ... it should die.
//            Death();
//        }
//    }

//	void Death()
//    {
//        // Set the death flag so this function won't be called again.
//        isDead = true;

//		// Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
//		//playerAudio.clip = deathClip;
//		//playerAudio.Play();
//    }
//}



//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class Player : MonoBehaviour
//{

//	#region player_var
//	//true => left player, false => right player
//	public bool leftPlayer;

//	//the game board
//	private Board board;

//	//current tile player is on
//	private Board.BoardTile curr_tile;

//	public GameObject BasicAttackPrefab;
//	#endregion

//	#region movement_var
//	float x_input;
//	float y_input;

//	Vector2 curr_dir;

//	public float movement_cooldown;
//	//can move when movement_timer <= 0
//	float movement_timer;
//	#endregion

//	#region attacking_var
//	float basic_attack_duration;
//	float attack_timer;
//	#endregion

//	#region health_var
//	public float maxHealth;                                     // The amount of health the player starts the game with.
//	public float LeftRoundHealth;                               // The current health the LEFT player has.
//	public float RightRoundHealth;                               // The current health the RIGHT player has.
//	public Slider LeftHP;                                        // Reference to the UI's health bar.
//	public Slider RightHP;                                        // Reference to the UI's health bar.
//	bool isDead;
//	#endregion

//	#region playerComponents
//	Rigidbody2D playerRB;

//	#endregion

//	#region unityFunc

//	// Start is called before the first frame update
//	void Awake()
//	{
//		board = GameObject.Find("GameBoard").transform.GetComponent<Board>();
//		playerRB = GetComponent<Rigidbody2D>();
//		movement_timer = 0;
//		attack_timer = 0;
//		LeftRoundHealth = maxHealth;
//		RightRoundHealth = maxHealth;
//	}

//	// Update is called once per frame
//	void Update()
//	{
//		curr_tile = board.PositionToTile(playerRB.position);
//		attack_timer -= Time.deltaTime;
//		movement_timer -= Time.deltaTime;
//		if (leftPlayer)
//		{
//			x_input = Input.GetAxisRaw("LeftHorizontal");
//			y_input = Input.GetAxisRaw("LeftVertical");
//		}
//		else
//		{
//			x_input = Input.GetAxisRaw("RightHorizontal");
//			y_input = Input.GetAxisRaw("RightVertical");
//		}

//		//Basic Attack
//		if (BasicAttackControl())
//		{
//			BasicAttack();
//		}
//		//Card Attack

//		//Move
//		Move();
//	}

//	#endregion


//	#region basic_movement
//	// moves one unit in a direction
//	void Move()
//	{
//		if (movement_timer <= 0 && attack_timer <= 0)
//		{

//			movement_timer = movement_cooldown;


//			if (x_input > 0 && y_input == 0)
//			{
//				curr_dir = Vector2.right;
//			}
//			else if (x_input < 0 && y_input == 0)
//			{
//				curr_dir = Vector2.left;

//			}
//			else if (y_input < 0 && x_input == 0)
//			{
//				curr_dir = Vector2.down;
//			}
//			else if (y_input > 0 && x_input == 0)
//			{
//				curr_dir = Vector2.up;

//			}
//			Vector2 movementVector = new Vector2(x_input, y_input);

//			//can only move if the next tile can be accessed by the player
//			Vector2 nextPos = playerRB.position + movementVector;

//			Board.BoardTile nextTile = board.PositionToTile(nextPos);
//			if (nextTile != null && nextTile.CanBeAccessedBy(leftPlayer))
//			{
//				playerRB.position = nextPos;
//			}
//		}
//	}

//	#endregion

//	#region basic_attack

//	bool BasicAttackControl()
//	{
//		if (leftPlayer)
//		{
//			return Input.GetKeyDown(KeyCode.LeftControl);
//		}
//		else
//		{
//			return Input.GetKeyDown(KeyCode.RightControl);
//		}
//	}

//	void BasicAttack()
//	{
//		if (attack_timer <= 0)
//		{
//			attack_timer = basic_attack_duration;
//			StartCoroutine(BasicAttackRoutine());
//		}
//	}

//	IEnumerator BasicAttackRoutine()
//	{

//		//ANIMATION HERE
//		yield return null;

//		Vector2 offset;
//		if (leftPlayer)
//		{
//			offset = Vector2.right;
//		}
//		else
//		{
//			offset = Vector2.left;
//		}

//		//instantiate/initialize the BasicAttack proectile

//		Board.BoardTile spawnTile = board.PositionToTile(curr_tile.position + offset);
//		GameObject basicAttack = (GameObject)Instantiate(BasicAttackPrefab, spawnTile.position, Quaternion.identity);

//		//essentially the Awake function
//		BasicAttack projectile = basicAttack.GetComponent<BasicAttack>();
//		projectile.board = board;
//		projectile.curr_tile = spawnTile;
//		projectile.leftPlayer = leftPlayer;
//		projectile.moving_timer = projectile.time_on_tile;


//		//ANIMATION HERE
//		yield return null;
//	}
//	#endregion

//	#region health_func
//	public void TakeDamage(int amount)
//	{
//		// Reduce the current health by the damage amount.
//		if (leftPlayer)
//		{
//			LeftRoundHealth -= amount;
//			LeftHP.value = LeftRoundHealth / maxHealth;
//			if (LeftRoundHealth <= 0 && !isDead)
//			{
//				Death();
//			}
//		}
//		else
//		{
//			RightRoundHealth -= amount;
//			RightHP.value = RightRoundHealth / maxHealth;
//			if (RightRoundHealth <= 0 && !isDead)
//			{
//				Death();
//			}
//		}
//	}

//	void Death()
//	{
//		// Set the death flag so this function won't be called again.
//		isDead = true;

//		//GameObject go = GameObject.FindWithTag("GameController");
//		//go.GetComponent<GameManager>().NextPlayerRound();

//		// Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
//		//playerAudio.clip = deathClip;
//		//playerAudio.Play();
//	}
//	#endregion

//}
