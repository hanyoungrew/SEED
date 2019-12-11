using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpgradeUI : MonoBehaviour
{

    #region UI_var
    bool leftReady;
    bool rightReady;
    public Sprite readySprite;
    Image leftReadyImage;
    Image rightReadyImage;
    public GameManager gm;
    PlayerStats leftStats;
    PlayerStats rightStats;

    public Text leftSunlight;
    public Text rightSunlight;
    
    #endregion

    #region attackIntensity_Variables
    //Image leftAttack1;
    Image leftAttack2;
    Image leftAttack3;
    Image leftAttack4;
    Image leftAttack5;
    Image leftAttack6;
    Image leftAttack7;
    Image leftAttack8;
    Image leftAttack9;
    Image leftAttack10;
    Text leftAttack;
    Button leftAttackButton;

    //Image rightAttack1;
    Image rightAttack2;
    Image rightAttack3;
    Image rightAttack4;
    Image rightAttack5;
    Image rightAttack6;
    Image rightAttack7;
    Image rightAttack8;
    Image rightAttack9;
    Image rightAttack10;
    Text rightAttack;
    Button rightAttackButton;
    #endregion

    #region healIntensity_Variables
    int maxHealth = 100;

    Image leftHeal1;
    Image leftHeal2;
    Image leftHeal3;
    Image leftHeal4;
    Image leftHeal5;
    Image leftHeal6;
    Image leftHeal7;
    Image leftHeal8;
    Image leftHeal9;
    Image leftHeal10;
    Text leftHealth;
    Button leftHealthButton;

    Image rightHeal1;
    Image rightHeal2;
    Image rightHeal3;
    Image rightHeal4;
    Image rightHeal5;
    Image rightHeal6;
    Image rightHeal7;
    Image rightHeal8;
    Image rightHeal9;
    Image rightHeal10;
    Text rightHealth;
    Button rightHealthButton;

    //Slider rightHealSlider;
    //Slider leftHealSlider;
    #endregion

    #region speedIntensity_Variables
    Image leftSpeed1;
    Image leftSpeed2;
    Image leftSpeed3;
    Image leftSpeed4;
    Image leftSpeed5;
    Image leftSpeed6;
    Image leftSpeed7;
    Image leftSpeed8;
    Image leftSpeed9;
    Image leftSpeed10;
    Text leftSpeed;
    Button leftSpeedButton;

    Image rightSpeed1;
    Image rightSpeed2;
    Image rightSpeed3;
    Image rightSpeed4;
    Image rightSpeed5;
    Image rightSpeed6;
    Image rightSpeed7;
    Image rightSpeed8;
    Image rightSpeed9;
    Image rightSpeed10;
    Text rightSpeed;
    Button rightSpeedButton;
    #endregion


    //Image leftMove1;
    //Image leftMove2;
    //Image leftMove3;
    //Image leftMove4;
    //Image leftMove5;

    #region Unity_func

    private void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        leftStats = gm.lStats;
        rightStats = gm.rStats;

        AwakeAttackIntensity();
        AwakeHealthIntensity();
        AwakeSpeedIntensity();
        leftSunlight = GameObject.Find("LSunlight").GetComponent<Text>();
        rightSunlight = GameObject.Find("RSunlight").GetComponent<Text>();
    }

    private void Update()
    {
        leftSunlight.text = gm.leftSunlight();
        rightSunlight.text = gm.rightSunlight();
    }


    
    #region attack
    private void UpgradeLeftAttack(){

        if (leftStats.attackLvl < 10){
            gm.lSunlightCtr -= 1;
            leftStats.attackLvl+= 1;
        }

    }

    public void UpdateLeftAttackLevel(){
       if (gm.lSunlightCtr >= 1){
        UpgradeLeftAttack();
        leftAttackIntensity();
       }
    }
    private void leftAttackIntensity()
    {

        if (leftStats.attackLvl == 10){
            leftAttackButton.interactable = false;
        }


        leftAttack.text = leftStats.attackLvl.ToString();
        if (leftStats.attackLvl>= 2)
        {
            leftAttack2.enabled = true;
            if (leftStats.attackLvl>= 3)
            {
                leftAttack3.enabled = true;
                if (leftStats.attackLvl>= 4)
                {
                    leftAttack4.enabled = true;
                    if (leftStats.attackLvl>= 5)
                    {
                        leftAttack5.enabled = true;
                        if (leftStats.attackLvl>= 6)
                        {
                            leftAttack6.enabled = true;
                            if (leftStats.attackLvl>= 7)
                            {
                                leftAttack7.enabled = true;
                                if (leftStats.attackLvl>= 8)
                                {
                                    leftAttack8.enabled = true;
                                    if (leftStats.attackLvl>= 9)
                                    {
                                        leftAttack9.enabled = true;
                                        if (leftStats.attackLvl>= 10)
                                        {
                                            leftAttack10.enabled = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }




    private void UpgradeRightAttack(){

        if (rightStats.attackLvl < 10){
            gm.rSunlightCtr -= 1;
            rightStats.attackLvl+= 1;
        }

    }

    public void UpdateRightAttackLevel(){
       if (gm.rSunlightCtr >= 1){
        UpgradeRightAttack();
        rightAttackIntensity();
       }
    }
    private void rightAttackIntensity()
    {
        if (rightStats.attackLvl == 10){
            rightAttackButton.interactable = false;
        }
        rightAttack.text = rightStats.attackLvl.ToString();
        if (rightStats.attackLvl>= 2)
        {
            rightAttack2.enabled = true;
            if (rightStats.attackLvl>= 3)
            {
                rightAttack3.enabled = true;
                if (rightStats.attackLvl>= 4)
                {
                    rightAttack4.enabled = true;
                    if (rightStats.attackLvl>= 5)
                    {
                        rightAttack5.enabled = true;
                        if (rightStats.attackLvl>= 6)
                        {
                            rightAttack6.enabled = true;
                            if (rightStats.attackLvl>= 7)
                            {
                                rightAttack7.enabled = true;
                                if (rightStats.attackLvl>= 8)
                                {
                                    rightAttack8.enabled = true;
                                    if (rightStats.attackLvl>= 9)
                                    {
                                        rightAttack9.enabled = true;
                                        if (rightStats.attackLvl>= 10)
                                        {
                                            rightAttack10.enabled = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    #endregion





    #region health

    private void UpgradeLeftHealth(){
        if (leftStats.healthLvl < 10){
            gm.lSunlightCtr -= 1;
            leftStats.healthLvl+= 1;
        }

    }
    public void UpdateLeftHealthLevel(){
       if (gm.lSunlightCtr >= 1){
        UpgradeLeftHealth();
        leftHealIntensity();
       }
    }


    private void leftHealIntensity()
    {
        if (leftStats.healthLvl == 10){
            leftHealthButton.interactable = false;
        }

        leftHealth.text = leftStats.healthLvl.ToString();
        if (leftStats.healthLvl>= 2)
        {
            leftHeal2.enabled = true;
            if (leftStats.healthLvl>= 3)
            {
                leftHeal3.enabled = true;
                if (leftStats.healthLvl>= 4)
                {
                    leftHeal4.enabled = true;
                    if (leftStats.healthLvl>= 5)
                    {
                        leftHeal5.enabled = true;
                        if (leftStats.healthLvl>= 6)
                        {
                            leftHeal6.enabled = true;
                            if (leftStats.healthLvl>= 7)
                            {
                                leftHeal7.enabled = true;
                                if (leftStats.healthLvl>= 8)
                                {
                                    leftHeal8.enabled = true;
                                    if (leftStats.healthLvl>= 9)
                                    {
                                        leftHeal9.enabled = true;
                                        if (leftStats.healthLvl>= 10)
                                        {
                                            leftHeal10.enabled = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        //leftStats.healthLvl+= 1;
        //leftHealSlider.value = leftStats.healthStat/ maxHealth;
    }





    //////////


    private void UpgradeRightHealth(){
        if (rightStats.healthLvl < 10){
            gm.rSunlightCtr -= 1;
            rightStats.healthLvl += 1;
        }
    }

    public void UpdateRightHealthLevel(){
        if (gm.rSunlightCtr >= 1){
            UpgradeRightHealth();
            rightHealIntensity();
        }
    }


    private void rightHealIntensity()
    {

        if (rightStats.healthLvl == 10){
            rightHealthButton.interactable = false;
        }

        rightHealth.text = rightStats.healthLvl.ToString();
        if (rightStats.healthLvl>= 2)
        {
            rightHeal2.enabled = true;
            if (rightStats.healthLvl>= 3)
            {
                rightHeal3.enabled = true;
                if (rightStats.healthLvl>= 4)
                {
                    rightHeal4.enabled = true;
                    if (rightStats.healthLvl>= 5)
                    {
                        rightHeal5.enabled = true;
                        if (rightStats.healthLvl>= 6)
                        {
                            rightHeal6.enabled = true;
                            if (rightStats.healthLvl>= 7)
                            {
                                rightHeal7.enabled = true;
                                if (rightStats.healthLvl>= 8)
                                {
                                    rightHeal8.enabled = true;
                                    if (rightStats.healthLvl>= 9)
                                    {
                                        rightHeal9.enabled = true;
                                        if (rightStats.healthLvl>= 10)
                                        {
                                            rightHeal10.enabled = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        //rightStats.healthLvl+= 1;
        //rightHealSlider.value = rightStats.healthStat/ maxHealth;

    }

    #endregion




    #region speed

    private void UpgradeLeftSpeed(){
        if (leftStats.speedLvl < 10){
            gm.lSunlightCtr -= 1;
            leftStats.speedLvl+= 1;
        }

    }
    public void UpdateLeftSpeedLevel(){
       if (gm.lSunlightCtr >= 1){
        UpgradeLeftSpeed();
        leftSpeedIntensity();
       }
    }


    private void leftSpeedIntensity()
    {
        if (leftStats.speedLvl == 10){
            leftSpeedButton.interactable = false;   
        }

        leftSpeed.text = leftStats.speedLvl.ToString();
        if (leftStats.speedLvl>= 2)
        {
            leftSpeed2.enabled = true;
            if (leftStats.speedLvl>= 3)
            {
                leftSpeed3.enabled = true;
                if (leftStats.speedLvl>= 4)
                {
                    leftSpeed4.enabled = true;
                    if (leftStats.speedLvl>= 5)
                    {
                        leftSpeed5.enabled = true;
                        if (leftStats.speedLvl>= 6)
                        {
                            leftSpeed6.enabled = true;
                            if (leftStats.speedLvl>= 7)
                            {
                                leftSpeed7.enabled = true;
                                if (leftStats.speedLvl>= 8)
                                {
                                    leftSpeed8.enabled = true;
                                    if (leftStats.speedLvl>= 9)
                                    {
                                        leftSpeed9.enabled = true;
                                        if (leftStats.speedLvl>= 10)
                                        {
                                            leftSpeed10.enabled = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    private void UpgradeRightSpeed(){
        if (rightStats.speedLvl < 10){
            gm.rSunlightCtr -= 1;
            rightStats.speedLvl+= 1;
        }

    }
    public void UpdateRightSpeedLevel(){
       if (gm.rSunlightCtr >= 1){
        UpgradeRightSpeed();
        rightSpeedIntensity();
       }
    }



    private void rightSpeedIntensity()
    {
        if (rightStats.speedLvl == 10){
            rightSpeedButton.interactable = false;   
        }

        rightSpeed.text = rightStats.speedLvl.ToString();
        if (rightStats.speedLvl>= 2)
        {
            rightSpeed2.enabled = true;
            if (rightStats.speedLvl>= 3)
            {
                rightSpeed3.enabled = true;
                if (rightStats.speedLvl>= 4)
                {
                    rightSpeed4.enabled = true;
                    if (rightStats.speedLvl>= 5)
                    {
                        rightSpeed5.enabled = true;
                        if (rightStats.speedLvl>= 6)
                        {
                            rightSpeed6.enabled = true;
                            if (rightStats.speedLvl>= 7)
                            {
                                rightSpeed7.enabled = true;
                                if (rightStats.speedLvl>= 8)
                                {
                                    rightSpeed8.enabled = true;
                                    if (rightStats.speedLvl>= 9)
                                    {
                                        rightSpeed9.enabled = true;
                                        if (rightStats.speedLvl>= 10)
                                        {
                                            rightSpeed10.enabled = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion




    #region done buttons
    public void LeftUpgradeDone()
    {
        leftReadyImage = GameObject.Find("leftReadyImage").GetComponent<Image>();
        leftReady = true;
        leftReadyImage.sprite = readySprite;
        //leftReadyImage.enabled = true; (alternative method)
        if (rightReady)
        {
            DoneWithUpgrades();
        }
    }
    public void RightUpgradeDone()
    {
        rightReadyImage = GameObject.Find("rightReadyImage").GetComponent<Image>();
        rightReady = true;
        rightReadyImage.sprite = readySprite;
        if (leftReady)
        {
            DoneWithUpgrades();
        }
    }

    public void DoneWithUpgrades(){
        
        //set stats in gm to appropriate level
        leftStats.updateStats();
        rightStats.updateStats();

        //set stats of (existing) player objects using these stats
        //workaround for DontDestroyOnLoad

        //write this code later

        //call next scene
        gm.RoundScene();
        //gm.CardSelectionScene();

    }

    #endregion
    public void AwakeAttackIntensity()
    {
        leftAttack2 = GameObject.Find("lAttack2").GetComponent<Image>();
        leftAttack3 = GameObject.Find("lAttack3").GetComponent<Image>();
        leftAttack4 = GameObject.Find("lAttack4").GetComponent<Image>();
        leftAttack5 = GameObject.Find("lAttack5").GetComponent<Image>();
        leftAttack6 = GameObject.Find("lAttack6").GetComponent<Image>();
        leftAttack7 = GameObject.Find("lAttack7").GetComponent<Image>();
        leftAttack8 = GameObject.Find("lAttack8").GetComponent<Image>();
        leftAttack9 = GameObject.Find("lAttack9").GetComponent<Image>();
        leftAttack10 = GameObject.Find("lAttack10").GetComponent<Image>();
        leftAttack = GameObject.Find("leftAttackText").GetComponent<Text>();
        leftAttackButton = GameObject.Find("leftAttackButton").GetComponent<Button>();

        rightAttack2 = GameObject.Find("rAttack2").GetComponent<Image>();
        rightAttack3 = GameObject.Find("rAttack3").GetComponent<Image>();
        rightAttack4 = GameObject.Find("rAttack4").GetComponent<Image>();
        rightAttack5 = GameObject.Find("rAttack5").GetComponent<Image>();
        rightAttack6 = GameObject.Find("rAttack6").GetComponent<Image>();
        rightAttack7 = GameObject.Find("rAttack7").GetComponent<Image>();
        rightAttack8 = GameObject.Find("rAttack8").GetComponent<Image>();
        rightAttack9 = GameObject.Find("rAttack9").GetComponent<Image>();
        rightAttack10 = GameObject.Find("rAttack10").GetComponent<Image>();
        rightAttack = GameObject.Find("rightAttackText").GetComponent<Text>();
        rightAttackButton = GameObject.Find("rightAttackButton").GetComponent<Button>();

        leftAttack2.enabled = false;
        leftAttack3.enabled = false;
        leftAttack4.enabled = false;
        leftAttack5.enabled = false;
        leftAttack6.enabled = false;
        leftAttack7.enabled = false;
        leftAttack8.enabled = false;
        leftAttack9.enabled = false;
        leftAttack10.enabled = false;

        rightAttack2.enabled = false;
        rightAttack3.enabled = false;
        rightAttack4.enabled = false;
        rightAttack5.enabled = false;
        rightAttack6.enabled = false;
        rightAttack7.enabled = false;
        rightAttack8.enabled = false;
        rightAttack9.enabled = false;
        rightAttack10.enabled = false;

        leftAttackIntensity();
        rightAttackIntensity();
    }

    public void AwakeHealthIntensity()
    {
        leftHeal2 = GameObject.Find("lHeal2").GetComponent<Image>();
        leftHeal3 = GameObject.Find("lHeal3").GetComponent<Image>();
        leftHeal4 = GameObject.Find("lHeal4").GetComponent<Image>();
        leftHeal5 = GameObject.Find("lHeal5").GetComponent<Image>();
        leftHeal6 = GameObject.Find("lHeal6").GetComponent<Image>();
        leftHeal7 = GameObject.Find("lHeal7").GetComponent<Image>();
        leftHeal8 = GameObject.Find("lHeal8").GetComponent<Image>();
        leftHeal9 = GameObject.Find("lHeal9").GetComponent<Image>();
        leftHeal10 = GameObject.Find("lHeal10").GetComponent<Image>();
        leftHealth = GameObject.Find("leftHealth").GetComponent<Text>();
        leftHealthButton = GameObject.Find("leftHealthButton").GetComponent<Button>();

        rightHeal2 = GameObject.Find("rHeal2").GetComponent<Image>();
        rightHeal3 = GameObject.Find("rHeal3").GetComponent<Image>();
        rightHeal4 = GameObject.Find("rHeal4").GetComponent<Image>();
        rightHeal5 = GameObject.Find("rHeal5").GetComponent<Image>();
        rightHeal6 = GameObject.Find("rHeal6").GetComponent<Image>();
        rightHeal7 = GameObject.Find("rHeal7").GetComponent<Image>();
        rightHeal8 = GameObject.Find("rHeal8").GetComponent<Image>();
        rightHeal9 = GameObject.Find("rHeal9").GetComponent<Image>();
        rightHeal10 = GameObject.Find("rHeal10").GetComponent<Image>();
        rightHealth = GameObject.Find("rightHealth").GetComponent<Text>();
        rightHealthButton = GameObject.Find("rightHealthButton").GetComponent<Button>();

        leftHeal2.enabled = false;
        leftHeal3.enabled = false;
        leftHeal4.enabled = false;
        leftHeal5.enabled = false;
        leftHeal6.enabled = false;
        leftHeal7.enabled = false;
        leftHeal8.enabled = false;
        leftHeal9.enabled = false;
        leftHeal10.enabled = false;

        rightHeal2.enabled = false;
        rightHeal3.enabled = false;
        rightHeal4.enabled = false;
        rightHeal5.enabled = false;
        rightHeal6.enabled = false;
        rightHeal7.enabled = false;
        rightHeal8.enabled = false;
        rightHeal9.enabled = false;
        rightHeal10.enabled = false;

        //leftHealSlider = GameObject.Find("leftHealSlider").GetComponent<Slider>();
        //rightHealSlider = GameObject.Find("rightHealSlider").GetComponent<Slider>();
        //leftHealSlider.value = leftStats.healthStat/ maxHealth;
        //rightHealSlider.value = rightStats.healthStat/ maxHealth;


        leftHealIntensity();
        rightHealIntensity();
    }

    public void AwakeSpeedIntensity()
    {
        leftSpeed2 = GameObject.Find("lSpeed2").GetComponent<Image>();
        leftSpeed3 = GameObject.Find("lSpeed3").GetComponent<Image>();
        leftSpeed4 = GameObject.Find("lSpeed4").GetComponent<Image>();
        leftSpeed5 = GameObject.Find("lSpeed5").GetComponent<Image>();
        leftSpeed6 = GameObject.Find("lSpeed6").GetComponent<Image>();
        leftSpeed7 = GameObject.Find("lSpeed7").GetComponent<Image>();
        leftSpeed8 = GameObject.Find("lSpeed8").GetComponent<Image>();
        leftSpeed9 = GameObject.Find("lSpeed9").GetComponent<Image>();
        leftSpeed10 = GameObject.Find("lSpeed10").GetComponent<Image>();
        leftSpeed = GameObject.Find("leftSpeed").GetComponent<Text>();
        leftSpeedButton = GameObject.Find("leftSpeedButton").GetComponent<Button>();

        rightSpeed2 = GameObject.Find("rSpeed2").GetComponent<Image>();
        rightSpeed3 = GameObject.Find("rSpeed3").GetComponent<Image>();
        rightSpeed4 = GameObject.Find("rSpeed4").GetComponent<Image>();
        rightSpeed5 = GameObject.Find("rSpeed5").GetComponent<Image>();
        rightSpeed6 = GameObject.Find("rSpeed6").GetComponent<Image>();
        rightSpeed7 = GameObject.Find("rSpeed7").GetComponent<Image>();
        rightSpeed8 = GameObject.Find("rSpeed8").GetComponent<Image>();
        rightSpeed9 = GameObject.Find("rSpeed9").GetComponent<Image>();
        rightSpeed10 = GameObject.Find("rSpeed10").GetComponent<Image>();
        rightSpeed = GameObject.Find("rightSpeed").GetComponent<Text>();
        rightSpeedButton = GameObject.Find("rightSpeedButton").GetComponent<Button>();

        leftSpeed2.enabled = false;
        leftSpeed3.enabled = false;
        leftSpeed4.enabled = false;
        leftSpeed5.enabled = false;
        leftSpeed6.enabled = false;
        leftSpeed7.enabled = false;
        leftSpeed8.enabled = false;
        leftSpeed9.enabled = false;
        leftSpeed10.enabled = false;

        rightSpeed2.enabled = false;
        rightSpeed3.enabled = false;
        rightSpeed4.enabled = false;
        rightSpeed5.enabled = false;
        rightSpeed6.enabled = false;
        rightSpeed7.enabled = false;
        rightSpeed8.enabled = false;
        rightSpeed9.enabled = false;
        rightSpeed10.enabled = false;

        leftSpeedIntensity();
        rightSpeedIntensity();
    }
}
#endregion
