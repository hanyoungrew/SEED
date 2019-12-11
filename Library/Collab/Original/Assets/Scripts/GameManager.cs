using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

public class GameManager : MonoBehaviour
{
    
    #region GameManager var
    public static GameManager instance = null;
    
    //current scene name
    string curr;

    #endregion

    //variables to be saved between scenes
    #region saved data variables
    public int lSunlightCtr;
    public int rSunlightCtr;

    //for simplicity, FOR NOW simply utilize round number to determine win
    public int lWins;
    public int rWins;
    //public List<int> allWins = new List<int>();
    public ArrayList allWins = new ArrayList();

    public PlayerStats lStats;
    public PlayerStats rStats;

    public Player lPlayer;
    //public Board.BoardTile lPlayerCurrentTile;

    public Player rPlayer;
    //public Board.BoardTile rPlayerCurrentTile;


    //All cards that can be (eventually) used by either player (initialized by class?)
    [SerializeField]
    public Card[] leftPlayerCardLibrary;
    [SerializeField]
    public Card[] rightPlayerCardLibrary;

    //boolean array of which cards have been unlocked. TO DO LATER
    public bool[] lUnlocks;
    public bool[] rUnlocks;

    //list of cards each player are holding//time remaining to use card
    public List<(Card, float)> leftCardHolster = new List<(Card, float)>(); 
    public List<(Card, float)> rightCardHolster = new List<(Card, float)>();

    Image leftWonRound;
    Image rightWonRound;

    public float leftHealthPct;
    public float rightHealthPct;

    //reference elsewhere to see that both players have been loaded into the game now and the round can start
    public bool roundSafe;

    #endregion

    #region Unity Functions
    private void Awake()
    {
        if (instance is null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);


        //initializing saved variables
        lWins = 0;
        rWins = 0;
        lSunlightCtr = 0;
        rSunlightCtr = 0;
        lStats = new PlayerStats();         
        rStats = new PlayerStats();

        lUnlocks = new bool[leftPlayerCardLibrary.Length];
        rUnlocks = new bool[rightPlayerCardLibrary.Length];

        //for now unlock every card
        for (int i = 0; i < lUnlocks.Length; i++)
        {
            lUnlocks[i] = true; 
        }
        for (int i = 0; i < rUnlocks.Length; i++)
        {
            rUnlocks[i] = true;
        }


        curr = SceneManager.GetActiveScene().name;
        if (curr == "_preload" || curr == "TestScene") {
            SceneManager.LoadScene("GameStartScene");
            curr = SceneManager.GetActiveScene().name;
        }

        for (int i = 0; i < leftPlayerCardLibrary.Length; i++)
        {
            Card curCard = leftPlayerCardLibrary[i];
            if (lUnlocks[i])
            {
                leftCardHolster.Add((curCard, 0.0f));
            }
        }

        for (int i = 0; i < rightPlayerCardLibrary.Length; i++)
        {
            Card curCard = rightPlayerCardLibrary[i];
            if (rUnlocks[i])
            {
                rightCardHolster.Add((curCard, 0.0f));
            }
        }
        //leftWonRound = GameObject.Find("leftWon").GetComponent<Image>();
        //rightWonRound = GameObject.Find("rightWon").GetComponent<Image>();
        roundSafe = false;
    }



    public void Update(){
        //update all card timers
        if (roundSafe){
            for (int i = 0; i < leftCardHolster.Count; i++){
                float card_timer = leftCardHolster[i].Item2; 
                if (card_timer > 0){
                    card_timer -= Time.deltaTime;
                    if (card_timer < 0) {
                        card_timer = 0;
                    }
                    leftCardHolster[i] = (leftCardHolster[i].Item1, card_timer);
                }
            }
            for (int i = 0; i < rightCardHolster.Count; i++){
                float card_timer = rightCardHolster[i].Item2; 
                if (card_timer > 0){
                    card_timer -= Time.deltaTime;
                    if (card_timer < 0) {
                        card_timer = 0;
                    }
                    rightCardHolster[i] = (rightCardHolster[i].Item1, card_timer);
                }
            }

        }

    }


    #endregion


    #region misc
    //reset card holster to be 0 waiting timer
    public void resetCardHolster(){
        for (int i = 0; i < leftCardHolster.Count; i++){
            leftCardHolster[i] = (leftCardHolster[i].Item1, 0.0f);

        }
        for (int i = 0; i < rightCardHolster.Count; i++){
            rightCardHolster[i] = (leftCardHolster[i].Item1, 0.0f);

        }
    }


    //called by players when they die
    public void leftPlayerDead(){
        //update playerWins of rightPlayer
        rWins += 1;
        allWins.Add(2);
        disablePlayers();      

        if (rWins >= 3)
        {
            Invoke("VictoryScene", 2);
        }
        else
        {
            //rightWonRound.enabled = true;
            Invoke("UpgradeScene", 2);
        }
        
        Debug.Log("left dead");
    }

    public void rightPlayerDead(){
        //update playerWins of leftPlayer
        lWins += 1;
        allWins.Add(1);
        disablePlayers();      

        if (lWins >= 3)
        {
            Invoke("VictoryScene", 2);
        }
        else
        {
            //leftWonRound.enabled = true;
            Invoke("UpgradeScene", 2);
        }
        Debug.Log("lwins: " + lWins);
    }


    // UI for sunlight counter
    public string leftSunlight()
    {
        //Debug.Log(lSunlightCtr);
        string lSunlight = lSunlightCtr.ToString();
        return lSunlight;
    }

    public string rightSunlight()
    {
        //Debug.Log(rSunlightCtr);
        string rSunlight = rSunlightCtr.ToString();
        return rSunlight;
    }
    
    
    #endregion

    #region Scene_Transition

    public void RoundScene(){
        //start round with fresh card timers
        resetCardHolster();
        
        Debug.Log("Start Round Scene");
        SceneManager.LoadScene("RoundScene");
        
        //if first time round is started, i.e. not reloading players
        if (lPlayer == null){
            roundSafe = true;
        } else {
            //reloadPlayers();
            Invoke("reloadPlayers", 0.1f);
        }

    }

    public void disablePlayers(){
        roundSafe = false;
    }

    public void deactivatePlayers(){
        lPlayer.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        rPlayer.gameObject.GetComponent<SpriteRenderer>().enabled = false;

        lPlayer.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        rPlayer.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        
        lPlayer.enabled = false;
        rPlayer.enabled = false;
    }



    public void reloadPlayers(){
        try {
            lPlayer.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            lPlayer.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            lPlayer.enabled = true;

            rPlayer.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            rPlayer.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            rPlayer.enabled = true;

        } catch (Exception e){
            Debug.Log(e);
            Debug.Log("either first round or reloaded too fast");
        }

        lPlayer.loadPlayer();
        rPlayer.loadPlayer();
        roundSafe = true;
    }

    public void UpgradeToRoundScene()
    {
        RoundScene();
    }

    public void UpgradeScene()
    {
        deactivatePlayers();
        SceneManager.LoadScene("UpgradeScene");
    }
    
    public void VictoryScene()
    {
        deactivatePlayers();
        SceneManager.LoadScene("VictoryScene");
    }

    public void NewGame()
    {
        SceneManager.LoadScene("GameStartScene");
    }

    public void StartFirstRound()
    {
        SceneManager.LoadScene("LobbyScene");
    }
    #endregion
}
