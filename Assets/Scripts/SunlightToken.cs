using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunlightToken : MonoBehaviour
{
    // Start is called before the first frame update
    public int despawn_time;
    private float despawn_timer;

    private void Awake() {
        despawn_timer = despawn_time;
    }

    private void Update() {
        despawn_timer -= Time.deltaTime;
        if (despawn_timer < 0 ){
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            collision.gameObject.GetComponent<Player>().updateSunlightCounter();
            StartCoroutine(CollectToken());
        }
    }

    IEnumerator CollectToken()
    {
        //wait the animation time??
        yield return new WaitForSeconds(0.01f);
        Destroy(this.gameObject);
    }

}
