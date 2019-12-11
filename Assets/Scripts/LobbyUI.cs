using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyUI : MonoBehaviour
{
    bool leftReady;
    bool rightReady;
    GameManager gm;
    Image leftReadied;
    Image rightReadied;

    private void Awake()
    {
        leftReady = false;
        rightReady = false;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        leftReadied = GameObject.Find("LeftReadied").GetComponent<Image>();
        rightReadied = GameObject.Find("RightReadied").GetComponent<Image>();
        leftReadied.enabled = false;
        rightReadied.enabled = false;
    }

    private void Update()
    {
        if (leftReady && rightReady)
        {
            Invoke("invokeRoundScene", 1.0f);
        }
    }

    public void leftClickedReady()
    {
        leftReady = true;
        leftReadied.enabled = true;
    }

    public void rightClickedReady()
    {
        rightReady = true;
        rightReadied.enabled = true;
    }

    private void invokeRoundScene(){
        gm.RoundScene();
    }
}
