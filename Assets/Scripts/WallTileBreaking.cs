using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTileBreaking : MonoBehaviour
{
    int timesToBreak = 15;

    
    
    // Update is called once per frame
    public int DamageWall()
    {
        //Debug.Log("OUCH" + timesToBreak);
        timesToBreak -= 1;
        return timesToBreak;
        
    }
}
