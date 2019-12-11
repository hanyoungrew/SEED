using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class button_to_round : MonoBehaviour
{
    // Start is called before the first frame update
    GameManager  gManager;
    Button thisButton;
     
    void Start()
    {
        gManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(gManager.StartFirstRound);
    }
}
