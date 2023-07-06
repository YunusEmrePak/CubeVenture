using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public static PlayerAnimation instance;

    void Awake() {
        instance = this;
    }

    public void JumpAnimation()
    {
        transform.Rotate(new Vector3(0,0,-180));
        transform.Translate(Vector3.up);
    }
}
