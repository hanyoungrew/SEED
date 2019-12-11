using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictorySceneUI : MonoBehaviour
{
    public GameManager gm;
    Image LeftWin;
    Image LeftLose;
    Image RightWin;
    Image RightLose;

    private void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        LeftWin = GameObject.Find("LeftWin").GetComponent<Image>();
        LeftLose = GameObject.Find("LeftLose").GetComponent<Image>();
        RightWin = GameObject.Find("RightWin").GetComponent<Image>();
        RightLose = GameObject.Find("RightLose").GetComponent<Image>();

        LeftWin.enabled = false;
        LeftLose.enabled = false;
        RightWin.enabled = false;
        RightLose.enabled = false;
    }

    private void Update()
    {
        if (gm.lWins >= 3)
        {
            LeftWin.enabled = true;
            RightLose.enabled = true;

        } else if (gm.rWins >= 3)
        {
            RightWin.enabled = true;
            LeftLose.enabled = true;
        }
    }
}
