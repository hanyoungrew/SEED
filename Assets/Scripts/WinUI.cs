using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinUI : MonoBehaviour
{
    public GameManager gm;
    Image Win1;
    Image Win2;
    Image Win3;
    Image Win4;
    Image Win5;

    Color left = Color.green;

    Color right = new Color32(145, 61, 136, 255);
    private void Awake()
    {
        Win1 = GameObject.Find("Win1").GetComponent<Image>();
        Win2 = GameObject.Find("Win2").GetComponent<Image>();
        Win3 = GameObject.Find("Win3").GetComponent<Image>();
        Win4 = GameObject.Find("Win4").GetComponent<Image>();
        Win5 = GameObject.Find("Win5").GetComponent<Image>();

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        for (int i = 1; i <= gm.allWins.Count; i++)
        {
            int whoWon = (int)gm.allWins[i-1];
            if (whoWon == 1) //left Won
            {
                LeftColourWinner(i);
            }
            if(whoWon == 2)
            {
                RightColourWinner(i);
            }
        }
    }

    private void LeftColourWinner(int winner)
    {
        switch (winner)
        {
            case 1:
                Win1.color = left;
                break;
            case 2:
                Win2.color = left;
                break;
            case 3:
                Win3.color = left;
                break;
            case 4:
                Win4.color = left;
                break;
            case 5:
                Win5.color = left;
                break;

        }
    }

    private void RightColourWinner(int winner)
    {
        switch (winner)
        {
            case 1:
                Win1.color = right;
                break;
            case 2:
                Win2.color = right;
                break;
            case 3:
                Win3.color = right;
                break;
            case 4:
                Win4.color = right;
                break;
            case 5:
                Win5.color = right;
                break;

        }
    }

    

}
