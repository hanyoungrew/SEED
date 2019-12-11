using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownUI : MonoBehaviour
{
    Image cooldownImg;
    public float cooldown = 5;
    bool isCooldown;

    void Awake()
    {
        cooldownImg = GameObject.Find("CoolDown").GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isCooldown){
            cooldownImg.fillAmount += 1 / cooldown * Time.deltaTime;

            if (cooldownImg.fillAmount >= 1)
            {
                isCooldown = false;
            }
        }
    }

    void UseAbility()
    {
        cooldownImg.fillAmount = 0;
    }
}

// when ability is done, set isCooldown to true
// on using ability, call UseAbility()