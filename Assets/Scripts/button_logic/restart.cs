using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    // Start is called before the first frame update
    GameManager  gManager;
    Button thisButton;
     
    void Start()
    {
        gManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(this.Restart);
    }

    void Restart(){
                //audiomanager.StopMusic();
        GameObject s = gManager.audiomanager.gameObject;
        Destroy(gManager.audiomanager);
        Destroy(s);

        Destroy(gManager.lPlayer.gameObject);
        Destroy(gManager.lPlayer);
        Destroy(gManager.rPlayer.gameObject);
        Destroy(gManager.rPlayer); 
        Destroy(gManager.gameObject);
        Destroy(gManager);
        Invoke("ahh", 2.0f);
    }


    void ahh(){
        SceneManager.LoadScene("_preload");
    }
}
