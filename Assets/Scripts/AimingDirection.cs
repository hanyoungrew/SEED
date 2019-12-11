using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingDirection : MonoBehaviour
{
    public float ratio;

    // Update is called once per frame
    public void MoveAimer(Vector2 in_aim)
    {
        this.transform.localPosition = in_aim.normalized * ratio;
    }
}
