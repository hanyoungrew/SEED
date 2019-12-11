using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundUI : MonoBehaviour
{
    #region sliders
    public Slider LeftHP;                                        
    public Slider RightHP;

    //public Player leftPlayer;
    //public Player rightPlayer;

    public Text leftSunlight;
    public Text rightSunlight;

    public GameManager gm;

    public Image leftCard;
    public Image rightCard;

    public Text leftCardText;
    public Text rightCardText;

    public Text leftSunlightText;
    public Text rightSunlightText;

    //added by Emanuel for crude ability cooldown
    public int leftCardIndex = 0;
    public int rightCardIndex = 0;

    //public Text leftCardTimer;
    //public Text rightCardTimer;
    public Image leftCardTimer;
    public Image rightCardTimer;
    Image leftWonRound;
    Image rightWonRound;
    Image drawImg;
    Image leftWonSD;
    Image rightWonSD;

    Text countdownText;
    float timer;
    Image timesUpImg;
    bool flashOnce;
    Text five;
    Text four;
    Text three;
    Text two;
    Text one;

    #endregion

    // Start is called before the first frame update
    void Awake()
    {
        timer = 60.0f;
        countdownText = GameObject.Find("Countdown").GetComponent<Text>();
        timesUpImg = GameObject.Find("TimesUp").GetComponent<Image>();
        timesUpImg.enabled = false;
        flashOnce = true;
        five = GameObject.Find("5").GetComponent<Text>();
        four = GameObject.Find("4").GetComponent<Text>();
        three = GameObject.Find("3").GetComponent<Text>();
        two = GameObject.Find("2").GetComponent<Text>();
        one = GameObject.Find("1").GetComponent<Text>();
        five.enabled = false;
        four.enabled = false;
        three.enabled = false;
        two.enabled = false;
        one.enabled = false;


        //leftPlayer = GameObject.Find("LeftPlayer").GetComponent<Player>();
        //rightPlayer = GameObject.Find("RightPlayer").GetComponent<Player>();
        LeftHP = GameObject.FindGameObjectWithTag("leftHP").GetComponent<Slider>();
        RightHP = GameObject.FindGameObjectWithTag("rightHP").GetComponent<Slider>();
        leftSunlight = GameObject.Find("LSunlightCtr").GetComponent<Text>();
        rightSunlight = GameObject.Find("RSunlightCtr").GetComponent<Text>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        leftCard = GameObject.Find("LeftCardImage").GetComponent<Image>();
        rightCard = GameObject.Find("RightCardImage").GetComponent<Image>();

        leftCardText = GameObject.Find("LeftCardText").GetComponent<Text>();
        rightCardText = GameObject.Find("RightCardText").GetComponent<Text>();

        leftCardText.transform.position = leftCard.transform.position + new Vector3(0, 50, 0);
        rightCardText.transform.position = rightCard.transform.position + new Vector3(0, 50, 0);

        leftSunlightText = GameObject.Find("LeftSunlightCost").GetComponent<Text>();
        rightSunlightText = GameObject.Find("RightSunlightCost").GetComponent<Text>();


        leftWonRound = GameObject.Find("leftWon").GetComponent<Image>();
        rightWonRound = GameObject.Find("rightWon").GetComponent<Image>();
        leftWonSD = GameObject.Find("leftWonSD").GetComponent<Image>();
        rightWonSD = GameObject.Find("rightWonSD").GetComponent<Image>();
        drawImg = GameObject.Find("Draw").GetComponent<Image>();
        leftWonRound.enabled = false;
        rightWonRound.enabled = false;
        leftWonSD.enabled = false;
        rightWonSD.enabled = false;
        drawImg.enabled = false;

        //added by Emanuel for crude card timer
        //leftCardTimer =  GameObject.Find("LTimer").GetComponent<Text>();
        //rightCardTimer = GameObject.Find("RTimer").GetComponent<Text>();

        //new card timer 
        leftCardTimer =  GameObject.Find("LeftCoolDown").GetComponent<Image>();
        rightCardTimer =  GameObject.Find("RightCoolDown").GetComponent<Image>();
        
    }

    // Update is called once per frame
    public void UpdatePlayerHealth(bool leftPlayer, Player p)
    {
        if (leftPlayer){
            float LeftHealth = p.roundHealthPercentage();
            LeftHP.value = LeftHealth;
            if(LeftHP.value <= 0)
            {
                rightWonRound.enabled = true;
            }
        } else {
            float RightHealth = p.roundHealthPercentage();
            RightHP.value = RightHealth;
            if(RightHP.value <= 0)
            {
                leftWonRound.enabled = true;
            }
        } 
    }


    private void Update() {
        //Debug.Log("Update was called");
        if (gm.roundSafe){
            
            if (timer > 0.0f)
            {
                timer -= Time.deltaTime;
                countdownText.text = timer.ToString("F");
                if(timer >= 5.0f && timer < 6.0f)
                {
                    countdownText.enabled = false;
                    five.enabled = true;
                }
                if (timer >= 4.0f && timer < 5.0f)
                {
                    five.enabled = false;
                    four.enabled = true;
                }
                if (timer >= 3.0f && timer < 4.0f)
                {
                    four.enabled = false;
                    three.enabled = true;
                }
                if (timer >= 2.0f && timer < 3.0f)
                {
                    three.enabled = false;
                    two.enabled = true;
                }
                if (timer >= 1.0f && timer < 2.0f)
                {
                    two.enabled = false;
                    one.enabled = true;
                }
                if (timer >= 0.0f && timer < 1.0f)
                {
                    one.enabled = false;
                }
            } else
            {
                countdownText.enabled = false;
                if(LeftHP.value > RightHP.value)
                {
                    timesUpImg.enabled = true;
                    leftWonRound.enabled = true;
                    gm.rPlayer.Die();
                }
                else if (RightHP.value > LeftHP.value)
                {
                    timesUpImg.enabled = true;
                    rightWonRound.enabled = true;
                    gm.lPlayer.Die();
                }
                else
                {
                    if (flashOnce)
                    {
                        timesUpImg.enabled = true;
                    }
                    Invoke("DrawnGame", 2);
                    
                }
            }

            // use gm.leftCardHolster[leftCardIndex].Item1.cooldownTime to normalize this 
            // gm.leftCardHolster[leftCardIndex].Item2 = current time remaining to use card again
            leftSunlight.text = gm.leftSunlight();
            rightSunlight.text = gm.rightSunlight();

            float lfull_cool_down = gm.leftCardHolster[leftCardIndex].Item1.cooldownTime;
            float lpercent = gm.leftCardHolster[leftCardIndex].Item2 / lfull_cool_down;
            //leftCardTimer.text = lpercent.ToString() + "%";
            leftCardTimer.fillAmount = lpercent;

            float rfull_cool_down = gm.rightCardHolster[rightCardIndex].Item1.cooldownTime;
            float rpercent = gm.rightCardHolster[rightCardIndex].Item2 / rfull_cool_down;
            //rightCardTimer.text = rpercent.ToString() + "%";
            rightCardTimer.fillAmount = rpercent;


        }
    }

    public void UpdatePlayerCard(Player p)
    {
        if (p.leftPlayer)
        {
            leftCard.sprite = p.current_card.CardImage();
            leftCardIndex = p.card_index;
            leftCardText.text = p.current_card.name;
            leftSunlightText.text = p.current_card.sunlightCost.ToString();
        } else
        {
            rightCard.sprite = p.current_card.CardImage();
            rightCardIndex = p.card_index;
            rightCardText.text = p.current_card.name;
            rightSunlightText.text = p.current_card.sunlightCost.ToString();
        }
    }

    public void DrawnGame()
    {
        flashOnce = false;
        timesUpImg.enabled = false;
        drawImg.enabled = true;
        // sudden death logic
        Invoke("SuddenDeath", 2);
    }

    public void SuddenDeath() {
        if (LeftHP.value > RightHP.value)
        {
            leftWonSD.enabled = true;
            gm.rPlayer.Die();
        }
        else if (RightHP.value > LeftHP.value)
        {
            rightWonSD.enabled = true;
            gm.lPlayer.Die();
        }
    }
}
