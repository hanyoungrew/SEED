using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ControllerManager : MonoBehaviour
{
    
    private LobbyUI lobby; 

    public void Awake(){
        lobby = GameObject.Find("Canvas").GetComponent<LobbyUI>();
    }

    public int numPlayers = 0;

    void OnPlayerJoined(){
        numPlayers += 1;
        if (numPlayers == 1) {
            lobby.leftClickedReady();
        } else if (numPlayers == 2) {
            lobby.rightClickedReady();
        }
    }
}
