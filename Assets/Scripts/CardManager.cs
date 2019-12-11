using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    GameManager control;

    #region player_variables
    Player curPlayer;
    Image cardImage; 
    #endregion

    #region cards_manager
    public int leftCardPointer;
    public int rightCardPointer;

    Card currentCard; 
    #endregion
    void Awake()
    {
        //cardImage = transform.GetComponent<Image>();
        //control = GameObject.Find("GameManager").GetComponent<GameManager>();
        //currentCard = curPlayer.current_card;
        //Debug.Log(currentCard.name.ToUpper());
        //cardImage.sprite = currentCard.CardImage();
            


    }

    private void UpdateCardImage()
    {
        
    }
}
