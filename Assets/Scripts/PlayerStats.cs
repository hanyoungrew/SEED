using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{
        
    #region changeable stats
    //influences all relative strength of all attacks
    public float attackStat;

    //influences movement speed
    public float speedStat;

    //influences projectile speed
    public float projectileSpeedStat;

    // amount of health the player starts the game with
    public float healthStat;

    //how long before one can basic attack again
    public float basic_attack_duration;

    //how long before one can sword attack again
    public float sword_attack_duration;

    //create a spell tree based on player upgrade points 'blessings'
    public float blessingCount;
    #endregion
    
    #region levels

    public int attackLvl;
    public int healthLvl;
    public int speedLvl;

    // try doing switch statements instead
    public float[] attackValues = {1f,1.2f,1.6f,2.4f,3.4f,4f,5f,6f,7f,8f};
    public float[] healthValues = {10f,15f,17f,20f,22f,25f,27f,30f,32f,35f};
    public float[] speedValues = {3.0f ,3.25f, 3.50f, 3.75f, 4.0f, 4.25f, 4.5f, 4.75f, 5.0f, 5.25f};

    #endregion


    //default initialization. Later we can vary initialization based off the player's class
    public PlayerStats() //range from 1 to 10 to show 'level'
    {
        attackLvl = 1;
        healthLvl = 1;
        speedLvl = 1;

        attackStat = attackValues[attackLvl - 1];
        healthStat = healthValues[healthLvl - 1];
        speedStat = speedValues[speedLvl - 1];
        //attackStat = 1; //up to 10
        //speedStat = 5; //dont go lower than 5 (5 to 10 is good range)
        //healthStat = 50; //boost to 1000?
        projectileSpeedStat = 10; // 10 to 20
        basic_attack_duration = 0.1f;
        sword_attack_duration = 0.3f; 
        blessingCount = 0;
    }

    //updates stats according to current level
    public void updateStats(){
        attackStat = attackValues[attackLvl - 1];
        healthStat = healthValues[healthLvl - 1];
        speedStat = speedValues[speedLvl - 1];
    }
}
